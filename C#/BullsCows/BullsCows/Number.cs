using System;

namespace BullsCows
{
    class Number
    {
        private int[] number = new int[4];

        public int GetNumber(int index) { return number[index]; }

        public void Generate()
        {
            var rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    number[i] = rand.Next(1, 9);
                    continue;
                }
                number[i] = rand.Next(0, 9);
                for (int j = 0; j < i; j++)
                    if (number[i] == number[j])
                    {
                        i--;
                        break;
                    }
            }
        }
    }
}
