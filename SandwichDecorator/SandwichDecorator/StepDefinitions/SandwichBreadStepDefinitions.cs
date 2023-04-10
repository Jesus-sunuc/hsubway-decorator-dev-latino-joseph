using FluentAssertions;
using NUnit.Framework;
using SandwichDecoratorLibrary;
using System;
using TechTalk.SpecFlow;

namespace SandwichDecorator.StepDefinitions
{
    [Binding]
    public class SandwichBreadStepDefinitions
    {
        private void ResetSandwichAndTopping()
        {
            _sc.Set<ISandwich>(null, "sandwich");
            _sc.Set<ITopping>(null, "topped");
        }

        static (decimal, string) GetFinalPriceAndDescription(object sandwich)
        {
            decimal finalPrice = 0;
            string finalDescription = "";

            if (sandwich is ISandwich)
            {
                finalPrice = ((ISandwich)sandwich).GetPrice();
                finalDescription = ((ISandwich)sandwich).GetDescription() + finalDescription;
                return (finalPrice, finalDescription);
            }
            else
            {
                if (((ITopping)sandwich).Sandwich != null)
                {
                    var Tuple = GetFinalPriceAndDescription(((ITopping)sandwich).Sandwich);
                    finalPrice = Tuple.Item1 + ((ITopping)sandwich).GetPrice() + finalPrice;
                    finalDescription = Tuple.Item2 + ((ITopping)sandwich).GetDescription() + finalDescription;
                    return (finalPrice, finalDescription);

                }
                else
                {
                    var Tuple = GetFinalPriceAndDescription(((ITopping)sandwich).Topping);
                    finalPrice = Tuple.Item1 + ((ITopping)sandwich).GetPrice() + finalPrice;
                    finalDescription = Tuple.Item2 + ((ITopping)sandwich).GetDescription() + finalDescription;
                    return (finalPrice, finalDescription);
                }
            }
        }

        private ScenarioContext _sc;

        private decimal _dailySale;
        public SandwichBreadStepDefinitions(ScenarioContext scenario)
        {
            _sc = scenario;
            _sc.Add("topped", null);
            _sc.Add("inventory", new Inventory());
            _sc.Add("sandwich", null);
            _dailySale = 0;
        }

        [When(@"there is only (.*) slices of white bread")]
        public void WhenThereIsOnlySlicesOfWhiteBread(int p0)
        {
            Inventory inventory = _sc.Get<Inventory>("inventory");
            inventory.breadStock = 3;
            _sc.Set<Inventory>(inventory, "inventory");
        }

        [When(@"a BLT sandwich on white bread is ordered")]
        public void WhenABLTSandwichOnWhiteBreadIsOrdered()
        {
            Inventory inventory = _sc.Get<Inventory>("inventory");
            BLTSandwich sandwich = null;
            try
            {
                inventory.SellBLT(Bread.white);
                sandwich = new BLTSandwich(Bread.white);
            }
            catch (MissingIngredientException ex)
            {
                _sc.Add("Exception", ex);
            }
            _sc.Set<Inventory>(inventory, "inventory");
            _sc.Set<ISandwich>(sandwich, "sandwich");
        }

        [When(@"a BLT sandwich on wheat bread is ordered")]
        public void WhenABLTSandwichOnWheatBreadIsOrdered()
        {
            ResetSandwichAndTopping();
            BLTSandwich sandwich = new BLTSandwich(Bread.wheat);
            _sc.Set<ISandwich>(sandwich, "sandwich");
        }

        [When(@"a BLT sandwich on rye bread is ordered")]
        public void WhenABLTSandwichOnRyeBreadIsOrdered()
        {
            ResetSandwichAndTopping();
            BLTSandwich sandwich = new BLTSandwich(Bread.rye);
            _sc.Set<ISandwich>(sandwich, "sandwich");
        }

        [When(@"a PBJ sandwich on white bread is ordered")]
        public void WhenAPBJSandwichOnWhiteBreadIsOrdered()
        {
            ResetSandwichAndTopping();
            PBJSandwich sandwich = new PBJSandwich(Bread.white);
            _sc.Set<ISandwich>(sandwich, "sandwich");
        }

        [When(@"a PBJ sandwich on wheat bread is ordered")]
        public void WhenAPBJSandwichOnWheatBreadIsOrdered()
        {
            ResetSandwichAndTopping();
            PBJSandwich sandwich = new PBJSandwich(Bread.wheat);
            _sc.Set<ISandwich>(sandwich, "sandwich");
        }

        [When(@"a PBJ sandwich on rye bread is ordered")]
        public void WhenAPBJSandwichOnRyeBreadIsOrdered()
        {
            ResetSandwichAndTopping();
            PBJSandwich sandwich = new PBJSandwich(Bread.rye);
            _sc.Set<ISandwich>(sandwich, "sandwich");
        }

