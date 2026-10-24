using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task13_WordCounter : ITask
    {
        public string Title => "Счётчик вхождений слов в тексте";
        public string Description => "Посчитать, сколько раз каждое слово встречается в тексте.";
        public string[] Requirements => new[]
        {
            "Использовать Dictionary<string, int>.",
            "Разбить текст на слова (по пробелам и знакам пунктуации).",
            "Привести слова к нижнему регистру.",
            "Вывести пары «слово → количество», отсортированные по убыванию."
        };

        public void Run()
        {
            Console.WriteLine("Введите текст для анализа:");
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Текст не введен.");
                return;
            }

            char[] separators = { ' ', '.', ',', '!', '?', ';', ':', '"', '(', ')', '\n', '\r', '-' };
            string[] rawWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var counts = new Dictionary<string, int>();

            foreach (var word in rawWords)
            {
                string cleanWord = word.Trim().ToLower();
                if (string.IsNullOrEmpty(cleanWord)) continue;

                if (counts.ContainsKey(cleanWord))
                    counts[cleanWord]++;
                else
                    counts.Add(cleanWord, 1);
            }

            var sortedList = new List<KeyValuePair<string, int>>(counts);
            sortedList.Sort((x, y) => y.Value.CompareTo(x.Value));

            Console.WriteLine("\nРезультаты (слово → количество):");
            Console.WriteLine(new string('-', 30));

            foreach (var pair in sortedList)
            {
                Console.WriteLine($"{pair.Key,-15} -> {pair.Value}");
            }
        }
    }
}
