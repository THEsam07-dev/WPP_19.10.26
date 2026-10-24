using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task07_StringReverse : ITask
    {
        public string Title => "Реверс строки без LINQ";
        public string Description => "Перевернуть введённую строку.";
        public string[] Requirements => new[]
        {
            "Не использовать Array.Reverse и LINQ.",
            "Реализовать через цикл for от конца к началу (или через char[] и swap).",
            "Пустая строка и строка из одного символа — обрабатываются корректно."
        };

        public void Run()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine() ?? string.Empty;

            char[] mas = input.ToCharArray();
            int left = 0;
            int right = mas.Length - 1;

            while (left < right)
            {
                char temp = mas[left];
                mas[left] = mas[right];
                mas[right] = temp;

                left++;
                right--;
            }
            string result = new string(mas);

            Console.WriteLine($"Реверс: \"{result}\"");
        }
    }
}
