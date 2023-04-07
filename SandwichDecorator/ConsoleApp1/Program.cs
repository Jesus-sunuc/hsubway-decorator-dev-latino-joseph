using SandwichDecoratorLibrary;
using System.Diagnostics;
using System.Threading;

public class Program
{
    static void Main()
    {
        Console.Clear();

        //Create inventory and list of sold sandwiches
        Inventory inventory;
        List<string> soldSandwiches = new List<string>();

        //restuarantrunnning means the console app hasn't ended, dailyrunning means the current day hasn't ended
        bool restaurantRunning = true;
        bool dayIsRunning = true;

        //List that contains the reports of each day, and therefore, the number of days that the restaurant has been running
        List<string> dailyReports = new List<string>();

        while (restaurantRunning)
        {
            //Reset the inventory's stock
            inventory = new Inventory();
            soldSandwiches = new List<string>();
            dayIsRunning = true;

            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine($"| DAY {dailyReports.Count + 1} HAS BEGUN! |");
            Console.WriteLine("--------------------");

            while (dayIsRunning)
            {
                if (inventory.IsEmpty())
                {
                    Console.Clear();
                    Console.WriteLine("SORRY, WE'RE OUT OF STOCK!");
                    break;
                }

                Console.WriteLine("\n" + inventory.Report());

                Console.WriteLine("\n" + "To begin sandwich creation, press any key ...");

                Console.ReadKey(true);

                Sandwichmaker(inventory, soldSandwiches);

                Console.WriteLine("If you wish to make another sandwich, press the 'S' key, otherwise, if you're done for the day, press any other key...");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.S:
                        continue;

                    default: break;
                }

                //Adds the report for the day in the list

                string completeReport = inventory.Report() + "\n" + "\n" + "Sandwiches made today:";

                foreach (string sandwich in soldSandwiches)
                {
                    completeReport += "\n" + $"{sandwich}";
                }

                dailyReports.Add(completeReport);


                Console.WriteLine($"Press any key to go to day {dailyReports.Count + 1}, else, if you wish to exit, press 'E' ");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.E:
                        restaurantRunning = false;
                        dayIsRunning = false;
                        break;

                    default:
                        restaurantRunning = true;
                        dayIsRunning = false;
                        break;
                }

            }

        }

        Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"| F I N A L   R E P O R T S |");
            Console.WriteLine("-----------------------------");

        Console.WriteLine("The reports for each day are:");

        for (int i = 0; i < dailyReports.Count; i++)
        {
            Console.WriteLine();
            Console.WriteLine("-------------");
            Console.WriteLine($"| D A Y : {i + 1} |");
            Console.WriteLine("-------------");
            Console.WriteLine(dailyReports[i]);
        }
    }

    //METHOD TO PRODUCE A SINGLE SANDWICH

    static void Sandwichmaker(Inventory newInventory, List<string> soldSasndwiches)
    {
        Console.Clear();

        Console.WriteLine("Welcome to the subway sandwich producer!");

        //USER SELECTS TYPE OF BREAD

        Bread userBread = BreadChooser();

        //USER SELECTS TYPE OF SANDWICH

        Object userSandwich;

        Console.WriteLine(@"
What type of sandwich do you wish to order?

Press the '1' key for a BLT Sandwich
Press the '2  key for a Chicken Sandwich
Press the '3' key for a PBJ Sandwich

If you don't select one of these options, your sandwich will be a Chicken Sandwich

");

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                userSandwich = new BLTSandwich(userBread);
                try
                {

                    newInventory.SellBLT(userBread);
                }

                catch (Exception ex) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message); 
                    };

                break;

            case ConsoleKey.D2:
                userSandwich = new ChickenSandwich(userBread);
                try
                {

                    newInventory.SellChicken(userBread);
                }

                catch (Exception ex) { Console.WriteLine(ex.Message); };
                break;

            case ConsoleKey.D3:
                userSandwich = new PBJSandwich(userBread);
                try
                {

                    newInventory.SellPBJ(userBread);
                }

                catch (Exception ex) { Console.WriteLine(ex.Message); };

                break;

            default:
                userSandwich = new ChickenSandwich(userBread); newInventory.SellChicken(userBread); break;
        }

        Console.WriteLine();
        Console.WriteLine($"You have ordered a {((ISandwich)userSandwich).GetDescription()}!");
        Console.WriteLine($"Your current sandwich has a price of {((ISandwich)userSandwich).GetPrice()}!");


        //USER SELECTS TOPPINGS

        bool finalDescionMade = false;

        while (!finalDescionMade)
        {

            Console.WriteLine(@"
Would you like to order addittional toppings?

Press the '1' key if you would like to order additional topics

Else, press any other key to get your final sandwich description and price ...
");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    userSandwich = ToppingChooser(userSandwich, newInventory);
                    if (newInventory.IsEmpty())
                    {
                        Console.Clear();
                        Console.WriteLine("SORRY, WE'RE OUT OF STOCK!");
                        finalDescionMade = true;
                        break;
                    }
                    break;

                default:
                    finalDescionMade = true; break;
            }
        }

        var Tuple = GetFinalPriceAndDescription(userSandwich);
        soldSasndwiches.Add(Tuple.Item2);

        Console.Clear();
         Console.WriteLine("-------------------------------");
            Console.WriteLine($"| F I N A L   S A N D W I C H |");
            Console.WriteLine("-------------------------------");
        Console.WriteLine($"You ordered a: {Tuple.Item2}");
        Console.WriteLine($"Your sandwich's final price is: {Tuple.Item1}");
        Console.WriteLine();

    }


    //METHOD TO CHOOSE A BREAD TYPE FOR THE SANDWICH
    static Bread BreadChooser()
    {
        Console.Clear();
        var bread = new Bread();
        Console.WriteLine(@"
What type of Bread would you like with you order?

Press the '1' key for White bread, White bread sandwich starts at $2.00.
Press the '2  key for Wheat bread, Wheat bread costs $0.25 extra.
Press the '3' key for Rye bread, Rye bread costs $0.50 extra.

If you don't select one of these options, your sandwich will have White bread
");
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                bread = Bread.white; break;

            case ConsoleKey.D2:
                bread = Bread.wheat; break;

            case ConsoleKey.D3:
                bread = Bread.rye; break;

            default:
                bread = Bread.white; break;
        }

        return bread;
    }


    //METHOD TO CHOOSE TOPPINGS FOR YOUR SANDWICH

    static ITopping ToppingChooser(Object sanwichOrTopping, Inventory availableGoods)
    {
        ITopping Topping;

        var priceAndDescription = GetFinalPriceAndDescription(sanwichOrTopping);

        Console.Clear();

        Console.WriteLine(@$"
Your sandwich currently is: {priceAndDescription.Item2}
And has a cost: {priceAndDescription.Item1}

What Topping do you wish to order?

There are extra-cost toppings:

Press the '1' key for Bacon, Bacon costs $0.75 per serving.
Press the '2  key for Ham, Ham costs $0.60 per serving.
Press the '3' key for Cheese, Cheese costs $0.75 per serving.
Press the '4  key for Tomato, Tomato costs $0.25 each.
Press the '5' key for Lettuce, Lettuce costs $0.25 each.

And free toppings:
Press the '6' key for Mayo.
Press the '7  key for BBQ Sauce.
Press the '8' key for Mustard.

If you don't select one of these options, your sandwich will have Mayo
");

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Bacon((ITopping)sanwichOrTopping);
                    availableGoods.SellBacon();
                }
                else
                {
                    Topping = new Bacon((ISandwich)sanwichOrTopping);
                    availableGoods.SellBacon();
                }
                break;

            case ConsoleKey.D2:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Ham((ITopping)sanwichOrTopping);
                    availableGoods.SellHam();
                }
                else
                {
                    Topping = new Ham((ISandwich)sanwichOrTopping);
                    availableGoods.SellHam();
                }
                break;

            case ConsoleKey.D3:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Cheese((ITopping)sanwichOrTopping);
                    availableGoods.SellCheese();
                }
                else
                {
                    Topping = new Cheese((ISandwich)sanwichOrTopping);
                    availableGoods.SellCheese();
                }
                break;

            case ConsoleKey.D4:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Tomato((ITopping)sanwichOrTopping);
                    availableGoods.SellTomato();
                }
                else
                {
                    Topping = new Tomato((ISandwich)sanwichOrTopping);
                    availableGoods.SellTomato();
                }
                break;

            case ConsoleKey.D5:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Lettuce((ITopping)sanwichOrTopping);
                    availableGoods.SellLettuce();
                }
                else
                {
                    Topping = new Lettuce((ISandwich)sanwichOrTopping);
                    availableGoods.SellLettuce();
                }
                break;

            case ConsoleKey.D6:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Mayo((ITopping)sanwichOrTopping);
                    availableGoods.SellMayo();
                }
                else
                {
                    Topping = new Mayo((ISandwich)sanwichOrTopping);
                    availableGoods.SellMayo();
                }
                break;

            case ConsoleKey.D7:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new BBQ((ITopping)sanwichOrTopping);
                    availableGoods.SellBBQ();
                }
                else
                {
                    Topping = new BBQ((ISandwich)sanwichOrTopping);
                    availableGoods.SellBBQ();
                }
                break;
            case ConsoleKey.D8:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Mustard((ITopping)sanwichOrTopping);
                    availableGoods.SellMustard();
                }
                else
                {
                    Topping = new Mustard((ISandwich)sanwichOrTopping);
                    availableGoods.SellMustard();
                }
                break;

            default:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Mayo((ITopping)sanwichOrTopping);
                    availableGoods.SellMayo();
                }
                else
                {
                    Topping = new Mayo((ISandwich)sanwichOrTopping);
                    availableGoods.SellMayo();

                }
                break;
        }

        return Topping;

    }

    //METHOD TO GET FINAL PRICE OF SANDWICH AND FULL DESCRIPTION RECURSIVELY

    static (decimal, string) GetFinalPriceAndDescription(object sandwich)
    {
        decimal finalPrice = 0;
        string finalDescription = "";
        if (sandwich is ISandwich sandwichObj)
        {
            finalPrice = sandwichObj.GetPrice();
            finalDescription = sandwichObj.GetDescription();
            Debug.WriteLine($"ISandwich: finalPrice={finalPrice}, finalDescription={finalDescription}");
        }
        if (sandwich is ITopping toppingObj)
        {
            if (toppingObj.Sandwich != null)
            {
                var tuple = GetFinalPriceAndDescription(toppingObj.Sandwich);
                finalPrice = tuple.Item1 + toppingObj.GetPrice();
                finalDescription = tuple.Item2 + " " + toppingObj.GetDescription();
                Debug.WriteLine($"ITopping Sandwich: finalPrice={finalPrice}, finalDescription={finalDescription}");
            }
            else if (toppingObj.Topping != null)
            {
                var tuple = GetFinalPriceAndDescription(toppingObj.Topping);
                finalPrice = tuple.Item1 + toppingObj.GetPrice();
                finalDescription = tuple.Item2 + " " + toppingObj.GetDescription();
                Debug.WriteLine($"ITopping Topping: finalPrice={finalPrice}, finalDescription={finalDescription}");
            }
        }
        return (finalPrice, finalDescription);
    }
}
