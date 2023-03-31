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
        //decimal _serveCount = 0;
        decimal price = 0m;
        string description;

        public BBQ(ITopping topping)
        {
            Topping = topping;
            price += topping.GetPrice();
            description = $"{topping.GetDescription()} + BBQ";
        }

        public BBQ(ISandwich sandwich)
        {
            Sandwich = sandwich;
            price += sandwich.GetPrice();
            description = $"{sandwich.GetDescription()} + BBQ";
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