        [When(@"a chicken sandwich on white bread is ordered")]
        public void WhenAChickenSandwichOnWhiteBreadIsOrdered()
        {
            ResetSandwichAndTopping();
            ChickenSandwich sandwich = new ChickenSandwich(Bread.white);
            _sc.Set<ISandwich>(sandwich, "sandwich");
        }

        [When(@"a chicken sandwich on wheat bread is ordered")]
        public void WhenAChickenSandwichOnWheatBreadIsOrdered()
        {
            ResetSandwichAndTopping();
            ChickenSandwich sandwich = new ChickenSandwich(Bread.wheat);
            _sc.Set<ISandwich>(sandwich, "sandwich");
        }

        [When(@"a chicken sandwich on rye bread is ordered")]
        public void WhenAChickenSandwichOnRyeBreadIsOrdered()
        {
            ResetSandwichAndTopping();
            ChickenSandwich sandwich = new ChickenSandwich(Bread.rye);
            _sc.Set<ISandwich>(sandwich, "sandwich");
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
            _sc.Set<ITopping>(newtopping, "topped");
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
            _sc.Set<ITopping>(newtopping, "topped");
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
            _sc.Set<ITopping>(newtopping, "topped");
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
            _sc.Set<ITopping>(newtopping, "topped");
        }

        [When(@"customer orders BBQ")]
        public void WhenCustomerOrdersBBQ()
        {
            ITopping newtopping;
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                newtopping = new BBQ(topping);
            }
            else
            {
                newtopping = new BBQ(sandwich);
            }
            _sc.Set<ITopping>(newtopping, "topped");
        }

        [When(@"customer orders mayo")]
        public void WhenCustomerOrdersMayo()
        {
            ITopping newtopping;
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                newtopping = new Mayo(topping);
            }
            else
            {
                newtopping = new Mayo(sandwich);
            }
            _sc.Set<ITopping>(newtopping, "topped");
        }

        [When(@"customer orders mustard")]
        public void WhenCustomerOrdersMustard()
        {
            ITopping newtopping;
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                newtopping = new Mustard(topping);
            }
            else
            {
                newtopping = new Mustard(sandwich);
            }
            _sc.Set<ITopping>(newtopping, "topped");
        }


        [Then(@"the sandwich will cost \$(.*)")]
        public void ThenTheSandwichWillCost(Decimal p0)
        {
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");

            decimal price;
            if (topping != null)
            {
                price = GetFinalPriceAndDescription(topping).Item1;
            }
            else
            {
                price = GetFinalPriceAndDescription(sandwich).Item1;
            }

            price.Should().BeApproximately(p0, 0.1m);
            _dailySale += price; // Add the sandwich price to the daily sale
        }

        [Then(@"the sandwich is described as ""([^""]*)""")]
        public void ThenTheSandwichIsDescribedAs(string p0)
        {
            ISandwich sandwich = _sc.Get<ISandwich>("sandwich");
            ITopping topping = _sc.Get<ITopping>("topped");
            if (topping != null)
            {
                GetFinalPriceAndDescription(topping).Item2.Should().Be(p0);
            }
            else
            {
                GetFinalPriceAndDescription(sandwich).Item2.Should().Be(p0);
            }
        }

        [Then(@"It will throw a MissingIngredientException error")]
        public void ThenItWillThrowAError()
        {
            MissingIngredientException ex = _sc.Get<MissingIngredientException>("Exception");
            ex.Message.Should().Be($"Cannot sell BLT sandwich due to missing bread.");
        }

        [Then(@"the daily sale should be \$(.*)")]
        public void ThenTheDailySaleShouldBe(Decimal p0)
        {
            _dailySale.Should().BeApproximately(p0, 0.1m);
        }

        private decimal revenue;
        private decimal expenses;
        private decimal profit;
        private Inventory shop = new Inventory();

        [Given(@"the sandwich shop made \$(.*) in revenue")]
        public void GivenTheSandwichShopMadeInRevenue(decimal amount)
        {
            revenue = amount;
            shop.AddRevenue(amount);
        }

        [Given(@"spent \$(.*) on ingredients")]
        public void GivenSpentOnIngredients(decimal amount)
        {
            expenses = amount;
            shop.GetExpenses(amount);
        }

        [When(@"the owner calculates the profit")]
        public void WhenTheOwnerCalculatesTheProfit()
        {
            profit = shop.GetProfit();
        }

        [Then(@"the profit should be \$(.*)")]
        public void ThenTheProfitShouldBe(decimal expectedProfit)
        {
            Assert.AreEqual(expectedProfit, profit);
        }
    }
}