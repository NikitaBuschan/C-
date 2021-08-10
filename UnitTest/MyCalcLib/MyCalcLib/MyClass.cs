using System;
using System.Collections.Generic;
using System.Text;

namespace MyCalcLib
{
    public class MyClass
    {
        public static double GetSqrt(double value)
        {
            return Math.Sqrt(value);
        }

        public string SayHello(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Parameter is empty");
            }

            return "Hello " + name;
        }
    }
}
