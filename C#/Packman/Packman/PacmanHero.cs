using System;
using System.Threading;

namespace Pacman
{
    public class PacmanHero : Unit
    {
        public Direction nextObjectDirection = Direction.nowhere;
        public static int Scores { get; private set; }
        public static int CountOfCollectedPoints { get; private set; } = 0;

        public PacmanHero()
        {
            Coord = new Coord(17, 14);
            Sprite = new Sprite(ConsoleColor.Yellow, "@");
            Scores = 0;
        }

        public override void Move(Map map)
        {
            if (GetCoordByDirection(objectDirection) == new Coord(14, 0))
            {
                NextCoord = new Coord(14, 27);
                Draw.RedrowUnit(this, null);
                ChangeCoord(map, NextCoord, 0, 5);
                return;
            }
            else if (GetCoordByDirection(objectDirection) == new Coord(14, 28))
            {
                NextCoord = new Coord(14, 1);
                Draw.RedrowUnit(this, null);
                ChangeCoord(map, NextCoord, 0, 5);
                return;
            }
            if (nextObjectDirection != Direction.nowhere && CheckMove(map, NextCoord = GetCoordByDirection(nextObjectDirection)))
            {
                objectDirection = nextObjectDirection;

                Eat(map, NextCoord);
                Draw.RedrowUnit(this, null);
                ChangeCoord(map, NextCoord, 0, 5);

                nextObjectDirection = Direction.nowhere;
            }
            else if (CheckMove(map, NextCoord = GetCoordByDirection(objectDirection)))
            {
                Eat(map, NextCoord);
                Draw.RedrowUnit(this, null);
                ChangeCoord(map, NextCoord, 0, 5);
            }
        }

        public override void Eaten() { }

        public override void Eat() { }

        public override void Exit() { }

        public void Eat(Map map, Coord coord)
        {
            if (map[coord] == 3)
            {
                Scores += 10;
                CountOfCollectedPoints++;
            }
            if (map[coord] == 4)
            {
                Game.fright = true;
                Timers.SetFrightTimer();
                Scores += 50;
                CountOfCollectedPoints++;
            }
            if (Game.fright)
            {
                foreach (var item in Game.ghosts)
                {
                    if (Coord == item.Coord)
                    {
                        Scores += 100;
                        item.Eat();
                        Game.exit += item.Exit;
                        Game.move -= item.Move;
                        Timers.StopTimer(Timers.aTimer);
                        Timers.SetTimerOutShadows();
                    }
                }
            }
        }

        public void Control(Map map, ConsoleKeyInfo info)
        {
            switch (info.Key)
            {
                case ConsoleKey.Escape:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    var pause = new Menu.Pause();
                    pause.ShowMenu();
                    pause.Control();
                    if (Timers.aTimer != null)
                        Timers.aTimer.Start();
                    Draw.AllMap(map);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                case ConsoleKey.NumPad4:
                    nextObjectDirection = Direction.left;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                case ConsoleKey.NumPad6:
                    nextObjectDirection = Direction.right;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                case ConsoleKey.NumPad8:
                    nextObjectDirection = Direction.up;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                case ConsoleKey.NumPad2:
                    nextObjectDirection = Direction.down;
                    break;
            }
        }

        public void CheckWin()
        {
            if (CountOfCollectedPoints == 240)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.SetCursorPosition(14, 10);
                Console.WriteLine("You win!");
                Thread.Sleep(2000);
                Console.Clear();
                Game.scores.AddScores();
                Console.Clear();
                Game.scores.Draw();
                Console.ReadKey();
                var menu = new Menu.Main();
                menu.ShowMenu();
                menu.Control();
            }
        }
    }
}