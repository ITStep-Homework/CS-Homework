using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCS
{
    internal class homework1
    {
        public static void FizzBuzz()
        {
            Console.WriteLine("Enter a positive integer between 1 and 100:");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int n) || n < 1 || n > 100)
            {
                Console.WriteLine("Please enter a valid positive integer.");
                return;
            }

            bool isFizz = n % 3 == 0;
            bool isBuzz = n % 5 == 0;

            if (isFizz && isBuzz)
            {
                Console.WriteLine("Fizz Buzz");
            }
            else if (isFizz)
            {
                Console.WriteLine("Fizz");
            }
            else if (isBuzz)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(n);
            }
        }
        public static void CalculatePercent()
        {
            Console.WriteLine("Enter the first number:");
            string input1 = Console.ReadLine();
            Console.WriteLine("Enter the second number:");
            string input2 = Console.ReadLine();

            if (!double.TryParse(input1, out double num1) || !double.TryParse(input2, out double num2) || num2 < 0)
            {
                Console.WriteLine("Please enter valid numbers");
                return;
            }

            double percent = num1 * num2 / 100;
            Console.WriteLine($"The {num2}% of {num1} is: {percent}");
        }
        public static void CombineDigits()
        {
            Console.WriteLine("Enter 4 numbers separated by spaces:");
            string input = Console.ReadLine();
            string[] digits = input.Split(' ');

            if (digits.Length != 4 || !digits.All(n => int.TryParse(n, out _)))
            {
                Console.WriteLine("Please enter exactly 4 valid digits.");
                return;
            }

            Console.WriteLine("The combined number is: " + string.Join("", digits));
        }
        public static void SwapDigits()
        {
            Console.WriteLine("Enter 6 digits number:");
            string input = Console.ReadLine();

            if (input.Length != 6 || !int.TryParse(input, out _))
            {
                Console.WriteLine("Please enter a valid 6-digit number.");
                return;
            }

            Console.WriteLine("Enter positions to swap (1-6) separated by space separated by space:");
            string swapInput = Console.ReadLine();
            string[] positions = swapInput.Split(' ');

            if (positions.Length != 2 ||
                !int.TryParse(positions[0], out int pos1) ||
                !int.TryParse(positions[1], out int pos2) ||
                pos1 < 1 || pos1 > 6 || pos2 < 1 || pos2 > 6)
            {
                Console.WriteLine("Please enter valid positions to swap.");
                return;
            }

            char[] digits = input.ToCharArray();
            char temp = digits[pos1 - 1];
            digits[pos1 - 1] = digits[pos2 - 1];
            digits[pos2 - 1] = temp;

            Console.WriteLine("The number after swapping is: " + new string(digits));
        }
        public static void DateStats()
        {
            Console.WriteLine("Enter date in format dd.MM.yyyy:");
            string input = Console.ReadLine();

            if (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("Please enter a valid date in dd.MM.yyyy format.");
                return;
            }

            string season;
            int month = date.Month;
            if (month == 12 || month == 1 || month == 2)
                season = "Winter";
            else if (month >= 3 && month <= 5)
                season = "Spring";
            else if (month >= 6 && month <= 8)
                season = "Summer";
            else
                season = "Autumn";

            string dayOfWeek = date.ToString("dddd", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine($"{season} {dayOfWeek}");
        }
        //static void Main(string[] args)
        //{
        //    FizzBuzz();
        //    CalculatePercent();
        //    CombineDigits();
        //    SwapDigits();
        //    DateStats();
        //}
    }
}