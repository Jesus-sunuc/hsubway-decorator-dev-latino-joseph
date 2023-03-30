using SandwichDecoratorLibrary;
using System.Threading;

public class Program 
{ 
    static void Main()
    {
        Console.Clear();

        ISandwich userSandwich;

        Console.WriteLine("Welcome to the subway sandwich producer!");

        Console.WriteLine(@"
What type of sandwich do you wish to order?

Press the '1' key for a BLT Sandwich
Press the '2 key for a Chicken Sandwich
Press the '3' key for a PBJ Sandwich

If you don't select one of these options, your sandwich will be a Chicken Sandwich

");

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                userSandwich = new BLTSandwich(BreadChooser()); break;

            case ConsoleKey.D2:
                userSandwich = new ChickenSandwich(BreadChooser()); break;

            case ConsoleKey.D3:
                userSandwich = new PBJSandwich(BreadChooser()); break;

            default:
                userSandwich = new ChickenSandwich(BreadChooser()); break;
        }

        Console.WriteLine($"You have order a {userSandwich.GetDescription()}!");
        Console.WriteLine($"Your current sandwich has a price of {userSandwich.GetPrice()}!");

        bool finalDescionMade = false;

        while(!finalDescionMade)
        {
            Console.WriteLine(@"
Would you like to order addittional toppings?

Press the '1' key if you would like to order additional topics

Else, press any other key to get your final sandwich description and price ...
");

            switch (Console.ReadKey(true).Key)
            { 
                case ConsoleKey.D1:
                    ToppingChooser(userSandwich); break;

                default:
                    finalDescionMade=true; break;      
            }
        }
    }




    static Bread BreadChooser()
    {
        var bread = new Bread();
        Console.WriteLine(@"
What type of Bread would you like with you order?

Press the '1' key for White bread, White bread sandwich starts at $2.00.
Press the '2 key for Wheat bread, Wheat bread costs $0.25 extra.
Press the '3' key for Rye bread, Rye bread costs $0.50 extra.

If you don't select one of these options, your sandwich will have White bread
");
        switch(Console.ReadKey(true).Key)
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





    static ITopping ToppingChooser(Object sanwichOrTopping) 
    {
        ITopping Topping;

        Console.WriteLine(@"
What Topping do you wish to order?

There are extra-cost toppings:

Press the '1' key for Bacon, Bacon costs $0.75 per serving.
Press the '2 key for Ham, Bacon costs $0.75 per serving.
Press the '3' key for Cheese, Cheese costs $0.75 per serving.
Press the '4 key for Tomato, Tomato costs $0.25 each.
Press the '5' key for Lettuce, Lettuce costs $0.25 each.

And free toppings:
Press the '6' key for Mayo.
Press the '7 key for BBQ Sauce.
Press the '8' key for Mustard.

If you don't select one of these options, your sandwich will have Mayo
");

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                if(sanwichOrTopping is ITopping)
                {
                    Topping = new Bacon((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new Bacon((ISandwich)sanwichOrTopping);
                }          
                break;

            case ConsoleKey.D2:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Ham((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new Ham((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D3:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Cheese((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new Cheese((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D4:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Tomato((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new Tomato((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D5:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Lettuce((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new Lettuce((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D6:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Mayo((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new Mayo((ISandwich)sanwichOrTopping);
                }
                break;

            case ConsoleKey.D7:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new BBQ((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new BBQ((ISandwich)sanwichOrTopping);
                }
                break;
            case ConsoleKey.D8:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Mustard((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new Mustard((ISandwich)sanwichOrTopping);
                }
                break;

            default:
                if (sanwichOrTopping is ITopping)
                {
                    Topping = new Mayo((ITopping)sanwichOrTopping);
                }
                else
                {
                    Topping = new Mayo((ISandwich)sanwichOrTopping);
                }
                break;
        }

        return Topping;

    }
}
