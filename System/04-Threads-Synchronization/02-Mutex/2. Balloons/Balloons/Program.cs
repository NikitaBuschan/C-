using System;
using System.Collections.Generic;
using System.Threading;

namespace Balloons
{
    public class Program
    {
        private static List<Balloon> Balloons { get; set; } = new List<Balloon>();

        static void Main(string[] args)
        {
            var evtObj = new ManualResetEvent(false);

            Console.Write("Enter count of balloons: ");
            var count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Balloons.Add(new Balloon(evtObj));
                evtObj.WaitOne();
                evtObj.Reset();
            }

            while (true)
            {
                Console.SetCursorPosition(0,0);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("                                               ");
                Console.SetCursorPosition(0, 0);
                Console.Write("Enter the number of changed balloons: ");

                count = Convert.ToInt32(Console.ReadLine());
                count = (count > Balloons.Count) ? Balloons.Count : count;

                for (int i = 0; i < count; i++)
                {
                    Balloons[i].ChangePosition();
                    evtObj.WaitOne();
                    evtObj.Reset();
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("By!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
