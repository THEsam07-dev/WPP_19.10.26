using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;
using Workshop_C_.Tasks.Level1;

namespace Workshop_C_.Menu
{
    public class MenuRunner
    {
        private readonly List<ITask> _level1Tasks;

        public MenuRunner()
        {
            _level1Tasks = new List<ITask>
            {
                new Task01_HelloWorld(),
                new Task02_Primitives(),
                new Task03_Calculator(),
                new Task04_Parity(),
                new Task05_MultiplicationTable(),
                new Task06_SumOfDigits(),
                new Task07_StringReverse(),
                new Task08_FizzBuzz(),
                new Task09_ArrayStats(),
                new Task10_Sorting(),
                new Task11_MatrixDiagonal(),
                new Task12_Palindrome(),
                new Task13_WordCounter(),
                new Task14_AgeCalculator()
            };
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Практикум по C# ===");
                Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
                Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
                Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите уровень: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": RunLevel1(); break;
                    case "2": Console.WriteLine("В разработке..."); ConsoleHelper.Pause(); break;
                    case "3": Console.WriteLine("В разработке..."); ConsoleHelper.Pause(); break;
                    case "0": running = false; break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        ConsoleHelper.Pause();
                        break;
                }
            }
        }

        private void RunLevel1()
        {
            bool inLevel = true;
            while (inLevel)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 1: Базовый ---");

                for (int i = 0; i < _level1Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_level1Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string input = Console.ReadLine();
                if (input == "0") { inLevel = false; continue; }

                if (int.TryParse(input, out int taskNum) && taskNum > 0 && taskNum <= _level1Tasks.Count)
                {
                    var task = _level1Tasks[taskNum - 1];

                    ConsoleHelper.PrintTaskHeader(task.Title, task.Description, task.Requirements);

                    task.Run();

                    ConsoleHelper.Pause();
                }
                else
                {
                    Console.WriteLine("Такого задания нет.");
                    ConsoleHelper.Pause();
                }
            }
        }
    }
}
