using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Mayo : ITopping
    {
        public ISandwich Sandwich {get; set;}
        public ITopping Topping {get; set;}
        public decimal _serveCount = 0;
        public decimal price = 0m;

        public Mayo(ITopping topping)
        {
            Topping = topping;
            price += topping.GetPrice();
        }

        public Mayo(ISandwich sandwich)
        {
            Sandwich = sandwich;
            price += sandwich.GetPrice();
        }

        public string GetDescription()
        {
            return " + Mayo";
        }

        public decimal GetPrice()
        {
            return price;
        }
    }
}
