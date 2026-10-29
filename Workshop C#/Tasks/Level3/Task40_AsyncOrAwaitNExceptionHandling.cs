using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level3
{
    public class Task40_AsyncOrAwaitNExceptionHandling : ITask
    {
        public string Title => "async/await + обработка исключений";
        public string Description => "Асинхронный метод с эмуляцией скачивания и обработкой исключений.";
        public string[] Requirements => new[]
        {
            "async Task<string> DownloadAsync(string url) — внутри Task.Delay(1000).",
            "Имитировать ошибку: если url пустой — бросить ArgumentException.",
            "В Main (или Run) вызвать через await внутри try/catch.",
            "Продемонстрировать успешный и ошибочный вызов."
        };
        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }
        private async Task RunAsync()
        {
            Console.WriteLine("Демонстрация 1 - Успешный вызов");
            try
            {
                string result = await DownloadAsync("https://example.com/file.zip");//ждем заершения для асинхронного метода
                Console.WriteLine($"Успех: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка аргумента: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nДемонстрация 2 - Ошибочный вызов");
            try
            {
                string result = await DownloadAsync("");//пустая строка для копирования исключения
                Console.WriteLine($"Успех: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перехвачено исключение: {ex.Message}");
                Console.WriteLine("Приложение продолжает работу, не падает!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
            
            Console.WriteLine("\nКонец программы");
        }
        public async Task<string> DownloadAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL не может быть пустым или null.", nameof(url));
            }

            Console.WriteLine($"[DownloadAsync] Начинаем скачивание с {url}........");

            await Task.Delay(1000);

            Console.WriteLine($"[DownloadAsync] Скачивание завершено для {url}.");

            return "1024 байта (эмуляция)";
        }
    }
}
