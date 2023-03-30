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
        public Bacon(ITopping topping)
        {
            Topping = topping;

            price += topping.GetPrice();
        }
        public Bacon(ISandwich sandwich)
        {
            Sandwich = sandwich;

            price += sandwich.GetPrice();
        }
        public decimal GetPrice()
        {
            return price;
        }
        public string GetDescription()
        {
            return " + bacon";
        }
    }
}
