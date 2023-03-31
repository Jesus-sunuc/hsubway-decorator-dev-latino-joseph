using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class BBQ : ITopping
    {
        public ISandwich Sandwich {get; set;}
        public ITopping Topping {get; set;}
        decimal _serveCount = 0;
        public decimal price = 0m;

        public BBQ(ITopping topping)
        {
            Topping = topping;
            price += topping.GetPrice();
        }

        public BBQ(ISandwich sandwich)
        {
            Sandwich = sandwich;
            price += sandwich.GetPrice();
        }

        public string GetDescription()
        {
            return " + BBQ";
        }

        public decimal GetPrice()
        {
            return price;
        }
    }
}
