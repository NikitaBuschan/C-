using System;
using System.Collections.Generic;

namespace Pacman.Menu
{
    public abstract class Menu
    {
        protected int topIndent = 10;
        protected int leftIndent = 23;
        protected int selectedIndex = 0;
        protected int width = 15;

        protected List<string> menuList;

        public virtual void ShowMenu()
        {
            for (int i = 0; i < menuList.Count; i++)
            {
                int side = (width - menuList[i].Length) / 2;

                Console.SetCursorPosition(leftIndent, i + topIndent);

                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                for (int j = 0; j < side; j++)
                    Console.Write(' ');
                Console.Write(menuList[i]);
                for (int j = 0; j < width - side - menuList[i].Length; j++)
                    Console.Write(' ');

                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 25);
        }

        protected virtual void RedrowMenuItem(int selectedIndex, int newSelectedIndex)
        {
            Console.SetCursorPosition(leftIndent, selectedIndex + topIndent);
            int side = (width - menuList[selectedIndex].Length) / 2;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            for (int j = 0; j < side; j++)
                Console.Write(' ');
            Console.Write(menuList[selectedIndex]);
            for (int j = 0; j < width - side - menuList[selectedIndex].Length; j++)
                Console.Write(' ');

            Console.SetCursorPosition(leftIndent, newSelectedIndex + topIndent);
            side = (width - menuList[newSelectedIndex].Length) / 2;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int j = 0; j < side; j++)
                Console.Write(' ');
            Console.Write(menuList[newSelectedIndex]);
            for (int j = 0; j < width - side - menuList[newSelectedIndex].Length; j++)
                Console.Write(' ');

            this.selectedIndex = newSelectedIndex;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 25);

        }

        public abstract void Control();
    }
}
