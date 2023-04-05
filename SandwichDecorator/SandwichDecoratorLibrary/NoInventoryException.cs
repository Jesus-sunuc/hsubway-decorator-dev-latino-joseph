using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class NoInventoryException : Exception
    {
        public NoInventoryException(ITopping t) : base($"Inventory of {t} is out of stock") 
        {
            
        }
    }
}
