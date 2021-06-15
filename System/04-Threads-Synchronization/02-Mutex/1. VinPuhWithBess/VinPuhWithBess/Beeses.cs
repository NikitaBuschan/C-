using System;
using System.Threading;

namespace VinPuhWithBess
{
    public class Beeses
    {
        private int Portion { get; set; }
        private int Count { get; set; }
        public Thread thread { get; set; }

        public Beeses(int count, int portion)
        {
            Count = count;
            Portion = portion;
            thread = new Thread(new ThreadStart(Eat));
            thread.Start();
        }

        public void Eat()
        {
            while (true)
            {
                Console.WriteLine("Beeses get honey");
                Thread.Sleep(new Random().Next(0, 10000));
            }
        }

        public void GetHoney()
        {
            Console.WriteLine($"Beeses mined {Portion * Count}");
        }
    }
}
