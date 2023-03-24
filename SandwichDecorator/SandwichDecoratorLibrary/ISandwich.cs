using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public interface ISandwich
    {
        public decimal GetPrice();
        public string GetDescription();
    }
}
