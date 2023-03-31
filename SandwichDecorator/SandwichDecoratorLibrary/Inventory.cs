﻿using System;
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
        int toppingStock = 4000;

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

        public void SellBLT(Bread bread)
        {
            BLT--;
            if (bread == Bread.rye ) { rye = rye - 2; }
            else if (bread == Bread.wheat) { wheat = wheat - 2; }
            else{ white = white - 2; }
        }
        public void SellPBJ(Bread bread)
        {
            PBJ--;
            if (bread == Bread.rye) { rye = rye - 2; }
            else if (bread == Bread.wheat) { wheat = wheat - 2; }
            else { white = white - 2; }
        }
        public void SellChicken(Bread bread)
        {
            Chicken--;
            if (bread == Bread.rye) { rye = rye - 2; }
            else if (bread == Bread.wheat) { wheat = wheat - 2; }
            else { white = white - 2; }
        }
        public void SellBacon()
        {
            bacon--;
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
                $"BLT sandwiches {sandwichStock - BLT}\n" +
                $"PBJ sandwiches {sandwichStock - PBJ}\n" +
                $"Chicken sandwiches {sandwichStock - Chicken}\n" +
                $"White bread {breadStock - white}\n" +
                $"Wheat bread {breadStock - wheat}\n" +
                $"Rye bread {breadStock - rye} \n" +
                $"Bacon topping {toppingStock - bacon}\n" +
                $"Ham topping {toppingStock - ham}\n" +
                $"Mustard topping {toppingStock - mustard}\n" +
                $"BBQ topping {toppingStock - BBQ}\n" +
                $"Cheese topping {toppingStock - cheese}\n" +
                $"Lettuce topping {toppingStock - lettuce}\n" +
                $"Mayo topping {toppingStock - mayo}\n" +
                $"Tomato topping {toppingStock- tomato}";

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