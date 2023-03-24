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
            
        }

        [Then(@"the sandwich will cost \$(.*)")]
        public void ThenTheSandwichWillCost(Decimal p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the sandwich is described as ""([^""]*)""")]
        public void ThenTheSandwichIsDescribedAs(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"a BLT sandwich on wheat bread is ordered")]
        public void WhenABLTSandwichOnWheatBreadIsOrdered()
        {
            throw new PendingStepException();
        }

        [When(@"a PBJ sandwich on white bread is ordered")]
        public void WhenAPBJSandwichOnWhiteBreadIsOrdered()
        {
            throw new PendingStepException();
        }

        [When(@"a PBJ sandwich on wheat bread is ordered")]
        public void WhenAPBJSandwichOnWheatBreadIsOrdered()
        {
            throw new PendingStepException();
        }

        [When(@"a chicken sandwich on white bread is ordered")]
        public void WhenAChickenSandwichOnWhiteBreadIsOrdered()
        {
            throw new PendingStepException();
        }

        [When(@"a chicken sandwich on wheat bread is ordered")]
        public void WhenAChickenSandwichOnWheatBreadIsOrdered()
        {
            throw new PendingStepException();
        }
    }
}
