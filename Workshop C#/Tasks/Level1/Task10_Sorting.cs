using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task10_Sorting : ITask
    {
        public string Title => "Сортировка пузырьком + вставками";
        public string Description => "Отсортировать массив двумя алгоритмами и замерить время.";
        public string[] Requirements => new[]
        {
            "Реализовать BubbleSort и InsertionSort отдельными методами.",
            "Оба — без LINQ и Array.Sort.",
            "Замерить время каждого через Stopwatch на массиве 10 000 элементов.",
            "Вывести оба времени."
        };

        public void Run()
        {
            const int size = 10000;
            var rnd = new Random();

            int[] originalArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                originalArray[i] = rnd.Next(1, 1000);
            }

            int[] arrayForBubble = (int[])originalArray.Clone();
            int[] arrayForInsertion = (int[])originalArray.Clone();

            var swB = Stopwatch.StartNew();
            BubbleSort(arrayForBubble);
            swB.Stop();

            var swI = Stopwatch.StartNew();
            InsertionSort(arrayForInsertion);
            swI.Stop();

            Console.WriteLine($"Размер массива: {size}");
            Console.WriteLine($"Время пузырька: {swB.ElapsedMilliseconds} мс."); // Исправлено!
            Console.WriteLine($"Время вставками: {swI.ElapsedMilliseconds} мс.");

            bool isSame = true;
            for (int i = 0; i < size; i++)
            {
                if (arrayForBubble[i] != arrayForInsertion[i])
                {
                    isSame = false;
                    break;
                }
            }

            Console.WriteLine(isSame
                ? "\nПроверка пройдена: оба массива отсортированы идентично."
                : "\nОшибка: массивы отличаются!");
        }

        private void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        private void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }
}