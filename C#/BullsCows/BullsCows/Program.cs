using System;

namespace BullsCows
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number();
            number.Generate();

            Insert game = new Insert();
            while (true)
            {
                game.UserSet();
                game.Check(number);
                game.Print();
                if (game.Win())
                {
                    Console.WriteLine();
                    Console.WriteLine("Try again? Y / N");

                    var temp = Console.ReadLine();
                    if (temp == "Y" || temp == "y")
                        continue;
                    else if (temp == "N" || temp == "n")
                    {
                        Console.WriteLine("Goodbye =)");
                        break;
                    }
                }
            }
        }
    }
}