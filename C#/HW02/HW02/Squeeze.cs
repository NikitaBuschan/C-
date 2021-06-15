using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW02
{
    class Squeeze
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
                mass[i] = random.Next(-1, 3);
        }

        public void SqueezeMass()
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] == 0)
                {
                    for (int j = i; j < mass.Length - 1; j++)
                        mass[j] = mass[j + 1];
                    i--;
                }
                mass[mass.Length - 1] = -1;
            }
        }

        public void Print()
        {
            foreach (var item in mass)
                Console.Write(item + "  ");
        }
    }
}