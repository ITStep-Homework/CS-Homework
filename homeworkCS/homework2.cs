using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeworkCS
{
    internal class homework2
    {
        public static void SumMinToMax()
        {
            int[,] array = new int[5, 5];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    array[i, j] = random.Next(-100, 101);

            Console.WriteLine("Массив:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write($"{array[i, j],5} ");
                Console.WriteLine();
            }

            int min = array[0, 0];
            int max = array[0, 0];
            int minRow = 0, minCol = 0;
            int maxRow = 0, maxCol = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minRow = i;
                        minCol = j;
                    }
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            int minIndex = minRow * 5 + minCol;
            int maxIndex = maxRow * 5 + maxCol;
            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);

            int sum = 0;
            for (int index = start + 1; index < end; index++)
                sum += array[index / 5, index % 5];

            Console.WriteLine($"\nМинимальный элемент: {min} в позиции [{minRow}, {minCol}]");
            Console.WriteLine($"Максимальный элемент: {max} в позиции [{maxRow}, {maxCol}]");
            Console.WriteLine($"Сумма элементов между минимальным и максимальным: {sum}");

            Console.ReadKey();
        }

        public static void CaesarCipher()
        {
            string Encrypt(string text, int key)
            {
                string result = "";
                foreach (char c in text)
                {
                    if (char.IsLetter(c))
                    {
                        char baseChar = char.IsUpper(c) ? 'A' : 'a';
                        result += (char)((c - baseChar + key) % 26 + baseChar);
                    }
                    else
                    {
                        result += c;
                    }
                }
                return result;
            }

            string Decrypt(string text, int key)
            {
                return Encrypt(text, 26 - key);
            }

            Console.WriteLine("Выберите режим: 1 - Шифрование, 2 - Расшифровка");
            string mode = Console.ReadLine();

            Console.WriteLine("Введите текст:");
            string inputText = Console.ReadLine();

            Console.WriteLine("Введите сдвиг (1-25):");
            if (!int.TryParse(Console.ReadLine(), out int shift) || shift < 1 || shift > 25)
            {
                Console.WriteLine("Ошибка: сдвиг должен быть числом от 1 до 25.");
                return;
            }

            if (mode == "1")
            {
                string encrypted = Encrypt(inputText, shift);
                Console.WriteLine($"Зашифрованный текст: {encrypted}");
            }
            else if (mode == "2")
            {
                string decrypted = Decrypt(inputText, shift);
                Console.WriteLine($"Расшифрованный текст: {decrypted}");
            }
            else
            {
                Console.WriteLine("Ошибка: выбран неверный режим.");
            }

            Console.ReadKey();
        }

        public static void EvaluateExpression()
        {
            Console.WriteLine("Введите выражение (+ и -):");
            string input = Console.ReadLine().Replace(" ", "");
            var matches = Regex.Matches(input, @"[+-]?\d+");

            int result = 0;
            foreach (Match m in matches)
                result += int.Parse(m.Value);

            Console.WriteLine($"Результат: {result}");
            Console.ReadKey();
        }

        public static void CapitalizeSentences()
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();

            var sb = new StringBuilder(text.Length);
            bool newSentence = true;

            foreach (char c in text)
            {
                if (newSentence && char.IsLetter(c))
                {
                    sb.Append(char.ToUpper(c));
                    newSentence = false;
                }
                else
                {
                    sb.Append(c);
                }

                if (c == '.' || c == '!' || c == '?')
                {
                    newSentence = true;
                }
            }

            Console.WriteLine("\nРезультат:");
            Console.WriteLine(sb.ToString());

            Console.ReadKey();
        }

        public static void CensorText()
        {
            Console.WriteLine("Введите текст (пустая строка для завершения ввода):");
            string text = "";
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                text += line + "\n";
            }

            Console.WriteLine("Введите недопустимое слово:");
            string badWord = Console.ReadLine();

            string pattern = $@"\b{Regex.Escape(badWord)}\b";
            int count = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
            string replacement = new string('*', badWord.Length);
            string censored = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);

            Console.WriteLine("\nРезультат работы:");
            Console.WriteLine(censored);
            Console.WriteLine($"Статистика: {count} замены слова \"{badWord}\".");

            Console.ReadKey();
        }

        //static void Main(string[] args)
        //{
            //SumMinToMax();
            //CaesarCipher();
            //EvaluateExpression();
            //CapitalizeSentences();
            //CensorText();
        //}
    }
}