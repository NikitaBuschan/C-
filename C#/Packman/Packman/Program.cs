using Pacman.Menu;
using System;

namespace Pacman
{
    public class Program
    {
        public static Main menu = new Main();

        static void Main(string[] args)
        {
            Console.SetWindowSize(60, 37);
            Console.SetBufferSize(60, 37);

            Console.CursorVisible = false;
            menu.ShowMenu();

            while (true)
            {
                menu.Control();
            }
        }
    }
}