using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;
using Workshop_C_.Tasks.Level1;
using Workshop_C_.Tasks.Level2;

namespace Workshop_C_.Menu
{
    public class MenuRunner
    {
        private readonly List<ITask> _level1Tasks;
        private readonly List<ITask> _level2Tasks;
        private readonly List<ITask> _level3Tasks;

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

            _level2Tasks = new List<ITask>
            {
                new Task16_SolutionMethod4String(),
                new Task17_StringBuilderVsConcatenation(),
                new Task18_TryParseVsTryCatch(),
                new Task19_StackOrQueue2Array(),
                new Task20_Generalizations(),
                new Task21_ENumWeekday(),
                new Task22_MethodParamsAndOverload(),
                new Task23_NullableTypes(),
                new Task24_OOPAnimals(),
                new Task25_IShapeInterfaceAndSorting(),
                new Task26_StrategyPattern(),
                new Task27_StudentIComparable(),
                new Task28_EqualsOrGetHashCode4Point(),
                new Task29_FactoryPattern(),
                new Task30_BankAccountAndException(),
                new Task31_IDisposableAndUsing(),
                new Task32_Temperature(),
                new Task33_LINQStaff(),
                new Task34_LINQByFirstLetter(),
                new Task35_GitDemo()
            };
            _level3Tasks = new List<ITask>
            {
                //пока пусто
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
                    case "2": RunLevel2(); break;
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
            bool inLevel1= true;
            while (inLevel1)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 1: Базовый ---");

                for (int i = 0; i < _level1Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_level1Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string input1 = Console.ReadLine();
                if (input1 == "0") { inLevel1 = false; continue; }

                if (int.TryParse(input1, out int taskNum1) && taskNum1 > 0 && taskNum1 <= _level1Tasks.Count)
                {
                    var task1 = _level1Tasks[taskNum1 - 1];

                    ConsoleHelper.PrintTaskHeader(task1.Title, task1.Description, task1.Requirements);

                    task1.Run();

                    ConsoleHelper.Pause();
                }
                else
                {
                    Console.WriteLine("Такого задания нет.");
                    ConsoleHelper.Pause();
                }
            }
        }

        private void RunLevel2()
        {
            bool inLevel2 = true;
            while(inLevel2)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 2 — Средний ---");

                for (int i = 0; i < _level2Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_level2Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string input2 = Console.ReadLine();
                if (input2 == "0") {inLevel2 = false; continue; }

                if (int.TryParse(input2, out int taskNum2) && taskNum2 > 0 && taskNum2 <= _level2Tasks.Count)
                {
                    var task2 = _level2Tasks[taskNum2 - 1];

                    ConsoleHelper.PrintTaskHeader(task2.Title, task2.Description, task2.Requirements);

                    task2.Run();

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
