using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public static class StringExtensions // отдельный класс для методов
    {
        public static bool IsPalindrome(this string str)//метод полиндрома как в тз.
        {
            if (string.IsNullOrEmpty(str))
                return false;
            //1-послед.2-ост.только символы.3-массив.4-ниний регистр
            var cleaned = new string(str.Where(char.IsLetterOrDigit).ToArray()).ToLower();

            int left = 0;//1ый элемент
            int right = cleaned.Length - 1;//крайний элемент

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
        public static int WordCount(this string str)//посчет кол-ва символов
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            return str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;//- пробелы
        }
        public static string ReverseString(this string str)//верверс символов
        {
            if (string.IsNullOrEmpty(str))
                return str;
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
    public class Task16_SolutionMethod4String : ITask
    {
        public string Title => "Методы расширения для `string`";
        public string Description => "Написать extension-методы для `string`";
        public string[] Requirements => new[]
        {
            "Реализовать в статическом классе StringExtensions.",
            "Методы: IsPalindrome(), WordCount(), ReverseString()",
            "Методы должны быть public static с this string` первым параметром",
            "Продемонстрировать вызов на 2–3 строках"
        };

        public void Run()
        {
            Console.WriteLine("Введите 1ое слово: ");
            string wordA = Console.ReadLine();
            Console.WriteLine("Введите 2ое слово: ");
            string wordB = Console.ReadLine();
            Console.WriteLine("Введите 3ье слово: ");
            string wordC = Console.ReadLine();

            if (string.IsNullOrEmpty(wordA))//страховка 
                wordA = "пусто";
            if (string.IsNullOrEmpty(wordB))
                wordB = "пусто";
            if (!string.IsNullOrEmpty(wordC))
                wordC = "пусто";

            ShowResults(wordA);
            ShowResults(wordB);
            ShowResults(wordC);
        }
        private void ShowResults(string word)//вывод результата
        {
            Console.WriteLine($"Текст: {word}");
            Console.WriteLine($"Палиндром: {word.IsPalindrome()}");
            Console.WriteLine($"Слов: {word.WordCount()}");
            Console.WriteLine($"Реверс: {word.ReverseString()}");
        }
    }
}
