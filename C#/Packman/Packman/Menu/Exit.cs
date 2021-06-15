using System;
using System.Collections.Generic;

namespace Pacman.Menu
{
    public class Exit : Menu
    {
        public Exit()
        {
            menuList = new List<string>()
            {
                "Yes",
                "No"
            };
        }

        public override void ShowMenu()
        {
            Console.SetCursorPosition(leftIndent, topIndent - 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("     Exit?");
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
                            if (selectedIndex == 1)
                                return;

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.SetCursorPosition(leftIndent, topIndent);
                            Console.WriteLine("Goodbye!");
                            Environment.Exit(0);
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
