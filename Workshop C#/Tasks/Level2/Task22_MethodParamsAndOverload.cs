using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task22_MethodParamsAndOverload : ITask
    {
        public string Title => "params-метод + перегрузка";
        public string Description => "Написать метод суммы с `params` и его перегрузку.";
        public string[] Requirements => new[]
        {
            "Sum(params int[] numbers) — сумма произвольного числа чисел.",
            "Перегрузка Sum(int[] numbers) — та же логика для массива.",
            "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum().",
            "Пустой вызов — вернуть 0."
        };        
        public void Run()
        {
            Console.WriteLine("=== тестирование params и перегрузок ===\n");

            //params
            int result1 = Sum(1, 2, 3);
            Console.WriteLine($"Sum(1, 2, 3) = {result1}");

            //передача готового массива
            int[] array = { 1, 2, 3 };
            int result2 = Sum(array);
            Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {result2}");

            //вызов с пустыми аргументами
            int result3 = Sum();
            Console.WriteLine($"Sum() = {result3}");

            //перегрузка 
            var list = new List<int> { 4, 5, 6 };
            int result4 = Sum(list);
            Console.WriteLine($"Sum(List<int> {{4, 5, 6}}) = {result4}");

            Console.WriteLine($"\nРезультаты 1 и 2 совпадают: {result1 == result2}");
        }
        //осн метод params
        public static int Sum(params int[] numbers)
        {
            if (numbers == null)return 0;

            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            return total;
        }
        //демонстрация перегрузки (без ошибки CS0111 из-за одинаковой структуры)
        public static int Sum(IEnumerable<int> numbers)//IEnumerable<int> -- из-за конфликта с params
        {
            if (numbers == null) return 0;

            int total = 0;
            foreach (int num in numbers)
            {
                total += num;   
            }
            return total;
        }
    }
}
