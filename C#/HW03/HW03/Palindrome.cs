using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW03
{
    class Palindrome
    {
        private string str;

        public void Input()
        {
            Console.WriteLine("Введите строку: ");
            str = Console.ReadLine();
        }

        private string Сonversion()
        {
            return str.ToUpper().Replace(" ", "");
        }

        public bool CheckString()
        {
            string temp = Сonversion();

            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
                if (str[i] != str[j])
                    return false;
            return true;
        }

        public void PrintResult() => Console.WriteLine("Strnig has " + (CheckString() ? "palindrome" : "no palindrome"));
    }
}