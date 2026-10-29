using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level3
{
    public class Task37_MemoizingFibonacci : ITask
    {
        public string Title => "Мемоизация Фибоначчи через Dictionary";
        public string Description => "Рреализовать мемоизированную функцию Фибоначчи.";
        public string[] Requirements => new[]
        {
            "Обычная рекурсивная версия (для сравнения на маленьком N).",
            "Мемоизированная версия с Dictionary<int, long>.",
            "Замерить время обеих на N = 30–35 через Stopwatch.",
            "Вывести оба времени и разницу."
        };
        public void Run()
        {
            const int n = 35;//н-константа по тз

            Console.WriteLine("Сравнение рекурсивной и мемоизированной Фибоначчи");
            Console.WriteLine($"N-константа = {n}");
            Console.WriteLine();

            //stopwatch + баз. рекурсия 
            Stopwatch sw = Stopwatch.StartNew();
            long plainRes = FibonacciPlain(n);
            sw.Stop();
            TimeSpan plainT = sw.Elapsed;

            Console.WriteLine($"Обычная рекурсия:F({n}) = {plainRes}, время = {plainT.TotalMilliseconds:F2} мс");

            //мемо версия 
            var trove = new Dictionary<int, long>();

            sw.Restart();
            long memoRes = FibonacciMemo(n, trove);
            sw.Stop();
            TimeSpan memoT = sw.Elapsed;

            Console.WriteLine($"Мемоизация (Dictionary): F({n}) = {memoRes}, время = {memoT.TotalMilliseconds:F2} мс");
            Console.WriteLine();

            //разница
            double speedup = memoT.TotalMilliseconds > 0 ? plainT.TotalMilliseconds / memoT.TotalMilliseconds : double.PositiveInfinity;

            Console.WriteLine("Сравнение");
            Console.WriteLine($"Разница во времени: {plainT.TotalMilliseconds - memoT.TotalMilliseconds:F2} мс");
            Console.WriteLine($"Мемоизация быстрее в {speedup:F1} раз(а)");
            Console.WriteLine($"Результаты совпадают: {plainRes == memoRes}");
        }
        
        private static long FibonacciPlain(int n)//рекурсия фибоначчи без кэша 
        {
            if (n <= 1) return n;
            return FibonacciPlain(n - 1) + FibonacciPlain(n - 2);
        }
        private static long FibonacciMemo(int n, Dictionary<int, long> trove)//фибоначчи со словарем
        {
            if (n <= 1) return n;
            if (trove.TryGetValue(n, out long troved)) return troved;
            long result = FibonacciMemo(n - 1, trove) + FibonacciMemo(n - 2, trove);
            trove[n] = result;
            return result;
        }
    }
}
