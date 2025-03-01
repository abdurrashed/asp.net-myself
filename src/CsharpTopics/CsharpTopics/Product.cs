using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTopics
{
    public class Product : IPuchasable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }



        public Product(string name, double price, double tax)
        {
            Name = name;
            Price = price;
            Tax = tax;
        }
        public double CalculatePriceAfterTax()
        {
            return Price + Tax;
        }

   

        public double CalculateDiscount(double discount)
        {
            return Price * discount / 100;
        }
    }
}
