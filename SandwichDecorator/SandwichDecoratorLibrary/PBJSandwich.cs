using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class PBJSandwich : ISandwich
    {
        public Bread bread;
        public decimal price = 2.75m;

        public PBJSandwich(Bread b)
        {
            bread = b;
            if (bread == Bread.wheat)
            {
                price += .25m;
            }
            else if (bread == Bread.rye)
            {
                price += .50m;
            }
        }
        public decimal GetPrice()
        {
            return price;
        }
        public string GetDescription()
        {
            return $"PBJ sandwich on {bread} bread";
        }
    }
}
