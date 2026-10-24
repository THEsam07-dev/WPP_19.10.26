using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task14_AgeCalculator : ITask
    {
        public string Title => "Возраст по дате рождения";
        public string Description => "По дате рождения вычислить точный возраст в годах, месяцах и днях.";
        public string[] Requirements => new[]
        {
            "Ввод даты через DateTime.TryParse (или TryParseExact).",
            "Учесть, что день рождения в этом году мог ещё не наступить.",
            "Вывести «X лет, Y месяцев, Z дней».",
            "Некорректная дата — сообщение об ошибке, не падать."
        };

        public void Run()
        {
            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            string input = Console.ReadLine();

            if (!DateTime.TryParseExact(input, "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime birthDate))
            {
                Console.WriteLine("Ошибка: неверный формат даты. Используйте дд.мм.гггг (например, 25.12.1995).");
                return;
            }

            DateTime today = DateTime.Today;

            if (birthDate > today)
            {
                Console.WriteLine("Ошибка: дата рождения не может быть в будущем!");
                return;
            }

            int years = today.Year - birthDate.Year;

            if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day))
                years--;

            DateTime tempDate = birthDate.AddYears(years);
            int months = today.Month - tempDate.Month;

            if (today.Day < tempDate.Day) months--;

            if (months < 0)
            {
                months += 12;
                years--;
            }

            DateTime startOfLastMonth = tempDate.AddMonths(months);
            int days = (today - startOfLastMonth).Days;

            Console.WriteLine($"\nВозраст: {years} лет, {months} месяцев, {days} дней.");
        }
    }
}
