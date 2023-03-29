using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Ham : ITopping
    {
        ISandwich Sandwich;
        ITopping Topping;
        decimal price = .60m;
        public Ham(ITopping topping)
        {
            Topping = topping;

            price += topping.GetPrice();
        }
        public Ham(ISandwich sandwich)
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
            return "+ ham";
        }
    }
}
