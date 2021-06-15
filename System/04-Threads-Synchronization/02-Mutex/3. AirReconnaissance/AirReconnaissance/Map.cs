using System;
using System.Drawing;

namespace AirReconnaissance
{
    public class Map
    {
        public Size Size { get; }

        public Map(Size size)
        {
            Size = size;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int height = 0; height < Size.Height; height++)
            {
                for (int width = 0; width < Size.Width; width++)
                { 
                    Console.SetCursorPosition(width * 4, height * 2);
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (i == 0 || j == 0 || i == 2 || j == 4)
                            {
                                Console.Write("*");
                            }
                            else if (i == 1 && j == 2)
                            {
                                Program.posibleMove.Add(new Point(width * 4 + j, height * 2 + i));
                                if (new Random().Next(0, 2) == 1)
                                {
                                    Program.Targets.Add(new Point(width * 4 + j, height * 2 + i));
                                    Console.SetCursorPosition(
                                            Program.Targets[Program.Targets.Count - 1].X,
                                            Program.Targets[Program.Targets.Count - 1].Y);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("#");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                else
                                {
                                    Console.SetCursorPosition(width * 4 + j, height * 2 + i);
                                    Console.Write(" ");
                                }
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.SetCursorPosition(width * 4, (height * 2 + i + 1));
                    }
                }
            }
        }
    }
}
