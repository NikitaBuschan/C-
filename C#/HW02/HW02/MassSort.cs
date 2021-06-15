using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW02
{
    class MassSort
    {
        private int[] mass;

        public void SetLength()
        {
            Console.Write("Set length of mass: ");
            mass = new int[Convert.ToInt32(Console.ReadLine())];
        }

        public void FeieldMass()
        {
            Random random = new Random();
            for (int i = 0; i < mass.Length; i++)
                mass[i] = random.Next(-3, 3);
        }

        public void SortMass()
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] < 0)
                {
                    int temp = mass[i];
                    for (int j = i; j > 0; j--)
                        mass[j] = mass[j - 1];
                    mass[0] = temp;
                }
            }
        }

        public void Print()
        {
            foreach (var item in mass)
                Console.Write(item + "  ");
        }
    }
}
