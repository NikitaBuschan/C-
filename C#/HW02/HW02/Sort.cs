using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HW02
{
    class Sort
    {
        private int[,] matrix;
        private int side;

        public void InputSide()
        {
            Console.Write("Enter side of matrix: ");
            side = Convert.ToInt32(Console.ReadLine());
            matrix = new int[side, side];
        }

        public void FieldMatrix()
        {
            Random random = new Random();
            for (int i = 0; i < side; i++)
                for (int j = 0; j < side; j++)
                    matrix[i, j] = random.Next(-500, 500);
        }

        public void SortMatrix()
        {
            int[,] temp = new int[side, side];
            for (int i = 0; i < side - 1; i++)
            {
                int one = 0;
                int two = 0;
                for (int j = 0; j < side; j++)
                {
                    one += matrix[j, i];
                    two += matrix[j, i + 1];
                }
                if (two < one)
                {
                    int[] mass = new int[side];
                    for (int z = 0; z < side; z++)
                    {
                        mass[z] = matrix[z, i];
                        matrix[z, i] = matrix[z, i + 1];
                        matrix[z, i + 1] = mass[z];
                    }
                    if (i > 1)
                        i -= 2;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                    Console.Write(matrix[i, j] + "   ");
                Console.WriteLine();
            }
        }
    }
}