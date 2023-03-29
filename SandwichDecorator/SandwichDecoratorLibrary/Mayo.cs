using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace SandwichDecoratorLibrary
{
    public class Mayo : ITopping
    {
        public Mayo(ITopping topping)
        {
            
        }
        public Mayo(ISandwich sandwich)
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
*/

namespace SandwichDecoratorLibrary
{
    public class Mayo : ITopping
    {
        private ITopping _topping;
        private static int _serveCount = 0;

        public Mayo(ITopping topping)
        {
            _topping = topping;
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
