namespace SandwichDecoratorLibrary
{
    public class BLTSandwich: ISandwich
    {
        Bread bread;
        decimal price = 4.50m;

        public BLTSandwich(Bread b)
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
            return $"BLT sandwich on {bread} bread";
        }
    }
}