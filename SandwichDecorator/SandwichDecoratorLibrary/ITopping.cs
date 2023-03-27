using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public interface ITopping
    {
        public decimal GetPrice();
        public string GetDescription();
    }
}
