using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level3
{
    public class Book//класс для книг
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
    public class Reader//класс для читателя
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; private set; } = new List<Book>();

        public Reader(string name)
        {
            Name = name;
        }
    }
    
    public class Library//бизнес-логика библиотеки
    {
        public List<Book> Books { get; private set; } = new List<Book>();
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void BorrowBook(Reader reader, Book book)
        {
            //проверка на наличие
            if (!Books.Contains(book)) throw new ArgumentException("Этой книги нет в библиотеке.");

            //проверка нп доступность
            if (!book.IsAvailable) throw new InvalidOperationException($"Книга '{book.Title}' уже выдана другому читателю.");

            //проверка на лимит в 3 книги
            if (reader.BorrowedBooks.Count >= 3) throw new InvalidOperationException($"Читатель '{reader.Name}' превысил лимит выдачи (макс. 3 книги).");

            book.IsAvailable = false;// Выдача
            reader.BorrowedBooks.Add(book);
        }
        public void ReturnBook(Reader reader, Book book)
        {
            //проверка на повтор книги
            if (!reader.BorrowedBooks.Contains(book)) throw new InvalidOperationException($"Читатель '{reader.Name}' не брал книгу '{book.Title}'.");

            //возврат книги
            book.IsAvailable = true;
            reader.BorrowedBooks.Remove(book);
        }
    }
    public class Task45_Library : ITask
    {
        public string Title => "Минипроект «Библиотека» + юнит-тесты";
        public string Description => "Классы библиотеки с бизнес-логикой выдачи и возврата книг.";
        public string[] Requirements => new[]
        {
            "Классы: Book, Reader, Library.",
            "Логика: выдача/возврат, лимит (не более 3 книг).",
            "Обработка ошибок: занятая книга, превышение лимита.",
            "Написать 5+ юнит-тестов."
        };
        public void Run()
        {
            Console.WriteLine("Демонстрация работы библиотеки");

            var library = new Library();
            var book1 = new Book("Война миров", "Г. Уэллс");
            var book2 = new Book("Уснувший в Армагеддоне", "Р. Брэдбери");
            var book3 = new Book("Зов предков", "Д. Лондон");
            var book4 = new Book("Электрические сны", "Ф. Дик");
            var book5 = new Book("Марсианин", "Э.Вейер");

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);

            var reader = new Reader("Александр");

            try
            {
                Console.WriteLine("1.Александер берет 'Война миров'...");
                library.BorrowBook(reader, book1);
                Console.WriteLine("Успешно!");

                Console.WriteLine("2.Александер берет 'Уснувший в Армагеддоне'...");
                library.BorrowBook(reader, book2);
                Console.WriteLine("Успешно!");

                Console.WriteLine("3.Александер берет 'Зов предков'...");
                library.BorrowBook(reader, book3);
                Console.WriteLine("Успешно!");

                Console.WriteLine("4.Александер пытается взять 4-ю книгу 'Электрические сны' (ожидаем ошибку лимита)...");
                library.BorrowBook(reader, book4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Исключение]: {ex.Message}");
            }

            try
            {
                Console.WriteLine("\n5.Александер возвращает 'Война миров'...");
                library.ReturnBook(reader, book1);
                Console.WriteLine("Успешно!");

                Console.WriteLine("6.Александер берет 4-ю книгу 'Электрические сны' (теперь можно)...");
                library.BorrowBook(reader, book4);
                Console.WriteLine("Успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Исключение]: {ex.Message}");
            }
        }
    }
}
