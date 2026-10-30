using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;
using static Workshop_C_.Tasks.Level2.Task26_StrategyPattern;

namespace Workshop_C_.Tasks.Level2
{
    public class Task26_StrategyPattern : ITask
    {
        public string Title => "Паттерн «Стратегия» (скидки)";
        public string Description => "Реализовать калькулятор скидок через паттерн «Стратегия».";
        public string[] Requirements => new[]
        {
            "Интерфейс IDiscountStrategy с методом Apply(decimal price).",
            "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%).",
            "Класс PriceCalculator, принимающий стратегию в конструкторе.",
            "Продемонстрировать расчёт цены с каждой стратегией."
        };
        public void Run()
        {
            Console.WriteLine("Демонстрация паттерна «Стратегия»\n");

            decimal bPrice = 1000m;
            Console.WriteLine($"Базовая цена товара: {bPrice:C}\n");

            var calcNoDiscount = new PriceCalc(new NoDiscount());
            decimal priceNoDiscount = calcNoDiscount.Calc(bPrice);
            Console.WriteLine($"Без скидки:{priceNoDiscount:C} (Скидка: 0%)");

            var calcVip = new PriceCalc(new VipDiscount());
            decimal priceVip = calcVip.Calc(bPrice);
            Console.WriteLine($"VIP скидка:{priceVip:C} (Скидка: 10%)");

            var calcPromo = new PriceCalc(new PromoDiscount());
            decimal pricePromo = calcPromo.Calc(bPrice);
            Console.WriteLine($"Промо-скидка:{pricePromo:C} (Скидка: 20%)");

            Console.WriteLine("\nдемонстрация смены стратегии на лету");

            var flexibleCalculator = new PriceCalc(new NoDiscount());
            Console.WriteLine($"Текущая цена:     {flexibleCalculator.Calc(bPrice):C}");

            flexibleCalculator.SetStrategy(new PromoDiscount());
            Console.WriteLine($"Цена после смены стратегии на Промо: {flexibleCalculator.Calc(bPrice):C}");
        }
        //реализация интерфейса
        public interface ISDescountStrategy
        {
            decimal Use(decimal price);
        }
        public class NoDiscount : ISDescountStrategy
        {
            public decimal Use(decimal price) => price;
        }
        public class VipDiscount : ISDescountStrategy
        {
            public decimal Use(decimal price) => price * 0.90m;//10%
        }
        public class PromoDiscount : ISDescountStrategy
        {
            public decimal Use(decimal price) => price * 0.80m; //20%
        }
        public class PriceCalc
        {
            private ISDescountStrategy _strategy;
            public PriceCalc(ISDescountStrategy strategy)
            {
                _strategy = strategy;
            }
            public void SetStrategy(ISDescountStrategy strategy)
            {
                _strategy = strategy;
            }
            public decimal Calc(decimal bPrice)
            {
                if (bPrice < 0)
                    throw new ArgumentException("Цена не может быть отрицательной");
                return _strategy.Use(bPrice);
            }
        }
    }
}
