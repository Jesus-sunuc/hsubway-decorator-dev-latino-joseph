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
        int breadStock = 50;
        int toppingStock = 4;

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
            if (BLT <= 0 || (bread == Bread.rye && rye < 2) || (bread == Bread.wheat && wheat < 2) || (bread == Bread.white && white < 2) || breadStock <= 0 || toppingStock <= 0 || sandwichStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell BLT sandwich due to missing of bread");
            }

            BLT--;
            if (bread == Bread.rye) { rye = rye - 2; }
            else if (bread == Bread.wheat) { wheat = wheat - 2; }
            else { white = white - 2; }
        }

        public void SellPBJ(Bread bread)
        {
            if (PBJ <= 0 || (bread == Bread.rye && rye < 2) || (bread == Bread.wheat && wheat < 2) || (bread == Bread.white && white < 2) || breadStock <= 0 || toppingStock <= 0 || sandwichStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell BLT sandwich due to missing bread.");
            }

            PBJ--;
            if (bread == Bread.rye) { rye = rye - 2; }
            else if (bread == Bread.wheat) { wheat = wheat - 2; }
            else { white = white - 2; }
        }
        public void SellChicken(Bread bread)
        {
            if (Chicken <= 0 || (bread == Bread.rye && rye < 2) || (bread == Bread.wheat && wheat < 2) || (bread == Bread.white && white < 2) || breadStock <= 0 || sandwichStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell BLT sandwich due to missing bread.");
            }

            Chicken--;
            if (bread == Bread.rye) { rye = rye - 2; }
            else if (bread == Bread.wheat) { wheat = wheat - 2; }
            else { white = white - 2; }
        }
        public void SellBacon()
        {
            bacon--;
            if(toppingStock <= 0)
            {
                throw new MissingIngredientException("Cannot sell the sandwich due to missing bacon.");
            }

        }
        public void SellHam()
        {
            ham--;
        }
        public void SellMustard()
        {
            mustard--;
        }
        public void SellBBQ()
        {
            BBQ--;
        }
        public void SellCheese()
        {
            cheese--;
        }
        public void SellLettuce()
        {
            lettuce--;
        }
        public void SellMayo()
        {
            mayo--;
        }
        public void SellTomato()
        {
            tomato--;
        }
        public string Report()
        {
            return $"Sales made \n" +
                $"BLT sandwiches: {sandwichStock - BLT}\n" +
                $"PBJ sandwiches: {sandwichStock - PBJ}\n" +
                $"Chicken sandwiches: {sandwichStock - Chicken}\n" +
                $"White bread: {breadStock - white}\n" +
                $"Wheat bread: {breadStock - wheat}\n" +
                $"Rye bread: {breadStock - rye} \n" +
                $"Bacon topping: {toppingStock - bacon}\n" +
                $"Ham topping: {toppingStock - ham}\n" +
                $"Mustard topping: {toppingStock - mustard}\n" +
                $"BBQ topping: {toppingStock - BBQ}\n" +
                $"Cheese topping: {toppingStock - cheese}\n" +
                $"Lettuce topping: {toppingStock - lettuce}\n" +
                $"Mayo topping: {toppingStock - mayo}\n" +
                $"Tomato topping: {toppingStock- tomato}";
        }
        public void ResetStock()
        {
            BLT = sandwichStock;
            PBJ = sandwichStock;
            Chicken = sandwichStock;
            white = breadStock;
            wheat = breadStock;
            rye = breadStock;
            bacon = toppingStock;
            ham = toppingStock;
            mustard = toppingStock;
            BBQ = toppingStock;
            cheese = toppingStock;
            lettuce = toppingStock;
            mayo = toppingStock;
            tomato = toppingStock;
        }
    }
}
