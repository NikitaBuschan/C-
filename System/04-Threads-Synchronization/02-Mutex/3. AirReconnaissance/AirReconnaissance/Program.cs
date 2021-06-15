using System;
using System.Collections.Generic;
using System.Drawing;

namespace AirReconnaissance
{
    public class Program
    {
        public static List<Point> Targets { get; set; } = new List<Point>();
        public static List<Point> posibleMove { get; set; } = new List<Point>();
        public static List<int> CountOfTargets { get; set; } = new List<int>();
        public static int Height { get; set; }
        public static int Width { get; set; }

        static void Main(string[] args)
        {
            Console.Write("Enter height: ");
            Height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter width: ");
            Width = Convert.ToInt32(Console.ReadLine());

            var map = new Map(new Size(Width, Height));

            map.Draw();

            var one = new Plane();
            var two = new Plane();

            int result = 0;

            foreach (var targets in CountOfTargets)
            {
                result += targets;
            }

            Console.Clear();
            Console.WriteLine($"Count of targets were: {result}");
        }
    }
}
