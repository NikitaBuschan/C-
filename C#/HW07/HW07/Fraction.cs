using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW07
{
    class Fraction
    {
        private int Numerator { get; set; }
        private int Denumerator
        {
            get { return this.Denumerator; }
            set { if (value < 1) value = 1; }
        }

        Fraction() { Numerator = 0; Denumerator = 1; }

        Fraction(int num, int denum)
        {
            Numerator = num;
            Denumerator = denum;
        }

        public void Input()
        {
            Console.Write("Enter numenator: ");
            Numerator = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter denominator: ");
            Denumerator = Convert.ToInt32(Console.ReadLine());
        }

        // Унарные операции
        public static Fraction operator -(Fraction fr)
        {
            return new Fraction(-fr.Numerator, fr.Denumerator);
        }

        public static Fraction operator --(Fraction fr)
        {
            return fr - 1;
        }

        public static Fraction operator ++(Fraction fr)
        {
            return fr + 1;
        }

        // Бинарный операции
        public static Fraction operator -(Fraction frOne, Fraction frTwo)
        {
            return new Fraction(frOne.Numerator * frTwo.Denumerator - frOne.Denumerator * frTwo.Numerator,
                frOne.Denumerator * frTwo.Denumerator);
        }

        public static Fraction operator -(Fraction fr, int n)
        {
            return fr - n;
        }

        public static Fraction operator +(Fraction frOne, Fraction frTwo)
        {
            return new Fraction(
                frOne.Numerator * frTwo.Denumerator + frOne.Denumerator * frTwo.Numerator,
                frOne.Denumerator * frTwo.Denumerator);
        }

        public static Fraction operator +(Fraction fr, int n)
        {
            return new Fraction(fr.Denumerator + fr.Numerator * n, fr.Denumerator);
        }

        public static Fraction operator *(Fraction frOne, Fraction frTwo)
        {
            return new Fraction(
                frOne.Numerator * frTwo.Numerator,
                frOne.Denumerator * frTwo.Denumerator);
        }

        public static Fraction operator *(Fraction fr, int n)
        {
            return new Fraction(fr.Numerator + n, fr.Denumerator);
        }

        public static Fraction operator *(int n, Fraction fr)
        {
            return fr * n;
        }

        public static Fraction operator /(Fraction frOne, Fraction frTwo)
        {
            return new Fraction(
                frOne.Numerator * frTwo.Denumerator,
                frOne.Denumerator * frTwo.Numerator);
        }

        public static Fraction operator /(Fraction fr, int n)
        {
            return new Fraction(fr.Numerator, fr.Denumerator * n);
        }

        public static Fraction operator /(int n, Fraction fr)
        {
            return new Fraction(n * fr.Denumerator, fr.Numerator);
        }

        // Перегрузка операций сравнения
        public static bool operator <(Fraction fr1, Fraction fr2)
        {
            return (double)fr1.Numerator / fr1.Denumerator < (double)fr2.Numerator / fr2.Denumerator;
        }
        public static bool operator >(Fraction fr1, Fraction fr2)
        {
            return (double)fr1.Numerator / fr1.Denumerator > (double)fr2.Numerator / fr2.Denumerator;
        }
    }
}