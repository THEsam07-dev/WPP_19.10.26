using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task25_IShapeInterfaceAndSorting : ITask
    {
        public string Title => "Интерфейс IShape + сортировка фигур";
        public string Description => "Реализовать интерфейс фигур и отсортировать их по площади.";
        public string[] Requirements => new[]
        {
            "IShape с методами Area() и Perimeter().",
            "Классы Circle, Rectangle, Triangle — реализуют IShape.",
            "Создать List<IShape> из 5+ фигур.",
            "Отсортировать по площади (через List.Sort с лямбдой или OrderBy).",
            "Вывести фигуры с площадями до и после сортировки."
        };
        public void Run()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle(5),
                new Rectangle(2, 3),
                new Triangle(3, 4, 5),
                new Circle(1.5),
                new Rectangle(10, 0.5),
                new Triangle(5, 5, 6),
                new Circle(10),
                new Rectangle(11, 3),
                new Triangle(5, 5, 5)
            };
            Console.WriteLine("=== фигуры до сортировки ===");
            PrintShapes(shapes);
            shapes.Sort((s1, s2) => s1.Area().CompareTo(s2.Area()));

            Console.WriteLine("\n=== фигуры после сортировки (по возрастанию площади) ===");
            PrintShapes(shapes);
        }
        private void PrintShapes(List<IShape> shapes)//всп. метод для отрисовки
        {
            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape,-25} | Площадь: {shape.Area(),6:F2} | Периметр: {shape.Perimeter(),6:F2}");
            }
        }
        public interface IShape
        {
            double Area();
            double Perimeter();
        }
        public class Circle : IShape
        {
            public double Radius { get; set; }
            public Circle(double radius)
            {
                Radius = radius;
            }
            public double Area() => Math.PI * Radius * Radius;
            public double Perimeter() => 2 * Math.PI * Radius;
            public override string ToString() => $"круг (R={Radius})";
        }
        public class Rectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public double Area() => Width * Height;
            public double Perimeter() => 2 * (Width + Height);
            public override string ToString() => $"прямоугольник ({Width}x{Height})";
        }
        public class Triangle : IShape
        {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }

            public Triangle(double a, double b, double c)
            {
                A = a;
                B = b;
                C = c;
            }
            public double Area()
            {
                double p = Perimeter() / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
            public double Perimeter() => A + B + C;

            public override string ToString() => $"треугольник ({A},{B},{C})";
        }
    }
}
