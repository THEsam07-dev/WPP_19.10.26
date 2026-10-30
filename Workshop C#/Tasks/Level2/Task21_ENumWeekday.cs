using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task21_ENumWeekday : ITask
    {
        public string Title => "eNum дни недели";
        public string Description => "Описать дни недели через enum и определить тип дня.";
        public string[] Requirements => new[]
        {
            "enum DayOfWeek { Monday, ..., Sunday }.",
            "Метод IsWeekend(DayOfWeek day) — true для субботы и воскресенья.",
            "Метод GetRussianName(DayOfWeek day) — возвращает название на русском.",
            "Продемонстрировать на всех 7 днях."
        };
        public enum MyDayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        public static bool IsWeekend(MyDayOfWeek day)//выходные
        {
            return day == MyDayOfWeek.Saturday || day == MyDayOfWeek.Sunday;
        }
        public static string GetRuName(MyDayOfWeek day)//возв. ру. название
        {
            switch (day)
            {
                case MyDayOfWeek.Monday: return "Понедельник";
                case MyDayOfWeek.Tuesday: return "Вторник";
                case MyDayOfWeek.Wednesday: return "Среда";
                case MyDayOfWeek.Thursday: return "Четверг";
                case MyDayOfWeek.Friday: return "Пятница";
                case MyDayOfWeek.Saturday: return "Суббота";
                case MyDayOfWeek.Sunday: return "Воскресенье";
                default: return "Неизвестный день";
            }
        }
        public void Run()
        {
            Console.WriteLine("Тестирование enum дней недели\n");

            var allDays = (MyDayOfWeek[])Enum.GetValues(typeof(MyDayOfWeek));

            foreach(var day in allDays)
            {
                string rusName = GetRuName(day);
                bool theWeekend = IsWeekend(day);

                Console.WriteLine($"День: {day,-9} | Название: {rusName,-11} | Выходной: {theWeekend}");//-n - выравнивание
            }
        }
    }
}
