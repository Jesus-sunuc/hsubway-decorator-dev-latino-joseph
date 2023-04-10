using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    public class Inventory
    {
        public int sandwichStock = 50;
        public int breadStock = 4;
        public int toppingStock = 4;

        //Keeps track of how much money was made in the day
        decimal dailyRevenue = 0;

        //Keeps track of how much was spent on ingredients
        // Costs:
        // Bacon $0.33
        // Ham   $0.28
        // Cheese $.40
        // Tomato $0.20
        // Lettuce $0.20
        // BBQ Sauce  $0.02
        // Mayo Sauce $0.04
        // Mustard    $0.01
        // WhiteBread  0.33/slice
        // WheatBread  0.38/slice
        // RyeBread    0.68/slice
        // PBJingredient  $0.78
        // BLTingredient  $1.25
        // SChickeningredient $1.75

        decimal Expenses = 0;

        int BLT;
        int PBJ;
        int Chicken;
        int white;
        int wheat;
        int rye;
        int bacon;
        int BBQ;
        int cheese;
        int ham;
        int lettuce;
        int mayo;
        int mustard;
        int tomato;

        public Inventory()
        {
            ResetStock();
        }

        public bool IsEmpty()
        {
            if (sandwichStock <= 0 || breadStock <= 1 || toppingStock <= 0)
            {
                return true;
            }

            return false;
        }

        public void SellBLT(Bread bread)
        {
            if (breadStock <= 1)
            {
                throw new MissingIngredientException("Cannot sell BLT sandwich due to missing bread.");
            }
            else if (sandwichStock <= 1)
            {
                throw new MissingIngredientException("Sorry, we cannot sell more BLT sandwich");
            }

            breadStock = breadStock - 2;
            sandwichStock--;

            BLT++;
            Expenses += 1.25m;
            if (bread == Bread.rye) { rye += 2; Expenses += 0.68m * 2; }
            else if (bread == Bread.wheat) { wheat += 2; Expenses += 0.38m * 2; }
            else { white += 2; Expenses += 0.33m * 2; }
        }

        public void SellPBJ(Bread bread)
        {
            if (breadStock <= 1)
            {
                throw new MissingIngredientException("Cannot sell PBJ sandwich due to missing bread.");
            }

            else if (sandwichStock <= 1)
            {
                throw new MissingIngredientException("Sorry, we cannot sell more PBJ sandwich");
            }

            breadStock = breadStock - 2;
            sandwichStock--;

            PBJ++;
            Expenses += 0.78m;
            if (bread == Bread.rye) { rye += 2; Expenses += 0.68m * 2; }
            else if (bread == Bread.wheat) { wheat += 2; Expenses += 0.38m * 2; }
            else { white += 2; Expenses += 0.33m * 2; }
        }
        public void SellChicken(Bread bread)
        {
            if (breadStock <= 1)
            {
                throw new MissingIngredientException("Cannot sell Chicken sandwich due to missing bread.");
            }

            else if (sandwichStock <= 1)
            {
                throw new MissingIngredientException("Sorry, we cannot sell more Chicken sandwich");
            }

            breadStock = breadStock - 2;
            sandwichStock--;

            Chicken++;
            Expenses += 1.75m;
            if (bread == Bread.rye) { rye += 2; Expenses += 0.68m * 2; }
            else if (bread == Bread.wheat) { wheat += 2; Expenses += 0.38m * 2; }
            else { white += 2; Expenses += 0.33m * 2; }
        }
        public void SellBacon()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell sandwich due to missing bacon.");
            }
            toppingStock--;
            bacon++;
            Expenses += 0.33m;
        }

        public void SellHam()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell sandwich due to missing ham.");
            }

            toppingStock--;
            ham++;
            Expenses += 0.28m;
        }

        public void SellMustard()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell sandwich due to missing mustard.");
            }

            toppingStock--;
            mustard++;
            Expenses += 0.01m;
        }

        public void SellBBQ()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell sandwich due to missing BBQ");
            }

            toppingStock--;
            BBQ++;
            Expenses += 0.02m;
        }

        public void SellCheese()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell sandwich due to missing cheese.");
            }

            toppingStock--;
            cheese++;
            Expenses += 0.40m;
        }

        public void SellLettuce()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell sandwich due to missing lettuce.");
            }

            toppingStock--;
            lettuce++;
            Expenses += 0.20m;
        }

        public void SellMayo()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell sandwich due to missing mayo.");
            }

            toppingStock--;
            mayo++;
            Expenses += 0.04m;
        }

        public void SellTomato()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell sandwich due to missing tomato.");
            }

            toppingStock--;
            tomato++;
            Expenses += 0.20m;
        }

        public string Report()
        {
            return $"Sales made \n" +
                $"BLT sandwiches: {BLT}\n" +
                $"PBJ sandwiches: {PBJ}\n" +
                $"Chicken sandwiches: {Chicken}\n" +
                $"White bread: {white}\n" +
                $"Wheat bread: {wheat}\n" +
                $"Rye bread: {rye} \n" +
                $"Bacon topping: {bacon}\n" +
                $"Ham topping: {ham}\n" +
                $"Mustard topping: {mustard}\n" +
                $"BBQ topping: {BBQ}\n" +
                $"Cheese topping: {cheese}\n" +
                $"Lettuce topping: {lettuce}\n" +
                $"Mayo topping: {mayo}\n" +
                $"Tomato topping: {tomato}\n" +

                $"\nBread Stock left: {breadStock}\n" +
                $"Topping Stock left: {toppingStock}\n" +
                $"Sandwich Stock left: {sandwichStock}\n" +

                $"\nRevenue obtained: ${dailyRevenue}\n" +
                $"Money spent on ingredients: ${Expenses}\n" +
                $"Total profit: ${GetProfit()}";

                
        }
        public void ResetStock()
        {
            BLT = 0;
            PBJ = 0;
            Chicken = 0;
            white = 0;
            wheat = 0;
            rye = 0;
            bacon = 0;
            ham = 0;
            mustard = 0;
            BBQ = 0;
            cheese = 0;
            lettuce = 0;
            mayo = 0;
            tomato = 0;
        }

        public void AddRevenue(decimal money)
        {
            dailyRevenue += money;
        }

        public decimal GetRevenue()
        {
            return dailyRevenue;
        }
        public decimal GetExpenses()
        {
            return Expenses;
        }

        //Metod to return profit made during the day

        public decimal GetProfit()
        {
            return dailyRevenue - Expenses;
        }
    }
}
