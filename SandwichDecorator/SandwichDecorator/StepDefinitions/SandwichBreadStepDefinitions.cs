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


        [Then(@"the sandwich will cost \$(.*)")]
        public void ThenTheSandwichWillCost(Decimal p0)
        {
            _sc.Get<ISandwich>("sandwich").GetPrice().Should().BeApproximately(p0, 0.1m);
            //ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            //sandwich.GetPrice().Should().BeApproximately(p0, 0.1m);
        }

        [Then(@"the sandwich is described as ""([^""]*)""")]
        public void ThenTheSandwichIsDescribedAs(string p0)
        {
            _sc.Get<ISandwich>("sandwich").GetDescription().Should().Be(p0);
        }
    }
}
