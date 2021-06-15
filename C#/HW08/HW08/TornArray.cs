using System;

namespace HW08
{
    class TornArray
    {
        private int[][] array;
        public TornArray(int n)
        {
            array = new int[n][];
            for (int i = 0, j = 5; i < n; i++, j += 2)
                array[i] = new int[j];

            Field();
        }

        public void Field()
        {
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    array[i][j] = rand.Next(1, 10);
        }

        public int this[int x, int y]
        {
            get
            {
                if (x > array.Length || y > array[x].Length)
                    throw new Exception("Out of bounds array.");
                return array[x][y];
            }
            private set { }
        }
    }
}