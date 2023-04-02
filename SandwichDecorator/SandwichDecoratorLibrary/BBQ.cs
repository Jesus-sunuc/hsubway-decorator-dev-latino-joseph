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
        decimal price = 0m;
        string description;
        public BBQ(ITopping topping)
        {
            Topping = topping;
            description = " + BBQ";
        }

        public BBQ(ISandwich sandwich)
        {
            Sandwich = sandwich;
            description = $" + BBQ";
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
