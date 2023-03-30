using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public interface ITopping
    {
        ISandwich Sandwich {get; set;}
        ITopping Topping {get; set;}
        public decimal GetPrice();
        public string GetDescription();
    }
}
