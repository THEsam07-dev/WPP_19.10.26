using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task18_TryParseVsTryCatch : ITask
    {
        public string Title => "TryParse vs try/catch";
        public string Description => "Сравнить два способа обработки некорректного ввода числа.";
        public string[] Requirements => new[]
        {
            "Способ 1: int.TryParse — вернуть bool + значение через out",
            "Способ 2: int.Parse внутри try/catch — ловить FormatException.",
            "Оба оформить отдельными методами.",
            "Продемонстрировать на корректном и некорректном вводе."
        };
        public void Run()
        {
            string[] inputs = { "123", "abc" };

            foreach (var input in inputs)
            {
                Console.WriteLine($"Ввод: \"{input}\"");

                //способ 1
                if (TryParseMethod(input, out int resultTryParse))
                    Console.WriteLine($"TryParse: успешно, значение = {resultTryParse}");
                else 
                    Console.WriteLine($"TryParse: ошибка преобразования");
                
                //способ 2
                try
                {
                    int resultTryCatch = TryCatchMethod(input);
                    Console.WriteLine($"try/catch: успешно, значение = {resultTryCatch}");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"try/catch: ошибка преобразования (пойман FormatException)");
                }
            }
        }
                
        public static bool TryParseMethod(string input, out int result)
        {
            return int.TryParse(input, out result);
        }
        public static int TryCatchMethod(string input)
        {
            return int.Parse(input);
        }
    }
}
