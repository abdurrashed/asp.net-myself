using System.Reflection;

Assembly a = Assembly.GetExecutingAssembly();
var types = a.GetTypes();
foreach(Type t in types)
{

    var interfaces = t.GetInterfaces();
    if(interfaces.Any(x => x.Name == "IPuchasable")) 
    {

        ConstructorInfo constructor =t.GetConstructor([typeof(string), typeof(double), typeof(double) ]);

        object? O=constructor.Invoke(["Camera", 30000, 10]);
        MethodInfo method1 = t.GetMethod("CalculatePriceAfterTax", BindingFlags.Instance | BindingFlags.Public);
       MethodInfo method2 = t.GetMethod("CalculateDiscount", BindingFlags.Instance | BindingFlags.Public, [typeof(double)]);

        double? r1 = (double?)method1?.Invoke(O, []);
        double? r2 = (double?)method2?.Invoke(O, [5]);

        Console.WriteLine(r1);
        Console.WriteLine(r2);


    }






}