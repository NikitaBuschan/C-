using System;
using System.Threading;

namespace VinPuhWithBess
{
    public class Vinni
    {
        private int Portion { get; set; }
        private int EatTime { get; set; }
        private int NoEat { get; set; }
        public Thread EatThread { get; set; }
        public Thread EnterDataThread { get; set; }
        public Thread DiedThread { get; set; }
        private bool isEat { get; set; } = false;

        public Vinni(int portion, int eatTime)
        {
            Portion = portion;
            EatTime = eatTime;
            NoEat = EatTime;
            EatThread = new Thread(new ThreadStart(Eat));
            EatThread.Start();
        }

        public void Eat()
        {
            Resources.VinniMutex.WaitOne();
            Console.WriteLine("Vinni start eating");
            for (int i = 0; i < EatTime; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Vinni is eating");
            }
            Console.WriteLine($"\nVinni finish eating, he ate {Portion * EatTime}\n");
            DiedThread = new Thread(new ThreadStart(Died));
            DiedThread.Start();
            Resources.VinniMutex.ReleaseMutex();
        }

        public void Died()
        {
            Resources.VinniMutex.WaitOne();
            EnterDataThread = new Thread(new ThreadStart(EatingTime));
            EnterDataThread.Start();
            Console.WriteLine($"Feed Vinni, he will die through {NoEat} seconds");
            for (int i = NoEat; i > 0; i--)
            {
                Thread.Sleep(1000);
                if (isEat)
                {
                    isEat = false;
                    Resources.VinniMutex.ReleaseMutex();
                    return;
                }
            }
            Console.WriteLine("Vinni Die! Now everyone is sad");
            Program.Beeses.GetHoney();
            Resources.VinniMutex.ReleaseMutex();
            Environment.Exit(0);
        }

        public void EatingTime()
        {
            Console.WriteLine("Enter Vinni eating time: \n");
            EatTime = Convert.ToInt32(Console.ReadLine());
            NoEat = EatTime;
            isEat = true;
            Thread.Sleep(1000);
            EatThread = new Thread(new ThreadStart(Eat));
            EatThread.Start();
        }
    }
}
