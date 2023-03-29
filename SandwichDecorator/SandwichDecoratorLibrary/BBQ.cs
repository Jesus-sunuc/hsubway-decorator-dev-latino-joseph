using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class BBQ : ITopping
    {
        ISandwich Sandwich;
        ITopping _topping;
        decimal _serveCount = 0;

        public BBQ(ITopping topping)
        {
            _topping = topping;
            _serveCount += topping.GetPrice();
        }

        public BBQ(ISandwich sandwich)
        {
            Sandwich = sandwich;
            _serveCount += sandwich.GetPrice();
        }

        public string GetDescription()
        {
            return "+ BBQ";
        }

        public decimal GetPrice()
        {
            return 0;
        }
    }
}
