using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW03
{
    class FindString
    {
        private string str;
        private string substring;

        public void Input()
        {
            Console.Write("Write string: ");
            str = Console.ReadLine();
            Console.Write("Write substring: ");
            substring = Console.ReadLine();
        }

        private bool HaveString()
        {
            if (str.IndexOf(substring) != -1)
                return true;
            else
                return false;
        }

        private void ChangeString()
        {
            Console.Write("Enter string: ");
            string temp = Console.ReadLine();
            str = str.Replace(substring, temp);
        }

        public void Print()
        {
            if (HaveString())
            {
                Console.WriteLine("\nString have substring\n");
                ChangeString();
                Console.WriteLine("New string: " + str);
            }
            else
                Console.WriteLine("String no have substring");
        }
    }
}