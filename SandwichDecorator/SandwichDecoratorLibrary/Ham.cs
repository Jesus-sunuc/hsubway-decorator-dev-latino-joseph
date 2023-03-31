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

            price += topping.GetPrice();
            description = $"{topping.GetDescription()} + ham";
        }
        public Ham(ISandwich sandwich)
        {
            Sandwich = sandwich;

            price += sandwich.GetPrice();
            description = $"{sandwich.GetDescription()} + ham";
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
