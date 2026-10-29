using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level3
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
    public class Task43_MultipleTypesOfExceptions : ITask
    {
        public string Title => "Множественные типы исключений, порядок catch";
        public string Description => "Продемонстрировать порядок обработки исключений: FormatException, DivideByZeroException, CustomException.";
        public string[] Requirements => new[]
        {
            "Метод, который может бросить FormatException, DivideByZeroException или свой CustomException.",
            "Несколько catch-блоков в правильном порядке (от частного к общему).",
            "Продемонстрировать все три сценария.",
            "В конце — finally с выводом «завершено».",
            "Объяснить в комментарии, почему порядок catch важен."
        };
        public void Run()
        {
            Console.WriteLine("Демонстрация порядка обработки исключений");
            Console.WriteLine();

            //formatException
            Console.WriteLine("Сценарий 1 - Неверный формат строки");
            ProcessData("не_число", 2);
            Console.WriteLine();

            //divideByZeroException
            Console.WriteLine("Сценарий 2 - Деление на ноль");
            ProcessData("10", 0);
            Console.WriteLine();

            //customException
            Console.WriteLine("Сценарий 3 - Кастомная ошибка");
            ProcessData("custom_error", 2);
            Console.WriteLine();
        }
        private void ProcessData(string text, int divisor)//метод по входным данным определяет тип исключения
        {
            try
            {
                if (text == "custom_error")//кастомная ошибка
                {
                    throw new CustomException("Произошла специфическая кастомная ошибка!");
                }
                int number = int.Parse(text);
                int result = number / divisor;
                Console.WriteLine($"Результат: {number} / {divisor} = {result}");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"[Перехвачено CustomException]: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[Перехвачено FormatException]: Строка '{text}' не является числом. Детали: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"[Перехвачено DivideByZeroException]: Попытка деления на ноль. Детали: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Перехвачено Exception]: Неизвестная ошибка. Детали: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("завершено");
            }
        }
    }
}
