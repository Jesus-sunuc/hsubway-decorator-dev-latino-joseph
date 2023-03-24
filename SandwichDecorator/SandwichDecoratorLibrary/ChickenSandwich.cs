using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichDecoratorLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            ISandwich sandwich = new Sandwich();
            ISandwich extraOnion = new OnionDecorator(sandwich);
            ISandwich extraTomatoes = new TomatoesDecorator(extraOnion);
            Console.WriteLine(extraTomatoes.GetSandwichType());
        }

        // base interface
        interface ISandwich
        {
            string GetSandwichType();
        }

        // concrete implementation
        class Sandwich : ISandwich
        {
            public string GetSandwichType()
            {
                return "This is a normal sandwich";
            }
        }

        // base decorator
        class SandwichDecorator : ISandwich
        {
            private ISandwich Sandwich;

            public SandwichDecorator(ISandwich sandwich)
            {
                Sandwich = sandwich;
            }
            public virtual string GetSandwichType()
            {

                return Sandwich.GetSandwichType();
            }
        }

        // Concrete decorators
        class OnionDecorator : SandwichDecorator
        {
            public OnionDecorator(ISandwich sandwich) : base(sandwich) { }

            public override string GetSandwichType()
            {
                string type = base.GetSandwichType();
                type += "\r\nwith extra onions";
                return type;
            }
        }

        class TomatoesDecorator : SandwichDecorator
        {
            public TomatoesDecorator(ISandwich sandwich) : base(sandwich) { }

            public override string GetSandwichType()
            {
                string type = base.GetSandwichType();
                type += "\r\nwith extra tomatoes";
                return type;
            }
        }
    }
}
