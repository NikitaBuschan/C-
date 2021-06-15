using System;
using System.Timers;
using Pacman.Shadows;

namespace Pacman
{
    public class Timers
    {
        public static System.Timers.Timer aTimer = null;
        public static System.Timers.Timer aTimerScared = null;

        public static void SetTimerOutShadows()
        {
            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += OutShadows;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public static void SetFrightTimer()
        {
            aTimerScared = new System.Timers.Timer(10000);
            aTimerScared.Elapsed += StopFrightTimer;
            aTimerScared.AutoReset = true;
            aTimerScared.Enabled = true;

            foreach (var item in Game.ghosts)
                item.Sprite = new Sprite(ConsoleColor.Blue, "%");
        }

        public static void OutShadows(Object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < Game.ghosts.Count; i++)
            {
                if (Game.ghosts[i].Coord == Game.startGhostPosition[i])
                {
                    Game.ghosts[i].Exit();
                    Game.exit += Game.ghosts[i].Exit;
                    return;
                }
            }
            Game.exit = null;
            StopTimer(aTimer);
        }

        public static void StopTimer(System.Timers.Timer timer)
        {
            timer.Stop();
            timer.Dispose();
        }

        public static void StopFrightTimer(Object source, ElapsedEventArgs e)
        {
            Game.fright = false;
            foreach (var item in Game.ghosts)
            {
                if (item is RedShadow)
                    item.Sprite = new Sprite(ConsoleColor.Red, "%");
                else if (item is BlueShadow)
                    item.Sprite = new Sprite(ConsoleColor.Blue, "%");
                else if (item is CyanShadow)
                    item.Sprite = new Sprite(ConsoleColor.Cyan, "%");
                else if (item is GreenShadow)
                    item.Sprite = new Sprite(ConsoleColor.Green, "%");
            }
            StopTimer(aTimerScared);
        }
    }
}
