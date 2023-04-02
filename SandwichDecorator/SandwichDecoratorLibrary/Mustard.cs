using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Mustard : ITopping
    {
        public ISandwich Sandwich {get; set;}
        public ITopping Topping {get; set;}
        //public decimal _serveCount = 0;
        decimal price = 0m;
        string description;

        public Mustard(ITopping topping)
        {
            Topping = topping;
            description = " + mustard";
        }

        public Mustard(ISandwich sandwich)
        {
            Sandwich = sandwich;
            description = "+ mustard";
        }

        public string GetDescription()
        {
            return description;
        }

        public decimal GetPrice()
        {
            return price;
        }
    }
}
