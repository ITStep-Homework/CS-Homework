using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCS
{
    internal class homework4
    {
        public class Fraction
        {
            private int numerator;
            private int denominator;

            public int Numerator
            {
                get { return numerator; }
                set { numerator = value; }
            }

            public int Denominator
            {
                get { return denominator; }
                set
                {
                    if (value == 0)
                        throw new ArgumentException("Знаменатель не может быть равен нулю");
                    denominator = value;
                }
            }

            public Fraction(int numerator, int denominator)
            {
                if (denominator == 0)
                    throw new ArgumentException("Знаменатель не может быть равен нулю");

                this.numerator = numerator;
                this.denominator = denominator;
                Simplify();
            }

            private void Simplify()
            {
                int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
                numerator /= gcd;
                denominator /= gcd;

                if (denominator < 0)
                {
                    numerator = -numerator;
                    denominator = -denominator;
                }
            }

            private int GCD(int a, int b)
            {
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }

            public static Fraction operator +(Fraction f1, Fraction f2)
            {
                int newNumerator = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
                int newDenominator = f1.denominator * f2.denominator;
                return new Fraction(newNumerator, newDenominator);
            }

            public static Fraction operator -(Fraction f1, Fraction f2)
            {
                int newNumerator = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
                int newDenominator = f1.denominator * f2.denominator;
                return new Fraction(newNumerator, newDenominator);
            }

            public static Fraction operator *(Fraction f1, Fraction f2)
            {
                int newNumerator = f1.numerator * f2.numerator;
                int newDenominator = f1.denominator * f2.denominator;
                return new Fraction(newNumerator, newDenominator);
            }

            public static Fraction operator /(Fraction f1, Fraction f2)
            {
                if (f2.numerator == 0)
                    throw new DivideByZeroException("Деление на ноль");

                int newNumerator = f1.numerator * f2.denominator;
                int newDenominator = f1.denominator * f2.numerator;
                return new Fraction(newNumerator, newDenominator);
            }

            public static bool operator ==(Fraction f1, Fraction f2)
            {
                return f1.numerator * f2.denominator == f2.numerator * f1.denominator;
            }

            public static bool operator !=(Fraction f1, Fraction f2)
            {
                return !(f1 == f2);
            }

            public static bool operator <(Fraction f1, Fraction f2)
            {
                return f1.numerator * f2.denominator < f2.numerator * f1.denominator;
            }

            public static bool operator >(Fraction f1, Fraction f2)
            {
                return f1.numerator * f2.denominator > f2.numerator * f1.denominator;
            }

            public static bool operator true(Fraction f)
            {
                return Math.Abs(f.numerator) < Math.Abs(f.denominator);
            }

            public static bool operator false(Fraction f)
            {
                return Math.Abs(f.numerator) > Math.Abs(f.denominator);
            }

            public static Fraction operator *(Fraction f, int i)
            {
                return new Fraction(f.numerator * i, f.denominator);
            }

            public static Fraction operator *(int i, Fraction f)
            {
                return new Fraction(f.numerator * i, f.denominator);
            }

            public static Fraction operator +(Fraction f, double d)
            {
                int wholePart = (int)d;
                double fractionalPart = d - wholePart;

                int newNumerator = (int)(fractionalPart * 1000);
                int newDenominator = 1000;

                Fraction doubleFraction = new Fraction(wholePart * newDenominator + newNumerator, newDenominator);
                return f + doubleFraction;
            }

            public override string ToString()
            {
                if (denominator == 1)
                    return numerator.ToString();
                return $"{numerator}/{denominator}";
            }
        }

        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 4);
            int a = 10;
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            double d = 1.5;
            Fraction f3 = f + d;

            Console.WriteLine($"f = {f}");
            Console.WriteLine($"f1 = f * a = {f1}");
            Console.WriteLine($"f2 = a * f = {f2}");
            Console.WriteLine($"f3 = f + d = {f3}");

            Console.WriteLine($"f правильная дробь: {(f ? "да" : "нет")}");
            Console.WriteLine($"f1 правильная дробь: {(f1 ? "да" : "нет")}");
        }
    }
}