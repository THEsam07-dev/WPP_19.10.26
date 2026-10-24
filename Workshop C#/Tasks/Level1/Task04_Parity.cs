using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task04_Parity : ITask
    {
        public string Title => "Чётность числа (два способа)";
        public string Description => "Определить, чётное ли введённое число.";
        public string[] Requirements => new[]
        {
            "Способ 1: через % 2 == 0.",
            "Способ 2: через тернарный оператор ? :.",
            "Оба способа реализовать отдельными методами."
        };

        public void Run()
        {
            int num = ParityNumInput("Введите целое число: ");

            ParityNumPercent(num);
            ParityNumByQuestion(num);
        }

        private int ParityNumInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }
        }

        private void ParityNumPercent(int a)
        {
            Console.Write("Способ 1 (if-else): ");
            if (a % 2 == 0)
            {
                Console.WriteLine($"{a} - четное");
            }
            else
            {
                Console.WriteLine($"{a} - нечетное");
            }
        }

        private void ParityNumByQuestion(int a)
        {
            Console.Write("Способ 2 (?:): ");
            string result = (a % 2 == 0) ? $"{a} - чётное" : $"{a} - нечётное";
            Console.WriteLine(result);
        }
    }
}
