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
        public Lettuce(ITopping topping)
        {
            Topping = topping;

            price += topping.GetPrice();
        }
        public Lettuce(ISandwich sandwich)
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
            return " + lettuce";
        }
    }
}
