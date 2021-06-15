using System;

namespace VinPuhWithBess
{
    class Program
    {
        public static Vinni Vinni { get; set; }
        public static Beeses Beeses { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Vinni portion: ");
            var portion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Vinni eating time: ");
            var eatTime = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Beeses count: ");
            var bessesCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Beeses portion: ");
            var bessesPortion = Convert.ToInt32(Console.ReadLine());

            Vinni = new Vinni(portion, eatTime);
            Beeses = new Beeses(bessesCount, bessesPortion);

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("By!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
