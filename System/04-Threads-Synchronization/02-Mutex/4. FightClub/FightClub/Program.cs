using System;

namespace FightClub
{
    class Program
    {
        private static Team TeamOne { get; set; }
        private static Team TeamTwo { get; set; }

        static void Main(string[] args)
        {
            TeamOne = new Team("#1");
            TeamTwo = new Team("#2");

            Console.ReadKey();

            TeamOne.Thread.Start();
            TeamTwo.Thread.Start();

            TeamOne.Lose += Team_Lose;
            TeamTwo.Lose += Team_Lose;
        }

        private static void Team_Lose(object sender, EventArgs e)
        {
            if (TeamOne.Fighters <= 0)
            {
                Console.WriteLine($"{TeamTwo.TeamName} is Win");
                Environment.Exit(0);
            }
            else if (TeamTwo.Fighters <= 0)
            {
                Console.WriteLine($"{TeamTwo.TeamName} is Win");
                Environment.Exit(0);
            }
        }
    }
}
