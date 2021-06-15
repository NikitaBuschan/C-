using System;
using System.Collections.Generic;

namespace Pacman.Menu
{
    public class Pause : Menu
    {
        public Pause()
        {
            menuList = new List<string>()
            {
                "Play again",
                "Scores",
                "Exit"
            };
        }

        public override void ShowMenu()
        {
            Console.SetCursorPosition(leftIndent, topIndent - 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  Game pause");
            base.ShowMenu();
        }

        public override void Control()
        {
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            return;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (selectedIndex == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                var game = new Game(new Map());
                                game.Start();
                            }
                            else if (selectedIndex == 1)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                var scores = new Scores();
                                scores.Draw();
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ReadKey();
                                Console.Clear();
                                ShowMenu();
                            }
                            else if (selectedIndex == menuList.Count - 1)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                var exit = new Exit();
                                exit.ShowMenu();
                                exit.Control();
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                ShowMenu();
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
