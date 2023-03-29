using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Mayo : ITopping
    {
        private ITopping _topping;
        private ISandwich sandwich;
        private static int _serveCount = 0;

        public Mayo(ITopping topping)
        {
            _topping = topping;
        }
        public Mayo(ISandwich sandwich)
        {

        }

        public string GetDescription()
        {
            /*return _topping.GetDescription();*/
            return $"You served {_serveCount.ToString()}";
        }

        public decimal GetPrice()
        {
            return _topping.GetPrice();
        }

        public int ServeCount
        {
            get { return _serveCount; }
        }

        public static void Serve()
        {
            _serveCount++;
        }
    }
}
