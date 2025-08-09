using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCS
{
    public class MusicalInstrument
    {
        protected string name;
        protected string characteristics;

        public MusicalInstrument(string name, string characteristics)
        {
            this.name = name;
            this.characteristics = characteristics;
        }

        public virtual void Sound()
        {
            Console.WriteLine($"{name} издает звук");
        }

        public virtual void Show()
        {
            Console.WriteLine($"Музыкальный инструмент: {name}");
        }

        public virtual void Desc()
        {
            Console.WriteLine($"Описание {name}: {characteristics}");
        }

        public virtual void History()
        {
            Console.WriteLine($"История создания {name}: информация отсутствует");
        }
    }

    public class Violin : MusicalInstrument
    {
        public Violin() : base("Скрипка", "Струнный смычковый инструмент с четырьмя струнами")
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Скрипка издает мелодичный звук: ♪♫♪");
        }

        public override void History()
        {
            Console.WriteLine("История создания скрипки: появилась в XVI веке в Италии, усовершенствована мастерами Страдивари и Гварнери");
        }
    }

    public class Trombone : MusicalInstrument
    {
        public Trombone() : base("Тромбон", "Медный духовой инструмент с выдвижной кулисой")
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Тромбон издает мощный звук: ♪♩♪♩");
        }

        public override void History()
        {
            Console.WriteLine("История создания тромбона: развился из сакбута в XV веке, широко используется в оркестрах и джазе");
        }
    }

    public class Ukulele : MusicalInstrument
    {
        public Ukulele() : base("Укулеле", "Четырехструнный щипковый инструмент гавайского происхождения")
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Укулеле издает легкий звук: ♪♬♪♬");
        }

        public override void History()
        {
            Console.WriteLine("История создания укулеле: появилась на Гавайях в XIX веке под влиянием португальских иммигрантов");
        }
    }

    public class Cello : MusicalInstrument
    {
        public Cello() : base("Виолончель", "Струнный смычковый инструмент, больше скрипки, играют сидя")
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Виолончель издает глубокий звук: ♫♪♫♪");
        }

        public override void History()
        {
            Console.WriteLine("История создания виолончели: развилась в XVI веке в Италии как басовая скрипка");
        }
    }

    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateArea()
        {
            return width * height;
        }
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }

    public class RightTriangle : Shape
    {
        private double leg1;
        private double leg2;

        public RightTriangle(double leg1, double leg2)
        {
            this.leg1 = leg1;
            this.leg2 = leg2;
        }

        public override double CalculateArea()
        {
            return 0.5 * leg1 * leg2;
        }
    }

    public class Trapezoid : Shape
    {
        private double base1;
        private double base2;
        private double height;

        public Trapezoid(double base1, double base2, double height)
        {
            this.base1 = base1;
            this.base2 = base2;
            this.height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * (base1 + base2) * height;
        }
    }

    internal class homework5
    {
        static void Main(string[] args)
        {
            MusicalInstrument[] instruments = {
                new Violin(),
                new Trombone(),
                new Ukulele(),
                new Cello()
            };

            foreach (MusicalInstrument instrument in instruments)
            {
                instrument.Show();
                instrument.Desc();
                instrument.Sound();
                instrument.History();
                Console.WriteLine(new string('-', 50));
            }

            Shape[] shapes = {
                new Rectangle(5, 3),
                new Circle(4),
                new RightTriangle(6, 8),
                new Trapezoid(4, 6, 3)
            };

            Console.WriteLine("Вычисление площадей различных фигур:");

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"{shape.GetType().Name}: Площадь = {shape.CalculateArea():F2}");
            }

            Console.ReadKey();
        }
    }
}