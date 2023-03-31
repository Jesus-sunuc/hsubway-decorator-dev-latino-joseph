using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Lettuce : ITopping
    {
        public ISandwich Sandwich {get; set;}
        public ITopping Topping {get; set;}
        decimal price = .25m;
        string description;
        public Lettuce(ITopping topping)
        {
            Topping = topping;

            price += topping.GetPrice();
            description = $"{topping.GetDescription()} + lettuce";
        }
        public Lettuce(ISandwich sandwich)
        {
            Sandwich = sandwich;

            price += sandwich.GetPrice();
            description = $"{sandwich.GetDescription()} + lettuce";
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
