using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Ham : ITopping
    {
        public ISandwich Sandwich {get; set;}
        public ITopping Topping {get; set;}
        decimal price = .60m;
        string description;
        public Ham(ITopping topping)
        {
            Topping = topping;
            description = " + ham";
        }
        public Ham(ISandwich sandwich)
        {
            Sandwich = sandwich;
            description = " + ham";
        }
        public decimal GetPrice()
        {
            return price;
        }
        public string GetDescription()
        {
            return description;
        }
    }
}
