using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW05
{
    class Decision
    {
        public LinearEquation linearEquation = new LinearEquation();

        public void Calculate(ref int x, ref int y)
        {
            var rand = new Random();
            int temp = rand.Next(1, 10);

            x = -linearEquation.A * temp;
            y = linearEquation.B * temp;
        }

        public void CalculateTwoEquation(LinearEquation secondEquation, ref int x, ref int y)
        {
            if (linearEquation.A == 0 || linearEquation.B == 0)
                throw new DivideByZeroException("Can not be divided by zero.");

            if ((double)linearEquation.A / (double)secondEquation.A == (double)linearEquation.B / (double)secondEquation.B)
                Calculate(ref x, ref y);
            else
                throw new ArgumentOutOfRangeException("No solution found.");
        }
    }
}