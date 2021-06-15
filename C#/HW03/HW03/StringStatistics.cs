using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW03
{
    class StringStatistics
    {
        private string str;

        public void InputString()
        {
            Console.Write("Input string: ");
            str = Console.ReadLine();
        }

        public int GetCountSymbols()
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] < 'a' || str[i] > 'z' &&
                    str[i] < 'A' || str[i] > 'Z' &&
                    str[i] < '0' || str[i] > '9')
                    count++;
            return count;
        }

        public int GetCountLetter()
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z')
                    count++;
            return count;
        }

        public int GetContLetterUp()
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] >= 'A' && str[i] <= 'Z')
                    count++;
            return count;
        }

        public int GetCountLetterDown()
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] >= 'a' && str[i] <= 'z')
                    count++;
            return count;
        }

        public int GetCountNumbers()
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] >= '0' && str[i] <= '9')
                    count++;
            return count;
        }

        public int GetCountPunctuation()
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ',' || str[i] == '.' || str[i] == '?' ||
                    str[i] == '\\' || str[i] == '-' || str[i] == ';' || str[i] == '/')
                    count++;
            return count;
        }

        public int GetCountSpace()
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                    count++;
            return count;
        }

        public void PrintStatistic()
        {
            Console.WriteLine("Count symbols: " + GetCountSymbols());
            Console.WriteLine("Count letters: " + GetCountLetter());
            Console.WriteLine("Count letter in up register: " + GetContLetterUp());
            Console.WriteLine("Count letter in down register: " + GetCountLetterDown());
            Console.WriteLine("Count of numbers: " + GetCountNumbers());
            Console.WriteLine("Count of punctuation: " + GetCountPunctuation());
            Console.WriteLine("Count of space: " + GetCountSpace());
        }
    }
}