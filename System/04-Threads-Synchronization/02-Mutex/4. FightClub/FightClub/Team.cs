using System;
using System.Threading;

namespace FightClub
{
    public class Team
    {
        public event EventHandler Lose;
        public Thread Thread { get; set; }
        public string TeamName { get; set; }
        public int Fighters { get; set; } = 0;

        public Team(string teamName)
        {
            TeamName = teamName;
            AddFighters();
            Thread = new Thread(Fight) { IsBackground = false };
        }

        public int AddFighters() =>
            Fighters += new Random().Next(0 , 100);

        public void KillFighters() =>
            Fighters -= new Random().Next(0, 100);

        public void Fight()
        {
            while (Fighters > 0)
            {
                AddFighters();
                Console.WriteLine($"{TeamName} add fighters");
                Thread.Sleep(2000);
                KillFighters();
                Console.WriteLine($"{TeamName} some fighters killed");
            }

            Lose?.Invoke(this, EventArgs.Empty);
        }
    }
}
