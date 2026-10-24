using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task11_MatrixDiagonal : ITask
    {
        public string Title => "Диагональ матрицы N×N";
        public string Description => "Найти сумму элементов главной диагонали матрицы N×N.";
        public string[] Requirements => new[]
        {
            "Размер N вводится пользователем (минимум 2).",
            "Матрица заполняется случайными числами.",
            "Сумма считается без LINQ, в одном цикле for.",
            "Вывести саму матрицу и сумму."
        };

        public void Run()
        {
            int n;
            while (true)
            {
                Console.Write("Введите размер матрицы N (минимум 2): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out n) && n >= 2)
                {
                    break;
                }
                Console.WriteLine("Некорректный ввод! Введите целое число >= 2.");
            }

            int[,] matrix = new int[n, n];
            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(1, 100);
                }
            }

            Console.WriteLine($"\nМатрица {n}x{n}:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }

            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine($"\nСумма элементов главной диагонали: {sum}");
        }
    }
}
