using System;

namespace BullsCows
{
    class Insert
    {
        private string number;
        private int[] intNumbers = new int[4];
        private int bulls = 0;
        private int cows = 0;

        public void UserSet()
        {
            Console.WriteLine("Enter number: ");
            number = Console.ReadLine();
            for (int i = 0; i < 4; i++)
                intNumbers[i] = Convert.ToInt32(number[i]) - '0';
        }

        public void Check(Number num)
        {
            for (int i = 0; i < intNumbers.Length; i++)
            {
                if (intNumbers[i] == num.GetNumber(i))
                    bulls++;
                for (int j = 0; j < intNumbers.Length; j++)
                {
                    if (i == j)
                        continue;
                    else
                        if (intNumbers[i] == num.GetNumber(j))
                        cows++;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Bulls: " + bulls + "  " + "Cows: " + cows);
        }

        public bool Win()
        {
            if (bulls == 4)
            {
                Console.WriteLine("You win!");
                return true;
            }
            return false;
        }
    }
}
