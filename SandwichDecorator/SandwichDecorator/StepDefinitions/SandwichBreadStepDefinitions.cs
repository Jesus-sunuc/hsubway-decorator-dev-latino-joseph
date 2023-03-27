using FluentAssertions;
using SandwichDecoratorLibrary;
using System;
using TechTalk.SpecFlow;

namespace SandwichDecorator.StepDefinitions
{
    [Binding]
    public class SandwichBreadStepDefinitions
    {
        private ScenarioContext _sc;

        public SandwichBreadStepDefinitions(ScenarioContext scenario)
        {
            _sc = scenario;
            _sc.Add("topped", null);
        }

        [When(@"a BLT sandwich on white bread is ordered")]
        public void WhenABLTSandwichOnWhiteBreadIsOrdered()
        {
            BLTSandwich sandwich = new BLTSandwich(Bread.white);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"a BLT sandwich on wheat bread is ordered")]
        public void WhenABLTSandwichOnWheatBreadIsOrdered()
        {
            BLTSandwich sandwich = new BLTSandwich(Bread.wheat);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"a BLT sandwich on rye bread is ordered")]
        public void WhenABLTSandwichOnRyeBreadIsOrdered()
        {
            BLTSandwich sandwich = new BLTSandwich(Bread.rye);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"a PBJ sandwich on white bread is ordered")]
        public void WhenAPBJSandwichOnWhiteBreadIsOrdered()
        {
            PBJSandwich sandwich = new PBJSandwich(Bread.white);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"a PBJ sandwich on wheat bread is ordered")]
        public void WhenAPBJSandwichOnWheatBreadIsOrdered()
        {
            PBJSandwich sandwich = new PBJSandwich(Bread.wheat);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"a PBJ sandwich on rye bread is ordered")]
        public void WhenAPBJSandwichOnRyeBreadIsOrdered()
        {
            PBJSandwich sandwich = new PBJSandwich(Bread.rye);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"a chicken sandwich on white bread is ordered")]
        public void WhenAChickenSandwichOnWhiteBreadIsOrdered()
        {
            ChickenSandwich sandwich = new ChickenSandwich(Bread.white);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"a chicken sandwich on wheat bread is ordered")]
        public void WhenAChickenSandwichOnWheatBreadIsOrdered()
        {
            ChickenSandwich sandwich = new ChickenSandwich(Bread.wheat);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"a chicken sandwich on rye bread is ordered")]
        public void WhenAChickenSandwichOnRyeBreadIsOrdered()
        {
            ChickenSandwich sandwich = new ChickenSandwich(Bread.rye);
            _sc.Add("sandwich", sandwich);
        }

        [When(@"customer orders cheese")]
        public void WhenCustomerOrdersCheese()
        {
            ITopping newtopping;
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                newtopping = new Cheese(topping);
            }
            else
            {
                newtopping = new Cheese(sandwich);
            }
            _sc.Set<ITopping>(topping, "topped");
        }

        [When(@"customer orders lettuce")]
        public void WhenCustomerOrdersLettuce()
        {
            ITopping newtopping;
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                newtopping = new Lettuce(topping);
            }
            else
            {
                newtopping = new Lettuce(sandwich);
            }
            _sc.Set<ITopping>(topping, "topped");
        }

        [When(@"customer orders tomato")]
        public void WhenCustomerOrdersTomato()
        {
            ITopping newtopping;
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                newtopping = new Tomato(topping);
            }
            else
            {
                newtopping = new Tomato(sandwich);
            }
            _sc.Set<ITopping>(topping, "topped");
        }

        [When(@"customer orders bacon")]
        public void WhenCustomerOrdersBacon()
        {
            ITopping newtopping;
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                newtopping = new Bacon(topping);
            }
            else
            {
                newtopping = new Bacon(sandwich);
            }
            _sc.Set<ITopping>(topping, "topped");
        }

        [Then(@"the sandwich will cost \$(.*)")]
        public void ThenTheSandwichWillCost(Decimal p0)
        {
            //_sc.Get<ISandwich>("sandwich").GetPrice().Should().BeApproximately(p0, 0.1m);
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                topping.GetPrice().Should().BeApproximately(p0, 0.1m);
            }
            else
            {
                sandwich.GetPrice().Should().BeApproximately(p0, 0.1m);
            }
        }

        [Then(@"the sandwich is described as ""([^""]*)""")]
        public void ThenTheSandwichIsDescribedAs(string p0)
        {
            //_sc.Get<ISandwich>("sandwich").GetDescription().Should().Be(p0);
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                topping.GetDescription().Should().Be(p0);
            }
            else
            {
                sandwich.GetDescription().Should().Be(p0);
            }
        }
    }
}
