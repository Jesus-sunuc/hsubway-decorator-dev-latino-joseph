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

                Console.WriteLine("\n" + inventory.Report());

                Console.WriteLine("\n" + "To begin sandwich creation, press any key ...");

                Console.ReadKey(true);

                Console.Clear();

                Console.WriteLine("If you wish to generate a random sandwich press 'R', else, if you wish to create your own, press any other key...");

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.R:
                        RandomSandwichmaker(inventory, soldSandwiches);
                        break;

                    default:
                        Sandwichmaker(inventory, soldSandwiches);
                        break;

                }

                if (inventory.IsEmpty())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SORRY, WE'RE OUT OF STOCK, WE'RE DONE FOR THE DAY!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("If you wish to make another sandwich, press the 'S' key, otherwise, if you're done for the day, press any other key...");

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.S:
                            continue;

                        default: break;
                    }
                }


                //Adds the report for the day in the list

                string completeReport = inventory.Report() + "\n" + "\n" + "Sandwiches made today:";

                foreach (string sandwich in soldSandwiches)
                {
                    completeReport += "\n" + $"-{sandwich}";
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

    //METHOD TO PRODUCE A SINGLE SANDWICH.

    static void Sandwichmaker(Inventory newInventory, List<string> soldSasndwiches)
    {
        Console.Clear();

        Console.WriteLine("Welcome to the subway sandwich producer!");

        //USER SELECTS TYPE OF BREAD

        Bread userBread = BreadChooser();

        //USER SELECTS TYPE OF SANDWICH

        Object userSandwich = default;

        Console.WriteLine(@"
What type of sandwich do you wish to order?

Press the '1' key for a BLT Sandwich
Press the '2  key for a Chicken Sandwich
Press the '3' key for a PBJ Sandwich

If you don't select one of these options, your sandwich will be a Chicken Sandwich

");
        //TRY CATCH BLOCK IN CASE THERE'S LACK OF AN INGREDIENT
        try
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    newInventory.SellBLT(userBread);
                    userSandwich = new BLTSandwich(userBread);
                    break;

                case ConsoleKey.D2:
                    newInventory.SellChicken(userBread);
                    userSandwich = new ChickenSandwich(userBread);
                    break;

                case ConsoleKey.D3:
                    newInventory.SellPBJ(userBread);
                    userSandwich = new PBJSandwich(userBread);
                    break;

                default:
                    userSandwich = new ChickenSandwich(userBread); newInventory.SellChicken(userBread); break;
            }
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(3000);
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"You have ordered a: {((ISandwich)userSandwich).GetDescription()}!");
        Console.WriteLine($"Your current sandwich has a price of: ${((ISandwich)userSandwich).GetPrice()}");


        //USER SELECTS TOPPINGS

        bool finalDescionMade = false;

        try
        {

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
                        break;

                    default:
                        finalDescionMade = true; break;
                }
            }
        }
        catch (Exception e)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("If you still wish to purchase your current sandwich without any additional toppings, press 'P', else, press any key..");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.P:
                    break;

                default:
                    return;
            }
        }

        var Tuple = GetFinalPriceAndDescription(userSandwich);
        soldSasndwiches.Add(Tuple.Item2);
        newInventory.AddRevenue(Tuple.Item1);

        Console.Clear();
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"| F I N A L   S A N D W I C H |");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"You ordered a: {Tuple.Item2}");
        Console.WriteLine($"Your sandwich's final price is: ${Tuple.Item1}");
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
                    availableGoods.SellBacon();
                    Topping = new Bacon((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellBacon();
                    Topping = new Bacon((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D2:
                if (sanwichOrTopping is ITopping)
                {
                    availableGoods.SellHam();
                    Topping = new Ham((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellHam();
                    Topping = new Ham((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D3:
                if (sanwichOrTopping is ITopping)
                {
                    availableGoods.SellCheese();
                    Topping = new Cheese((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellCheese();
                    Topping = new Cheese((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D4:
                if (sanwichOrTopping is ITopping)
                {
                    availableGoods.SellTomato();
                    Topping = new Tomato((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellTomato();
                    Topping = new Tomato((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D5:
                if (sanwichOrTopping is ITopping)
                {
                    availableGoods.SellLettuce();
                    Topping = new Lettuce((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellLettuce();
                    Topping = new Lettuce((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D6:
                if (sanwichOrTopping is ITopping)
                {
                    availableGoods.SellMayo();
                    Topping = new Mayo((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellMayo();
                    Topping = new Mayo((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D7:
                if (sanwichOrTopping is ITopping)
                {
                    availableGoods.SellBBQ();
                    Topping = new BBQ((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellBBQ();
                    Topping = new BBQ((ISandwich)sanwichOrTopping);
                }
                break;
            case ConsoleKey.D8:
                if (sanwichOrTopping is ITopping)
                {
                    availableGoods.SellMustard();
                    Topping = new Mustard((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellMustard();
                    Topping = new Mustard((ISandwich)sanwichOrTopping);
                }
                break;

            default:
                if (sanwichOrTopping is ITopping)
                {
                    availableGoods.SellMayo();
                    Topping = new Mayo((ITopping)sanwichOrTopping);
                }
                else
                {
                    availableGoods.SellMayo();
                    Topping = new Mayo((ISandwich)sanwichOrTopping);

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

    //METHOD TO MAKE A RANDOM SANDWICH EASILY

    static void RandomSandwichmaker(Inventory newInventory, List<string> soldSasndwiches)
    {
        Random num = new Random();

        Bread randomBread = new Bread();

        Object randomSandwich = default;

        (decimal, string) Tuple = default;

        try
        {

            switch (num.Next(0, 3))
            {
                case 0:
                    randomBread = Bread.white; break;

                case 1:
                    randomBread = Bread.wheat; break;

                case 2:
                    randomBread = Bread.rye; break;
            }

            switch (num.Next(0, 3))
            {
                case 0:
                    newInventory.SellBLT(randomBread);
                    randomSandwich = new BLTSandwich(randomBread);
                    break;

                case 1:
                    newInventory.SellChicken(randomBread);
                    randomSandwich = new ChickenSandwich(randomBread);
                    break;

                case 2:
                    newInventory.SellPBJ(randomBread);
                    randomSandwich = new PBJSandwich(randomBread);

                    break;
            }

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(3000);
            return;
        }

        try
        {

            int max = num.Next(0, 11);
            for (int i = 0; i < max; i++)
            {
                switch (num.Next(0, 8))
                {
                    case 0:
                        if (randomSandwich is ITopping)
                        {
                            newInventory.SellBacon();
                            randomSandwich = new Bacon((ITopping)randomSandwich);
                        }
                        else
                        {
                            newInventory.SellBacon();
                            randomSandwich = new Bacon((ISandwich)randomSandwich);
                        }
                        break;

                    case 1:
                        if (randomSandwich is ITopping)
                        {
                            newInventory.SellHam();
                            randomSandwich = new Ham((ITopping)randomSandwich);
                        }
                        else
                        {
                            newInventory.SellHam();
                            randomSandwich = new Ham((ISandwich)randomSandwich);
                        }
                        break;

                    case 2:
                        if (randomSandwich is ITopping)
                        {
                            newInventory.SellCheese();
                            randomSandwich = new Cheese((ITopping)randomSandwich);
                        }
                        else
                        {
                            newInventory.SellCheese();
                            randomSandwich = new Cheese((ISandwich)randomSandwich);
                        }
                        break;

                    case 3:
                        if (randomSandwich is ITopping)
                        {
                            newInventory.SellTomato();
                            randomSandwich = new Tomato((ITopping)randomSandwich);
                        }
                        else
                        {
                            newInventory.SellTomato();
                            randomSandwich = new Tomato((ISandwich)randomSandwich);
                        }
                        break;

                    case 4:
                        if (randomSandwich is ITopping)
                        {
                            newInventory.SellLettuce();
                            randomSandwich = new Lettuce((ITopping)randomSandwich);
                        }
                        else
                        {
                            newInventory.SellLettuce();
                            randomSandwich = new Lettuce((ISandwich)randomSandwich);
                        }
                        break;

                    case 5:
                        if (randomSandwich is ITopping)
                        {
                            newInventory.SellMayo();
                            randomSandwich = new Mayo((ITopping)randomSandwich);
                        }
                        else
                        {
                            newInventory.SellMayo();
                            randomSandwich = new Mayo((ISandwich)randomSandwich);
                        }
                        break;

                    case 6:
                        if (randomSandwich is ITopping)
                        {
                            newInventory.SellBBQ();
                            randomSandwich = new BBQ((ITopping)randomSandwich);
                        }
                        else
                        {
                            newInventory.SellBBQ();
                            randomSandwich = new BBQ((ISandwich)randomSandwich);
                        }
                        break;
                    case 7:
                        if (randomSandwich is ITopping)
                        {
                            newInventory.SellMustard();
                            randomSandwich = new Mustard((ITopping)randomSandwich);
                        }
                        else
                        {
                            newInventory.SellMustard();
                            randomSandwich = new Mustard((ISandwich)randomSandwich);
                        }
                        break;
                }

            }
        }
        catch (Exception e) //IF A RANDOM SANDWICH IS CREATED, AND THERE'S NO TOPPINGS, IT WILL STILL RETURN THE TOPPING-LESS SANDWICH
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(3000);

            Tuple = GetFinalPriceAndDescription(randomSandwich);
            soldSasndwiches.Add(Tuple.Item2);
            newInventory.AddRevenue(Tuple.Item1);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"| F I N A L   S A N D W I C H |");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"You ordered a: {Tuple.Item2}");
            Console.WriteLine($"Your sandwich's final price is: ${Tuple.Item1}");
            Console.WriteLine();
            return;
        }

        Tuple = GetFinalPriceAndDescription(randomSandwich);
        soldSasndwiches.Add(Tuple.Item2);
        newInventory.AddRevenue(Tuple.Item1);

        Console.Clear();
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"| F I N A L   S A N D W I C H |");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"You ordered a: {Tuple.Item2}");
        Console.WriteLine($"Your sandwich's final price is: ${Tuple.Item1}");
        Console.WriteLine();

    }


}