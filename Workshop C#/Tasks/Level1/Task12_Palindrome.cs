using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task12_Palindrome : ITask
    {
        public string Title => "Палиндром (без учёта регистра/пробелов)";
        public string Description => "Проверить, является ли строка палиндромом.";
        public string[] Requirements => new[]
        {
            "Игнорировать регистр (ToLower/ToUpper).",
            "Игнорировать пробелы и знаки пунктуации.",
            "Не использовать LINQ Reverse.",
            "Пустая строка и строка из одного символа — палиндром."
        };

        public void Run()
        {
            Console.Write("Введите строку для проверки: ");
            string userInput = Console.ReadLine() ?? string.Empty;

            if (IsPalindrome(userInput))
                Console.WriteLine("Это палиндром!");
            else
                Console.WriteLine("Это не палиндром.");
        }

        private bool IsPalindrome(string str)
        {
            if (string.IsNullOrEmpty(str)) return true;

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(str[left]))
                {
                    left++;
                }
                while (left < right && !char.IsLetterOrDigit(str[right]))
                {
                    right--;
                }

                if (char.ToLower(str[left]) != char.ToLower(str[right]))
                {
                    return false;
                }

                left++;
                right--;
            }
            return true;
        }
    }
}
