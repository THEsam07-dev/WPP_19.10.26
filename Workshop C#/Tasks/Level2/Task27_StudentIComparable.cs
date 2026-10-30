using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task27_StudentIComparable : ITask
    {
        public string Title => "IComparable / IComparer<T> для Student";
        public string Description => "Научить Student сортироваться двумя разными способами.";
        public string[] Requirements => new[]
        {
            "Класс Student: Name, AverageGrade.",
            "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию).",
            "Реализовать IComparer<Student> ByNameComparer — сортировка по имени.",
            "Продемонстрировать обе сортировки на List<Student>."
        };
        public void Run()
        {
            List<Student> students = new List<Student>
            {
                new Student("Мария", 5.0),
                new Student("Александр", 3.2),
                new Student("Кирилл", 4.2), 
                new Student("Полина", 3.9),
                new Student("Макар", 4.4),
                new Student("Ульяна", 3.8),
                new Student("Максим", 4.3),
                new Student("Захар", 3.3)
            };
            Console.WriteLine("Исходный список студентов");
            PrintList(students);

            //через IComparable
            students.Sort();

            Console.WriteLine("\nСортировка 1 - По среднему баллу (по убыванию)");
            Console.WriteLine("(Использован метод students.Sort() и IComparable)");
            PrintList(students);

            //через IComparer
            students.Sort(new ByNameComparer());

            Console.WriteLine("\nСортировка 2 - По имени (в алфавитном порядке)");
            Console.WriteLine("(Использован students.Sort(new ByNameComparer()) и IComparer)");
            PrintList(students);
        }
        private void PrintList(List<Student> students)
        {
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
        }
        public class Student : IComparable<Student>
        {
            public string Name { get; set; }
            public double AverageGrade { get; set; }

            public Student(string name, double averageGrade)
            {
                Name = name;
                AverageGrade = averageGrade;
            }
            public int CompareTo(Student other)
            {
                if (other == null) return 1;

                int result = other.AverageGrade.CompareTo(this.AverageGrade);

                if (result == 0)
                {
                    return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
                }

                return result;
            }
            public override string ToString()
            {
                return $"Студент: {Name,-10} | Средний балл: {AverageGrade:F1}";
            }
        }
        public class ByNameComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;
                
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);//по алфавиту
            }
        }
    }
}
