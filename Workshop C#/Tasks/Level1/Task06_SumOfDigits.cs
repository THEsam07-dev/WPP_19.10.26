using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task06_SumOfDigits : ITask
    {
        public string Title => "Сумма цифр числа (строка + арифметика)";
        public string Description => "Найти сумму цифр введённого числа (например, 1234 → 10).";
        public string[] Requirements => new[]
        {
            "Способ 1 (строка): число → ToString() → пройти по символам → int.Parse каждой цифры.",
            "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }.",
            "Оба способа оформить отдельными методами.",
            "Отрицательные числа — брать модуль."
        };

        public void Run()
        {
            Console.WriteLine("Введите целое число:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Ошибка: введено некорректное число.");
                return;
            }

            int sumString = SumString(number);
            int sumMath = SumMath(number);

            Console.WriteLine($"\nВведено число: {number}");
            Console.WriteLine($"Через строку: {sumString}");
            Console.WriteLine($"Через арифметику: {sumMath}");

            if (sumString == sumMath)
                Console.WriteLine("Решения совпадают.");
            else
                Console.WriteLine("Решения НЕ совпадают.");
        }

        private int SumString(int n)
        {
            n = Math.Abs(n);
            string numberStr = n.ToString();
            int sum = 0;

            foreach (char c in numberStr)
            {
                sum += int.Parse(c.ToString());
            }
            return sum;
        }

        private int SumMath(int n)
        {
            n = Math.Abs(n);
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
