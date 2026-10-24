using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task09_ArrayStats : ITask
    {
        public string Title => "Массивы: min/max/sum/avg";
        public string Description => "Для массива чисел найти минимум, максимум, сумму и среднее.";
        public string[] Requirements => new[]
        {
            "Заполнить массив (например, случайными числами 1–100, размер 20).",
            "Реализовать без LINQ (Min/Max/Sum/Average запрещены).",
            "Оформить 4 отдельных метода.",
            "Пустой массив — обработать (вернуть ошибку или 0, но не падать)."
        };

        public void Run()
        {
            int[] numbers = new int[20];
            var rnd = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(1, 101);
            }

            Console.WriteLine("Массив: " + string.Join(", ", numbers));
            Console.WriteLine($"Минимум: {GetMin(numbers)}");
            Console.WriteLine($"Максимум: {GetMax(numbers)}");
            Console.WriteLine($"Сумма: {GetSum(numbers)}");
            Console.WriteLine($"Среднее: {GetAvg(numbers):F3}");
        }

        private int GetMin(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] < min) min = arr[i];
            return min;
        }

        private int GetMax(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max) max = arr[i];
            return max;
        }

        private long GetSum(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            long sum = 0;
            for (int i = 0; i < arr.Length; i++) sum += arr[i];
            return sum;
        }

        private double GetAvg(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            return (double)GetSum(arr) / arr.Length;
        }
    }
}