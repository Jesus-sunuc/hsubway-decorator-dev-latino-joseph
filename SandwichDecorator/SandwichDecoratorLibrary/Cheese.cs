using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Cheese : ITopping
    {
        public ISandwich Sandwich {get; set;}
        public ITopping Topping {get; set;}
        decimal price = .75m;
        string description;

        public Cheese(ITopping topping) 
        {
            Topping = topping;
            description = " + cheese";
        }
        public Cheese(ISandwich sandwich) 
        {
            Sandwich = sandwich;
            description = " + cheese";
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
