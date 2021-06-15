using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW03
{
    class StringAndSymbol
    {
        private string str;
        private char symbol;

        public void InputString()
        {
            Console.Write("Input string: ");
            str = Console.ReadLine();
            Console.Write("Intup symbol: ");
            symbol = Convert.ToChar(Console.ReadLine());
        }

        public void FindSymbol()
        {
            for (int i = 0; i < str.Length; i++)
                if (str[i] == symbol)
                    str = str.Replace(symbol, Convert.ToChar(Convert.ToString(symbol).ToUpper()));
        }

        public void DeleteEnd()
        {
            for (int i = str.Length - 1; i >= 0; i--)
                if (str[i] == symbol)
                {
                    str = str.Remove(i, str.Length - i);
                    return;
                }
        }

        public void PrintString()
        {
            Console.WriteLine(str);
        }
    }
}