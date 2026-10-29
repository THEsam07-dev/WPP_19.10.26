using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level3
{
    public class Task36_DuplicatesList : ITask
    {
        public string Title => "Дубликаты в List (HashSet + GroupBy)";
        public string Description => "Найти дубликаты в списке чисел двумя способами.";
        public string[] Requirements => new[]
        {
            "Способ 1: HashSet<int> — при добавлении проверять Contains.",
            "Способ 2: LINQ GroupBy(x => x).Where(g => g.Count() > 1).",
            "Оба способа оформить отдельными методами.",
            "Продемонстрировать на списке с повторяющимися значениями.",
            "Оба метода возвращают одинаковый набор дубликатов."
        };
        public void Run()
        {
            List<int> numbers = new List<int>
            {
                0,//хали
                32,//аарон нисмет
                4,//мобли 
                20,//саня сарр
                5,//эдвардс
                13,//бэм адебайо
                25,//бэн симмонс
                9,//бэн марурин
                14,//уокер кесслер
                24,//брендон миллер
                28,//брайс сэнсабо
                2,//кейд каннингем
                16,//калеб мартин
                8,//люк кеннард
                23,//седрик ковард
                7,//чет холмгерн
                30,//клинт капела
                3,//дейзи бейн
                15,//букер
                55,//данкан робертсон
                10,//джабари смит
                19,//якоб пёльтель
                27,//джамал мюррей
                1,//харден
                31,//джаррет аллен
                21,//эмбид
                25,//марк уильямс
                45,//майк конли
                22,//майлз бриджес
                11,//райн калкбреннер
                13,//мо вагнер
                17,//оконгву
                43,//паскаль сиакам
                13,//пол джордж
                44,//партик уильямс
                27,//руди гобер
                28,//руи хатимура
                12,//стивен адамс
            };

            Console.WriteLine("=== Исходный список чисел ===");
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine();

            var duplicatesByHashSet = FindDuplicatesWithHashSet(numbers);
            var duplicatesByLinq = FindDuplicatesWithLinq(numbers);

            Console.WriteLine("Способ 1 черех HashSet");
            Console.WriteLine(duplicatesByHashSet.Count > 0 ? string.Join(", ", duplicatesByHashSet.OrderBy(n => n)) : "Дубликатов нет");
            Console.WriteLine();

            Console.WriteLine("Способ 2 через LINQ GroupBy");
            Console.WriteLine(duplicatesByLinq.Count > 0 ? string.Join(", ", duplicatesByLinq.OrderBy(n => n)) : "Дубликатов нет");
            Console.WriteLine();

            Console.WriteLine("Частота повторов через LINQ");
            var groups = numbers.GroupBy(x => x).Where(g => g.Count() > 1).OrderBy(g => g.Key);

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key} — {group.Count()} раз(а)");
            }
            Console.WriteLine();

            bool sameSet = new HashSet<int>(duplicatesByHashSet).SetEquals(duplicatesByLinq);

            Console.WriteLine("Проверка");
            Console.WriteLine($"Наборы дубликатов совпадают: {sameSet}");
        }
        public static List<int> FindDuplicatesWithHashSet(List<int> numbers)//через hashset
        {
            HashSet<int> seen = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();

            foreach (int number in numbers)
            {
                if (seen.Contains(number)) duplicates.Add(number);
                else seen.Add(number);
            }
            return duplicates.ToList();
        }
        private static List<int> FindDuplicatesWithLinq(List<int> numbers)//через linq
        {
            return numbers.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
        }
    }
}
