using SandwichDecoratorLibrary;
using System.Threading;

public class Program
{
    static void Main()
    {
        Console.Clear();

        //Create inventory and reset its stock
        Inventory inventory = new Inventory();

        bool restaurantRunning = true;

        while (restaurantRunning)
        {
            if (inventory.IsEmpty())
            {
                Console.Clear();
                Console.WriteLine("SORRY, WE'RE OUT OF STOCK!");
                break;
            }

            Console.WriteLine(inventory.Report());

            Console.WriteLine("To begin sandwich creation, press any key ...");

            Console.ReadKey(true);

            Sandwichmaker(inventory);

            Console.WriteLine("If you wish to make another sandwich, press the 'S' key, otherwise, if you wish to exit, press ay other key...");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.S:
                    restaurantRunning = true;
                    break;

                default: restaurantRunning = false; break;
            }
        }

        Console.WriteLine(inventory.Report());
    }

    //METHOD TO PRODUCE A SINGLE SANDWICH

    static void Sandwichmaker(Inventory newInventory)
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
                userSandwich = new BLTSandwich(userBread); newInventory.SellBLT(userBread); break;

            case ConsoleKey.D2:
                userSandwich = new ChickenSandwich(userBread); newInventory.SellChicken(userBread); break;

            case ConsoleKey.D3:
                userSandwich = new PBJSandwich(userBread); newInventory.SellPBJ(userBread); break;

            default:
                userSandwich = new ChickenSandwich(userBread); newInventory.SellChicken(userBread); break;
        }

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

        Console.Clear();
        Console.WriteLine($"You ordered a {Tuple.Item2}");
        Console.WriteLine($"Your sandwich's final price is {Tuple.Item1}");

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
}
