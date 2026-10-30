using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task33_LINQStaff : ITask
    {
        public string Title => "LINQ: сотрудники (top-3, avg по отделу, фильтр)";
        public string Description => "LINQ-запросы по списку сотрудников.";
        public string[] Requirements => new[]
        {
            "- Класс Employee: Name, Age, Salary, Department.",
            "- Список из 10+ сотрудников.",
            "- Запросы через LINQ: топ-3 по зарплате, средняя зарплата по каждому отделу, сотрудники старше 30.",
            "- Вывести результаты."
        };
        public void Run()
        {
            List<Staff> staff = new List<Staff>
            {
                new Staff("Виктор", 79, 70000m, "Design"),
                new Staff("Дмитрий", 35, 120000m, "Design"),
                new Staff("Анна", 42, 45000m, "HR"),
                new Staff("Мария", 25, 60000m, "Marketing"),
                new Staff("Борис", 31, 150000m, "Front"),
                new Staff("Елена", 45, 110000m, "Front"),
                new Staff("Алексей", 22, 45000m, "Back"),
                new Staff("Ольга", 38, 85000m, "Back"),
                new Staff("Сергей", 29, 70000m, "Back"),
                new Staff("Татьяна", 33, 130000m, "Sales"),
                new Staff("Павел", 50, 100000m, "Test"),
                new Staff("Ксения", 27, 55000m, "Test")
            };
            Console.WriteLine("Топ-3 сотрудника по зарплате");
            var top3Salaries = staff
                .OrderByDescending(e => e.Salary)
                .Take(3);
            foreach (var emp in top3Salaries)
            {
                Console.WriteLine($"{emp.Name,-10} | Зарплата: {emp.Salary:C} | Отдел: {emp.Department}");
            }
            Console.WriteLine();
            Console.WriteLine("Средняя зарплата по отделам");
            var avgByDept = staff
                .GroupBy(e => e.Department)
                .Select(group => new
                {
                    Department = group.Key,
                    AverageSalary = group.Average(e => e.Salary),
                    EmployeeCount = group.Count()
                })
                .OrderByDescending(x => x.AverageSalary);

            foreach (var dept in avgByDept)
            {
                Console.WriteLine($"{dept.Department,-12} | Средняя ЗП: {dept.AverageSalary:C} | Сотрудников: {dept.EmployeeCount}");
            }
            Console.WriteLine();

            Console.WriteLine("Сотрудники старше 30 лет");
            var olderThan30 = staff
                .Where(e => e.Age > 30)
                .OrderBy(e => e.Age);
            foreach (var emp in olderThan30)
            {
                Console.WriteLine($"{emp.Name,-10} | Возраст: {emp.Age} | Зарплата: {emp.Salary:C}");
            }
        }
        //класс сотрудник 
        public class Staff
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }
            public string Department { get; set; }
            public Staff(string name, int age, decimal salary, string department)
            {
                Name = name;
                Age = age;
                Salary = salary;
                Department = department;
            }
        }
    }
}
