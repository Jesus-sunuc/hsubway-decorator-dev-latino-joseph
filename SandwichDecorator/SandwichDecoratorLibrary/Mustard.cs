using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Mustard : ITopping
    {
        public Mustard(ITopping topping)
        {

        }
        public Mustard(ISandwich sandwich)
        {

        }
        public decimal GetPrice()
        {
            return 0;
        }
        public string GetDescription()
        {
            return "";
        }
    }
}
