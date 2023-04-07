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
        int sandwichStock = 10;
        int breadStock = 3;
        int toppingStock = 4000;

        //Keeps track of how much money was made in the day
        decimal dailyRevenue = 0;

        int BLT;
        int PBJ;
        int Chicken;
        public int white;
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
            if (sandwichStock == 0 || breadStock == 0 || toppingStock == 0)
            {
                return true;
            }

            return false;
        }

        public void SellBLT(Bread bread)
        {
            if (breadStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell BLT sandwich or bread due to missing of bread");
            }

            breadStock -= 2;
            //sandwichStock--;
            BLT++;
            if (bread == Bread.rye) { rye += 2; }
            else if (bread == Bread.wheat) { wheat += 2; }
            else { white += 2; }
        }

        public void SellPBJ(Bread bread)
        {
            if (breadStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell BLT sandwich due to missing bread.");
            }
            breadStock -= 2;
            //sandwichStock--;
            PBJ++;
            if (bread == Bread.rye) { rye += 2; }
            else if (bread == Bread.wheat) { wheat += 2; }
            else { white += 2; }
        }
        public void SellChicken(Bread bread)
        {
            if (breadStock <= 0)
            {;
                throw new MissingIngredientException("Cannot sell BLT sandwich due to missing bread.");
            }

            breadStock -= 2;
            //sandwichStock--;
            Chicken++;
            if (bread == Bread.rye) { rye += 2; }
            else if (bread == Bread.wheat) { wheat += 2; }
            else { white += 2; }
        }
        public void SellBacon()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell bacon due to missing bacon.");
            }
            toppingStock--;

            bacon++;
        }

        public void SellHam()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell the sandwich due to missing ham.");
            }

            toppingStock--;
            ham++;
        }

        public void SellMustard()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell the sandwich due to missing mustard.");
            }

            toppingStock--;
            mustard++;
        }

        public void SellBBQ()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell the sandwich due to missing BBQ topping.");
            }

            toppingStock--;
            BBQ++;
        }

        public void SellCheese()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell the sandwich due to missing cheese topping.");
            }

            toppingStock--;
            cheese++;
        }

        public void SellLettuce()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell the sandwich due to missing lettuce topping.");
            }

            toppingStock--;
            lettuce++;
        }

        public void SellMayo()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell the sandwich due to missing mayo topping.");
            }

            toppingStock--;
            mayo++;
        }

        public void SellTomato()
        {
            if (toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell the sandwich due to missing tomato topping.");
            }

            toppingStock--;
            tomato++;
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
                $"Tomato topping: {tomato}" +
                $"{breadStock}";
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
    }
}
