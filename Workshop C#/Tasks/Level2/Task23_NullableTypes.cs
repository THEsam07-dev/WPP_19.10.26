using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task23_NullableTypes : ITask
    {
        public string Title => "Nullable-типы, ??, ?.";
        public string Description => "Продемонстрировать работу с nullable.";
        public string[] Requirements => new[]
        {
            "Метод int? FindValue(string key) — возвращает null, если ключа нет.",
            "Использовать ?? для значения по умолчанию.",
            "Использовать ?. для безопасного доступа к свойству объекта, который может быть null.",
            "Использовать HasValue / Value с проверкой.",
            "Продемонстрировать на примере с найденным и ненайденным ключом.  "
        };
        public void Run()
        {
            Console.WriteLine("работа с методом FindValue и оператором ??");

            int? foundValue = FindValue("arena");
            int safeFoundValue = foundValue ?? -1;
            Console.WriteLine($"Ключ 'arena': Значение = {safeFoundValue}");

            int? notFoundValue = FindValue("online");
            int safeNotFoundValue = notFoundValue ?? -1; // верн. -1, так как == null
            Console.WriteLine($"Ключ 'online': Значение = {safeNotFoundValue} (по умолчанию)");

            Console.WriteLine("\nиспользование HasValue / Value");
            if (foundValue.HasValue)
            {
                Console.WriteLine($"Проверка HasValue: Значение для 'arena' = {foundValue.Value}");
            }

            if (!notFoundValue.HasValue)
            {
                Console.WriteLine("Проверка HasValue: Значение для 'online' отсутствует (null).");
            }

            Console.WriteLine("\n3.Использование ?. (Null-conditional operator)");

            // создаем пользователя без профиля
            User userWithoutProfile = new User { Name = "Иван", Profile = null };
            // создаем пользователя с профилем
            User userWithProfile = new User { Name = "Виктор", Profile = new UserProfile { Email = "lubaiaposhta@gmail.com" } };

            string email1 = userWithoutProfile?.Profile?.Email;
            Console.WriteLine($"Email пользователя 1: {(email1 ?? "не указан")}");

            string email2 = userWithProfile?.Profile?.Email;
            Console.WriteLine($"Email пользователя 2: {(email2 ?? "не указан")}");

            string nullString = null;
            int? length = nullString?.Length; // length будет nullт
            Console.WriteLine($"Длина null-строки: {(length.HasValue ? length.Value.ToString() : "null")}");
        }
        private readonly Dictionary<string, int> _data = new Dictionary<string, int>
        {
            {"arena", 100},
            {"daggerfall", 200},
            {"morrowind", 300},
            {"oblivion", 400},
            {"skyrim", 500}
        };
        private class User
        {
            public string Name { get; set; }
            public UserProfile Profile { get; set; }
        }
        private class UserProfile
        {
            public string Email { get; set; }
        }
        public int? FindValue(string key)//возвр nullable (int?) int
        {
            if (_data.TryGetValue(key, out int value))
            {
                return value;
            }
            return null;
        }
    }
}
