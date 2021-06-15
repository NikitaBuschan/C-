using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW05
{
    class LinearEquation
    {
        public string equation = string.Empty;
        public string secondEquation = string.Empty;
        public int A { get; private set; }
        public int B { get; private set; }
        public int ASecond { get; private set; }
        public int BSecond { get; private set; }

        public void Input(string str)
        {
            Console.Write("Enter equation: ");
            str = Console.ReadLine();
        }
        public void Check(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ' && str[i + 1] < '0' || str[i + 1] > '9')
                    throw new FormatException("Wrong format");
        }

        public void GetAB(string str, ref int a, ref int b)
        {
            string tempA = string.Empty;
            string tempB = string.Empty;
            bool flag = true;

            foreach (var item in str)
            {
                if (item == ',' || item == ' ')
                    flag = false;
                else if (char.IsDigit(item) && !flag)
                    tempB += item;
                else
                    tempA += item;
            }

            a = Convert.ToInt32(tempA);
            b = Convert.ToInt32(tempB);
        }
    }
}