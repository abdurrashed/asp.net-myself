


using Linq;

List<string> list = new List<string> { "apple", "banana", "mango" };

List<Order> orders = new List<Order>
{
 new Order {Item="banana",Quantity=10},
 new Order { Item="mango",Quantity=20},
 new Order{Item="jackfruit",Quantity=30}


};


var quantites=(from o in orders
 join n in list on o.Item equals n
 select o.Quantity);

foreach (var item in quantites)
    Console.WriteLine(item);

int count=orders.Count(x=>x.Quantity<15);