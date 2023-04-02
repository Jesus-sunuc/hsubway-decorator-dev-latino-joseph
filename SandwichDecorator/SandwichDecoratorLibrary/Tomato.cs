using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Tomato : ITopping
    {
        public ISandwich Sandwich {get; set;}
        public ITopping Topping {get; set;}
        decimal price = .25m;
        string description;
        public Tomato(ITopping topping)
        {
            Topping = topping;
            description = " + tomato";
        }
        public Tomato(ISandwich sandwich)
        {
            Sandwich = sandwich;
            description = " + tomato";
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
