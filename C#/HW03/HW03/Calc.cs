using System;
using System.Linq.Expressions;

namespace HW03
{
    class Check
    {
        public int LastNumber(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (Number(str[i]))
                    while (i++ < str.Length)
                        if (Space(str[i]))
                            return 0;
            return -1;
        }
        public bool Number(char s) => (s >= '0' && s <= '9');
        public bool Operation(char s) =>
            (s == '+' || s == '-' ||
             s == '*' || s == '/' ||
             s == '^' || s == '(' ||
             s == ')' || s == '.');
        public bool Operator(char s) =>
            (s == '+' || s == '-' || s == '*' || s == '/' || s == '^');
        public bool LHook(char s) => s == '(';
        public bool RHook(char s) => s == ')';
        public bool Point(char s) => s == '.';
        public bool Space(char s) => s == ' ';
        public bool Expression(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (str[i] >= 'a' && str[i] <= 'z' ||
                    str[i] >= 'A' && str[i] <= 'Z')
                    return false;
            return true;
        }
    }

    class Calc : Check
    {
        private string str;

        public Calc() : base() { }
        public void Input()
        {
            Console.Write("Write expression: ");
            str = Console.ReadLine();
        }

        public int GetBack(string str, int point)
        {
            int iter = point;

            while (Convert.ToBoolean(iter))
            {
                if (LHook(str[iter]))
                    return iter;
                iter--;
                if (RHook(str[iter]))
                {
                    while (!LHook(str[iter]))
                    {
                        iter--;
                    }
                    return iter;
                }
                if (!Number(str[iter]))
                    return iter + 1;
            }
            return 0;
        }

        public int GetPrioriti(string str, int iter)
        {
            if (LastNumber(str) == -1)
                return -1;

            char[] opmass = { '^', '(', '*', '/', '-', '+' };

            int j = iter;
            for (uint i = 0; i < opmass.Length; i++)
                while (j++ < str.Length)
                    if (str[(int)j] == opmass[i])
                        return GetBack(str, j);
            return -1;
        }


    }
}