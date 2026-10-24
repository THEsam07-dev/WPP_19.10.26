using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task01_HelloWorld : ITask
    {
        public string Title => "Hello, World + текущая дата";

        public string Description => "Вывести приветствие и текущую дату.";

        public string[] Requirements => new[]
        {
            "Использовать Console.WriteLine.",
            "Дату получить через DateTime.Now, отформатировать как dd.MM.yyyy.",
            "Вывести две строки: приветствие и дату."
        };

        public void Run()
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine($"Сегодня: {DateTime.Now:dd.MM.yyyy}");
        }
    }
}
