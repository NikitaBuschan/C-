using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW02
{
    class Matrix
    {
        private int[,] mass;
        private int length;

        public void SetLength()
        {
            Console.Write("Set length of mass: ");
            length = Convert.ToInt32(Console.ReadLine());
            mass = new int[length, length];
        }

        public void FieldMass()
        {
            Random rand = new Random();
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    mass[i, j] = rand.Next(0, 10);
        }

        public void Swap()
        {
            int[,] newMass = new int[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    newMass[i, j] = mass[j, i];

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    mass[i, j] = newMass[i, j];
        }

        public void Print()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                    Console.Write(mass[i, j] + "  ");
                Console.WriteLine();
            }
        }
    }
}