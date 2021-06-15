using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    struct Position
    {
        public int x;
        public int y;
    }
    class Puzzle
    {
        private const int size = 4;
        private Position[] position = new Position[size * size];
        private int user_position = 15;
        private int[] m_map = new int[size * size];

        public void FieldMap()
        {
            int count = 0;
            for (int i = 0; i < size * size - 1; i++)
                m_map[i] = ++count;
        }

        public void FieldPositions()
        {
            int count = 0;
            for (int i = 0, z = 5, left; i < size; i++)
            {
                left = 10;
                for (int j = 0, x = 3, top = 6; j < size; j++)
                {
                    position[count].x = i * top + x;
                    position[count].y = j * left + z;
                    count++;
                }
            }
        }

        public void ShufflePositions()
        {
            int stepUpDown = 4;
            int stepLeftRight = 1;
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var temp = rand.Next(1, 4);
                switch (temp)
                {
                    case 1:
                        SwapTo(user_position - stepUpDown);
                        break;
                    case 2:
                        SwapTo(user_position + stepUpDown);
                        break;
                    case 3:
                        SwapTo(user_position - stepLeftRight);
                        break;
                    case 4:
                        SwapTo(user_position + stepLeftRight);
                        break;
                }
            }
        }

        public void PrintPositions()
        {
            for (int i = 0; i < position.Length; i++)
            {
                Console.SetCursorPosition(position[i].y, position[i].x);
                if (m_map[i] == 0)
                {
                    Console.Write("  ");
                    continue;
                }
                Console.Write(m_map[i]);
            }
        }

        public void PrintMap()
        {
            Console.WriteLine("┌─────────┬─────────┬─────────┬─────────┐");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("├─────────┼─────────┼─────────┼─────────┤");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("├─────────┼─────────┼─────────┼─────────┤");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("├─────────┼─────────┼─────────┼─────────┤");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("│         │         │         │         │");
            Console.WriteLine("└─────────┴─────────┴─────────┴─────────┘");
        }

        public void Move()
        {
            int stepUpDown = 4;
            int stepLeftRight = 1;

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    StepTo(user_position - stepUpDown);
                    break;
                case ConsoleKey.DownArrow:
                    StepTo(user_position + stepUpDown);
                    break;
                case ConsoleKey.LeftArrow:
                    StepTo(user_position - stepLeftRight);
                    break;
                case ConsoleKey.RightArrow:
                    StepTo(user_position + stepLeftRight);
                    break;
                case ConsoleKey.Escape:
                    FieldMap();
                    return;
            }
        }

        public void StepTo(int step)
        {
            if (step > -1 && step < 16)
            {
                Console.SetCursorPosition(position[step].y, position[step].x);
                Console.Write("  ");
                Console.SetCursorPosition(position[user_position].y, position[user_position].x);
                Console.Write(m_map[step]);

                SwapTo(step);
            }
        }

        public void SwapTo(int step)
        {
            if (step > -1 && step < 16)
            {
                m_map[user_position] = m_map[step];
                m_map[step] = 0;
                user_position = step;
            }
        }

        public bool CheckWin()
        {
            for (int i = 0; i < m_map.Length - 1; i++)
                if (m_map[i] != i + 1)
                    return false;
            return true;
        }
    }
}