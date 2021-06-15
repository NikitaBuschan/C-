using System;
using System.Collections.Generic;
using System.Linq;

namespace Pacman.Menu
{
    public class Main : Menu
    {
        public Main()
        {
            menuList = new List<string>()
            {
                "Play",
                "Scores",
                "Exit"
            };
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
                                Game.pacman = new PacmanHero();
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