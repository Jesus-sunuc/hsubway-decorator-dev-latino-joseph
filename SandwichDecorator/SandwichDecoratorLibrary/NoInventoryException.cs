using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class MissingIngredientException : Exception
    {
        public MissingIngredientException(string message) : base(message)
        {
        }
    }
}


