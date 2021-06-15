using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Menu
{
    public class AddScores : Menu
    {
        private string message = "Enter your name: ";

        public override void ShowMenu()
        {
            Console.SetCursorPosition(leftIndent, topIndent);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(message);
        }

        public string EnterData()
        {
            Console.SetCursorPosition(leftIndent + message.Length + 1, topIndent);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
            return Console.ReadLine();
        }

        public override void Control()
        {

        }
    }
}
