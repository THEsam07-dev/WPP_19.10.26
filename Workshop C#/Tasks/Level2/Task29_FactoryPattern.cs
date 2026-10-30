using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task29_FactoryPattern : ITask
    {
        public string Title => "Паттерн «Фабрика» (уведомления)";
        public string Description => "Реализовать фабрику уведомлений.";
        public string[] Requirements => new[]
        {
            "Интерфейс INotification с методом Send(string message).",
            "Реализации: EmailNotification, SmsNotification, PushNotification.",
            "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию.",
            "enum NotificationType { Email, Sms, Push }.",
            "Продемонстрировать создание и отправку через фабрику."
        };
        public void Run()
        {
            Console.WriteLine("Демонстрация паттерна «Фабрика»\n");

            string message = "Скидка 20% на все товары! Успейте купить.";

            foreach (NotificationType type in Enum.GetValues(typeof(NotificationType)))
            {
                Console.WriteLine($"Попытка отправить через {type}");

                try
                {
                    INotification notification = NotificationFactory.Create(type);

                    notification.Send(message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine();
            }
            Console.WriteLine("Попытка передать неверный тип");
            try
            {
                NotificationType invalidType = (NotificationType)99;
                INotification invalidNotification = NotificationFactory.Create(invalidType);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
            }
        }
        //интерфейс + реализация 
        public interface INotification
        {
            void Send(string message);
        }
        public class EmailNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"[Email] Отправлено письмо: \"{message}\"");
            }
        }
        public class SmsNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"[SMS] Отправлено сообщение: \"{message}\"");
            }
        }
        public class PushNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"  [Push] Отправлено всплывающее уведомление: \"{message}\"");
            }
        }
        //фабрика
        public enum NotificationType
        {
            Email,
            Sms,
            Push,
        }
        public static class NotificationFactory
        {
            //тип -> готовый объект
            public static INotification Create(NotificationType type)
            {
                switch (type)
                {
                    case NotificationType.Email:
                        return new EmailNotification();
                    case NotificationType.Sms:
                        return new SmsNotification();
                    case NotificationType.Push:
                        return new PushNotification();
                    default:
                        throw new ArgumentException($"Неизвестный тип уведомления: {type}");
                }
            }
        }
    }
}
