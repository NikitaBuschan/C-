﻿using System;

namespace ProjectTwoCore
{
    public class Calculator
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static double Divide(double x, double y)
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
                // Custom business logic for divide by zero
                return 0;
            }
        }
    }
}
