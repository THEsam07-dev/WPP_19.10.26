using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task17_StringBuilderVsConcatenation : ITask
    {
        public string Title => "StringBuilder vs конкатенация (замер)";
        public string Description => "Сравнить производительность конкатенации через + и StringBuilder";
        public string[] Requirements => new[]
        {
            "Собрать строку из 10 000 (или 100 000) чисел двумя способами.",
            "Замерить время каждого через Stopwatch",
            "Вывести оба времени и разницу.",
            "Объяснить в комментарии, почему StringBuilder быстрее."
        };

        public void Run()
        {
            const int count = 100_000;
            string resultCC = "";
            var sb = new StringBuilder();

            var swConcat = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                resultCC += i;
            swConcat.Stop();

            var swSB = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                sb.Append(i);
            string resultSb = sb.ToString();
            swSB.Stop();

            bool IsComparison = resultCC == resultSb;

            Console.WriteLine($"Конкатенация (+): {swConcat.ElapsedMilliseconds} мс");
            Console.WriteLine($"StringBuilder: {swSB.ElapsedMilliseconds} мс");
            Console.WriteLine($"Разница: {swConcat.ElapsedMilliseconds - swSB.ElapsedMilliseconds} мс");
            Console.WriteLine($"Результаты равны: {IsComparison}");
            Console.WriteLine($"Длина итоговой строки: {resultCC.Length} символов");

            /* Объяснение почему StringBuilder быстрее конкатенации?
             * 1. В C# string не изменяемый тип данных и при каждом операторе в памяти создается новый объет строки и него копируются символы из старой строки + новая часть.
             * В этом цикле при каждой итерации создается новвая строка, которая еще и больше предыдущей.
             * * Что, в свою очередь, нагружает память и возрастает число обращений к сборщику мусора, что еще больше нагружает систему.
             * * 2. StringBuilder работает по-другому:
             * * - Во-первых, он имеет изменяемую последовательность символов. Т. е. он содержит внутри себя массив символов.
             * * - Во-вторых, все операции происходят внутри него без создания новых строк на каждом шаге.
             * Вывод: Отсюда и скоорось выполнения.
             */
        }
    }
}
