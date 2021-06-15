using System;
using System.Collections.Generic;
using System.Text;

namespace HW01
{
    class CountEvenNoneven
    {
        private string number;
        private double even = 0;
        private double odd = 0;

        public void Input()
        {
            do
            {
                Console.Write("Enter number: ");
                number = Console.ReadLine();
            } while (Convert.ToInt32(number) < 100 || Convert.ToInt32(number) > 100000000);
        }

        public void GetCount()
        {
            for (int i = 0; i < number.Length; i++)
                if (Convert.ToInt32(number[i]) % 2 == 0)
                    even++;
                else
                    odd++;
        }

        public void PrintRusult()
        {
            Console.WriteLine("Even: " + even + "\tOdd: " + odd);
            Console.WriteLine("Even: " + (even * 100 / number.Length) + "%" + "\nOdd: " + (odd * 100 / number.Length) + "%");
        }
    }
}