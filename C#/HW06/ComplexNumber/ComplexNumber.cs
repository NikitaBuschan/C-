using System;

namespace ComplexNumber
{
    class ComplexNumber
    {
        private string ComplexNum = string.Empty;
        private double Complex { get; set; }
        public ComplexNumber()
        {
            Complex = 0;
        }
        public ComplexNumber(double number)
        {
            Complex = number;
        }
        public ComplexNumber(double one, double two)
        {
            ComplexNum = $"{one} + -1 * {two}";
        }

        public static ComplexNumber operator +(ComplexNumber one, ComplexNumber two)
        {
            return new ComplexNumber(one.Complex + two.Complex);
        }
        public static ComplexNumber operator +(ComplexNumber one, double number)
        {
            return new ComplexNumber(one.Complex + number);
        }
        public static ComplexNumber operator -(ComplexNumber one, ComplexNumber two)
        {
            return new ComplexNumber(one.Complex - two.Complex);
        }
        public static ComplexNumber operator -(ComplexNumber one, double number)
        {
            return new ComplexNumber(one.Complex - number);
        }
        public static ComplexNumber operator /(ComplexNumber one, ComplexNumber two)
        {
            if (two.Complex == 0)
                throw new DivideByZeroException("Can not devide by zero.");
            return new ComplexNumber(one.Complex / two.Complex);
        }
        public static ComplexNumber operator /(ComplexNumber one, double two)
        {
            if (two == 0)
                throw new DivideByZeroException("Can not devide by zero.");
            return new ComplexNumber(one.Complex / two);
        }
        public static ComplexNumber operator *(ComplexNumber one, ComplexNumber two)
        {
            if (two.Complex == 0)
                throw new DivideByZeroException("Can not devide by zero.");
            return new ComplexNumber(one.Complex * two.Complex);
        }
        public static ComplexNumber operator *(ComplexNumber one, double two)
        {
            if (two == 0)
                throw new DivideByZeroException("Can not devide by zero.");
            return new ComplexNumber(one.Complex * two);
        }
    }
}