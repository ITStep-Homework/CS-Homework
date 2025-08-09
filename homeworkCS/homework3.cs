using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Wonders;

namespace HomeworkCS
{
    internal class homework3
    {
        public enum PayType
        {
            cash,
            card,
            transfer,
            eWallet,
            cryptoWallet
        }

        public struct Client
        {
            public int clientCode;
            public string fullName;
            public string address;
            public string phoneNumber;
            public int totalOrders;
            public double totalAmount;
        }

        public struct OrderItem
        {
            public string title;
            public double price;
        }

        public struct Request
        {
            public int requestCode;
            public Client client;
            public DateTime date;
            public List<OrderItem> orderItems;
            public PayType payType;
            public double amount
            {
                get
                {
                    double sum = 0;
                    if (orderItems != null)
                    {
                        foreach (var item in orderItems)
                        {
                            sum += item.price;
                        }
                    }
                    return sum;
                }
            }
        }



        // 4th task
        public class Student
        {
            public string lastName;
            public string firstName;
            public string middleName;
            public int age;
            public string group;
            public int[][] grades;

            public Student()
            {
                grades = new int[3][];
                grades[0] = new int[0];
                grades[1] = new int[0];
                grades[2] = new int[0];
            }

            public void SetGrade(int subject, int grade)
            {
                if (subject >= 0 && subject < 3 && grade >= 2 && grade <= 5)
                {
                    Array.Resize(ref grades[subject], grades[subject].Length + 1);
                    grades[subject][grades[subject].Length - 1] = grade;
                }
            }

            public int[] GetGrades(int subject)
            {
                if (subject >= 0 && subject < 3)
                {
                    return grades[subject];
                }
                return new int[0];
            }

            public double GetAverageGrade(int subject)
            {
                if (subject >= 0 && subject < 3 && grades[subject].Length > 0)
                {
                    double sum = 0;
                    foreach (int grade in grades[subject])
                    {
                        sum += grade;
                    }
                    return sum / grades[subject].Length;
                }
                return 0;
            }

            public void PrintStudentInfo()
            {
                Console.WriteLine($"ФИО: {lastName} {firstName} {middleName}");
                Console.WriteLine($"Группа: {group}");
                Console.WriteLine($"Возраст: {age}");
                Console.WriteLine("Оценки:");
                string[] subjects = { "Программирование", "Администрирование", "Дизайн" };

                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{subjects[i]}: ");
                    if (grades[i].Length > 0)
                    {
                        foreach (int grade in grades[i])
                        {
                            Console.Write($"{grade} ");
                        }
                        Console.WriteLine($"(Средний балл: {GetAverageGrade(i):F2})");
                    }
                    else
                    {
                        Console.WriteLine("Нет оценок");
                    }
                }
            }
        }


        // 5th task
        public static void WorldWonders()
        {
            Console.WriteLine("7 чудес света:\n");

            new GreatPyramid().ShowInfo();
            new HangingGardens().ShowInfo();
            new StatueOfZeus().ShowInfo();
            new TempleOfArtemis().ShowInfo();
            new MausoleumAtHalicarnassus().ShowInfo();
            new ColossusOfRhodes().ShowInfo();
            new LighthouseOfAlexandria().ShowInfo();
        }

        //static void Main(string[] args)
        //{
        //    WorldWonders();
        //}
    }
}
