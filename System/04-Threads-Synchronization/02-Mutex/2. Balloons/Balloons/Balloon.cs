using System;
using System.Drawing;
using System.Threading;

namespace Balloons
{
    public class Balloon
    {
        private ManualResetEvent manualResetEvent;
        public Thread Thread { get; set; }
        public Point Point { get; set; }

        public Balloon(ManualResetEvent evt)
        {
            manualResetEvent = evt;
            Thread = new Thread(Run);
            Thread.Start();
        }

        private void Run()
        {
            Point = new Point(new Random().Next(0, Console.WindowWidth), new Random().Next(0, Console.WindowHeight));
            Console.SetCursorPosition(Point.X, Point.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*");
            manualResetEvent.Set();
        }

        public void ChangePosition()
        {
            Console.SetCursorPosition(Point.X, Point.Y);
            Console.WriteLine(" ");
            Point = new Point(new Random().Next(0, Console.WindowWidth), new Random().Next(0, Console.WindowHeight));
            Console.SetCursorPosition(Point.X, Point.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*");
            manualResetEvent.Set();
        }
    }
}
