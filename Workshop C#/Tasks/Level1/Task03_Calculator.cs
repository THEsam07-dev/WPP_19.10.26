using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task03_Calculator : ITask
    {
        public string Title => "Калькулятор с делением на ноль";
        public string Description => "Принимать два числа и оператор (+, -, *, /), выводить результат. Обрабатывать деление на ноль.";
        public string[] Requirements => new[]
        {
            "Оператор обрабатывать через switch.",
            "При делении на ноль вывести ошибку.",
            "Некорректный оператор — «Неизвестная операция».",
            "Ввод чисел — через double.TryParse."
        };

        public void Run()
        {
            bool calc = true;
            while (calc)
            {
                Console.Clear();
                Console.WriteLine("Выберите тип операции:");
                Console.WriteLine("1. Сложение (+)");
                Console.WriteLine("2. Вычитание (-)");
                Console.WriteLine("3. Умножение (*)");
                Console.WriteLine("4. Деление (/)");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш выбор: ");

                string inputCalc = Console.ReadLine();
                if (int.TryParse(inputCalc, out int operation))
                {
                    switch (operation)
                    {
                        case 0:
                            calc = false;
                            break;
                        case 1:
                            OperationAddition();
                            break;
                        case 2:
                            OperationSubtraction();
                            break;
                        case 3:
                            OperationMultiplication();
                            break;
                        case 4:
                            OperationDivision();
                            break;
                        default:
                            Console.WriteLine("\nНеизвестная операция.");
                            ConsoleHelper.Pause();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nПожалуйста, введите число.");
                    ConsoleHelper.Pause();
                }
            }
        }

        private void OperationAddition()
        {
            double a = GetNumber("Введите первое значение (a): ");
            double b = GetNumber("Введите второе значение (b): ");
            Console.WriteLine($"\nРезультат сложения {a} + {b} = {a + b}");
            ConsoleHelper.Pause();
        }

        private void OperationSubtraction()
        {
            double a = GetNumber("Введите первое значение (a): ");
            double b = GetNumber("Введите второе значение (b): ");
            Console.WriteLine($"\nРезультат вычитания {a} - {b} = {a - b}");
            ConsoleHelper.Pause();
        }

        private void OperationMultiplication()
        {
            double a = GetNumber("Введите первое значение (a): ");
            double b = GetNumber("Введите второе значение (b): ");
            Console.WriteLine($"\nРезультат умножения {a} * {b} = {a * b}");
            ConsoleHelper.Pause();
        }

        private void OperationDivision()
        {
            double a = GetNumber("Введите первое значение (a): ");
            double b = GetNumber("Введите второе значение (b): ");

            if (b == 0)
            {
                Console.WriteLine("\nОшибка: деление на ноль невозможно.");
            }
            else
            {
                Console.WriteLine($"\nРезультат деления {a} / {b} = {a / b}");
            }
            ConsoleHelper.Pause();
        }

        private double GetNumber(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }
}
