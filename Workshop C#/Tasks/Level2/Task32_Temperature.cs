using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task32_Temperature : ITask
    {
        public string Title => "Свойства с валидацией (Temperature)";
        public string Description => "Класс Temperature с валидацией в set.";
        public string[] Requirements => new[]
        {
            "Свойство Celsius с проверкой в set: не ниже −273.15.",
            "При некорректном значении — бросать ArgumentOutOfRangeException.",
            "Вычисляемое свойство Fahrenheit (только get).",
            "Продемонстрировать корректное и некорректное присваивание."
        };
        public void Run()
        {
            var temp = new Temperature();

            Console.WriteLine("=== 1. Корректное присваивание ===");
            temp.Celsius = 25;
            Console.WriteLine($"Установлено: {temp.Celsius} °C");
            Console.WriteLine($"Пересчет в Фаренгейты: {temp.Fahrenheit:F2} °F\n");

            Console.WriteLine("=== 2. Изменение значения и пересчет ===");
            temp.Celsius = 0;
            Console.WriteLine($"Установлено: {temp.Celsius} °C");
            Console.WriteLine($"Пересчет в Фаренгейты: {temp.Fahrenheit:F2} °F\n");

            Console.WriteLine("=== 3. Граничное значение (Абсолютный ноль) ===");
            temp.Celsius = -273.15;
            Console.WriteLine($"Установлено: {temp.Celsius} °C");
            Console.WriteLine($"Пересчет в Фаренгейты: {temp.Fahrenheit:F2} °F\n");

            Console.WriteLine("=== 4. Некорректное присваивание (ниже абсолютного нуля) ===");
            try
            {
                Console.WriteLine("Попытка установить -300 °C...");
                temp.Celsius = -300;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[Ожидаемая ошибка] {ex.ParamName}: {ex.Message}");
                Console.WriteLine($"Текущая температура осталась прежней: {temp.Celsius} °C");
            }
        }
        //класс Temperature
        public class Temperature
        {
            private double _celsius;

            public double Celsius
            {
                get { return _celsius; }
                set
                {
                    if (value < -273.15)
                    {
                        throw new ArgumentOutOfRangeException(
                            nameof(value),
                            "Температура не может быть ниже абсолютного нуля (-273.15 °C).");
                    }
                    _celsius = value;
                }
            }
            public double Fahrenheit
            {
                get
                {
                    return (_celsius * 9 / 5) + 32;
                }
            }
        }
    }
}
