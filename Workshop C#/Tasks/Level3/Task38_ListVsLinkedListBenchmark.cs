using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level3
{
    public class Task38_ListVsLinkedListBenchmark : ITask
    {
        public string Title => "List<T> vs LinkedList<T> (бенчмарк)";
        public string Description => "Сравнить вставку в середину List<int> и LinkedList<int> по времени.";
        public string[] Requirements => new[]
        {
            "Создать List<int> и LinkedList<int> по 100 000 элементов.",
            "Вставить 1000 элементов в середину каждой коллекции.",
            "Замерить время через Stopwatch.",
            "Вывести оба времени и объяснить результат в комментарии."
        };
        //конст.
        private const int CollectionSize = 100_000;//100к эл-то
        private const int InsertCount = 1_000;//для послед. вставки в середину кол.
        public void Run()
        {
            var theFundamental = Enumerable.Range(0, CollectionSize).ToList();
            var list = new List<int>(theFundamental);
            var linkList = new LinkedList<int>(theFundamental);
            Console.WriteLine("List<T> vs LinkedList<T>: вставка в середину");
            Console.WriteLine($"Размер коллекций: {CollectionSize:N0} элементов");
            Console.WriteLine($"Количество вставок: {InsertCount:N0}");
            Console.WriteLine();

            Stopwatch sw = Stopwatch.StartNew();
            int listMidIndex = list.Count / 2;
            for (int i = 0; i < InsertCount; i++)
            {
                list.Insert(listMidIndex, -1);
            }
            sw.Stop();
            TimeSpan listTS = sw.Elapsed;

            sw.Restart();

            LinkedListNode<int> midNode = linkList.First;
            for (int i = 0; i < CollectionSize / 2 && midNode != null; i++)
            {
                midNode = midNode.Next; 
            }
            for (int i = 0; i < InsertCount; i++) 
            {
                linkList.AddAfter(midNode, -1);
            }
            sw.Stop();
            TimeSpan linkListTS = sw.Elapsed;

            Console.WriteLine($"List<int>:{listTS.TotalMilliseconds,10:F3} мс (итоговый размер: {list.Count:N0})");
            Console.WriteLine($"LinkedList<int>:{linkListTS.TotalMilliseconds,10:F3} мс (итоговый размер:{linkList.Count:N0})");
            Console.WriteLine();

            double speed = linkListTS.TotalMilliseconds > 0 ? listTS.TotalMilliseconds / linkListTS.TotalMilliseconds : double.PositiveInfinity;

            Console.WriteLine("Сравнение");
            Console.WriteLine($"Разница во времени: {listTS.TotalMilliseconds - linkListTS.TotalMilliseconds:F3} мс");
            Console.WriteLine($"LinkedList быстрее примерно в {speed:F1} раз(а)");
            Console.WriteLine();
            /* трактовка результатов в виде комментариев
             * List<T> -  являясь динамическими объектом требует сдвига всех лелементов на n (длину вставки(конкретно 1к)) при вставки в свою середину.
             * Вставка 1000 раз в середину дает около 50 млн операций перемещения = около 5 к мс.
             * 
             * LinkedList<T> - по сути своей все тот же список, но двусвязный, те элемент модержит ссылку не только на следующий элемент, но и на предидущий, что в свою очередь позволяет перемещаться по списку в 2х направлениях.
             * Если нужный узел найден (AddAfter - 0(1)) без сдвига и вставка выполняется очень бысто тк одна врямязатратная операция и все 1000 идут за 0(1).
             * 
             * ВЫВОД: LinkedList быстрее тк не сдвигает 50к элементов 
             */
        }
    }
}
