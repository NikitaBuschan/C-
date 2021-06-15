using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HW01
{
    class Flag
    {
        private byte side;

        private void RandSide()
        {
            Random random = new Random();
            side = Convert.ToByte(random.Next(21, 41));
        }

        public void Print()
        {
            RandSide();
            int indent = 3;

            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    Console.Write(" ");
                    if (j > indent - 1 && i > side / indent && i < side - side / indent && j < side - indent ||
                         i > indent - 1 && j > side / indent - 1 && j < side - side / indent && i < side - indent)
                        Console.Write("*");
                    else
                        Console.Write("@");
                }
                Console.WriteLine();
            }
        }
    }
}