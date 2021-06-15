using System;
using System.Collections.Generic;

namespace Pacman.Menu
{
    public class TryAgain : Menu
    {
        public TryAgain()
        {
            menuList = new List<string>()
            {
                "Yes",
                "No"
            };
        }

        public override void ShowMenu()
        {
            Console.SetCursorPosition(leftIndent, topIndent - 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  Try again?");
            base.ShowMenu();
        }

        public override void Control()
        {
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            if (selectedIndex == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                var game = new Game(new Map());  
                                game.Start();
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                Console.SetCursorPosition(leftIndent, topIndent);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("Goodbye!");
                                Environment.Exit(0);
                            }
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (selectedIndex != 0)
                                RedrowMenuItem(selectedIndex, selectedIndex - 1);
                            else
                                RedrowMenuItem(selectedIndex, menuList.Count - 1);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (selectedIndex == menuList.Count - 1)
                                RedrowMenuItem(selectedIndex, 0);
                            else
                                RedrowMenuItem(selectedIndex, selectedIndex + 1);
                            break;
                        }
                }
            }
        }
    }
}