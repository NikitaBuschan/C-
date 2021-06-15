using System;
using System.Drawing;
using System.Threading;

namespace AirReconnaissance
{
    public enum Direction { up, down, left, right, nowhere };

    public class Plane
    {
        public ManualResetEvent ManualResetEvent { get; }
        public Thread Thread { get; }
        public Point Point { get; set; }
        public Direction Direction { get; set; }
        public int CountOfTargets { get; set; }

        public Plane()
        {
            CountOfTargets = 0;
            Point = Program.posibleMove[new Random().Next(0, Program.posibleMove.Count)];
            Thread = new Thread(Move);

            Console.SetCursorPosition(Point.X, Point.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");

            Thread.Start();
        }

        public void Move()
        {
            Direction = GetWay();
            while (true)
            {
                switch (Direction)
                {
                    case Direction.up:
                        {
                            if ((Point.Y - 1) / 2 < 1)
                            {
                                Program.CountOfTargets.Add(CountOfTargets);
                                return;
                            }
                            RedrowPlane(Point, new Point(Point.X, Point.Y - 2));
                            Point = new Point(Point.X, Point.Y - 2);
                            if (CheckTarget(Point))
                            {
                                CountOfTargets++;
                            }
                            break;
                        }
                    case Direction.down:
                        {
                            if ((Point.Y + 1) / 2 > Program.Height - 1)
                            {
                                Program.CountOfTargets.Add(CountOfTargets);
                                return;
                            }
                            RedrowPlane(Point, new Point(Point.X, Point.Y + 2));
                            Point = new Point(Point.X, Point.Y + 2);
                            if (CheckTarget(Point))
                            {
                                CountOfTargets++;
                            }
                            break;
                        }
                    case Direction.left:
                        {
                            if ((Point.X - 3) / 4 < 1)
                            {
                                Program.CountOfTargets.Add(CountOfTargets);
                                return;
                            }
                            RedrowPlane(Point, new Point(Point.X - 4, Point.Y));
                            Point = new Point(Point.X - 4, Point.Y);
                            if (CheckTarget(Point))
                            {
                                CountOfTargets++;
                            }
                            break;
                        }
                    case Direction.right:
                        {
                            if ((Point.X + 3) / 4 > Program.Width - 1)
                            {
                                Program.CountOfTargets.Add(CountOfTargets);
                                return;
                            }
                            RedrowPlane(Point, new Point(Point.X + 4, Point.Y));
                            Point = new Point(Point.X + 4, Point.Y);
                            if (CheckTarget(Point))
                            {
                                CountOfTargets++;
                            }
                            break;
                        }
                    default:
                        break;
                }
                Thread.Sleep(1000);
            }
        }

        public Direction GetWay()
        {
            Direction dirX = Direction.nowhere;
            Direction dirY = Direction.nowhere;

            Console.SetCursorPosition(0, 10);
            int aInt = 0;
            int bInt = 0;

            if (Point.X / 4 >= Program.Width / 2)
            {
                dirX = Direction.left;
                aInt = Point.X / 4;
            }
            else if (Point.X / 4 < Program.Width / 2)
            {
                dirX = Direction.right;
                aInt = Point.X / 4;
            }

            if (Point.Y / 2 >= Program.Height / 2)
            {
                dirY = Direction.up;
                bInt = Point.Y;
            }
            else if (Point.Y / 2 < Program.Height / 2)
            {
                dirY = Direction.down;
                bInt = Point.Y;
            }

            if (aInt >= bInt)
                return dirX;
            else
                return dirY;
        }

        public bool CheckTarget(Point point)
        {
            foreach (var move in Program.Targets)
                if (move.X == point.X && move.Y == point.Y)
                    return true;

            return false;
        }

        public void RedrowPlane(Point nowStay, Point stepTo)
        {
            Console.SetCursorPosition(nowStay.X, nowStay.Y);
            Console.ForegroundColor = ConsoleColor.Blue;

            if (CheckTarget(nowStay))
                Console.Write("#");
            else
                Console.Write(" ");

            Console.SetCursorPosition(stepTo.X, stepTo.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
        }
    }
}
