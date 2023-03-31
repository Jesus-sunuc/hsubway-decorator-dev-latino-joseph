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
        //public decimal _serveCount = 0;
        decimal price = 0m;
        string description;

        public Mayo(ITopping topping)
        {
            Topping = topping;
            price += topping.GetPrice();
            description = $"{topping.GetDescription()} + mayo";
        }

        public Mayo(ISandwich sandwich)
        {
            Sandwich = sandwich;
            price += sandwich.GetPrice();
            description = $"{sandwich.GetDescription()} + mayo";
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
