using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Bacon : ITopping
    {
        public ISandwich Sandwich {get; set;}
        public ITopping Topping {get; set;}
        decimal price = .75m;
        string description;

        public Bacon(ITopping topping)
        {
            Topping = topping;

            price += topping.GetPrice();
            description = $"{topping.GetDescription()} + bacon";
        }
        public Bacon(ISandwich sandwich)
        {
            Sandwich = sandwich;

            price += sandwich.GetPrice();
            description = $"{sandwich.GetDescription()} + bacon";
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
