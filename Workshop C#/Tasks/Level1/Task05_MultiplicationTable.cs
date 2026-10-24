using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task05_MultiplicationTable : ITask
    {
        public string Title => "Таблица умножения 10x10";
        public string Description => "Вывести таблицу умножения 10x10.";
        public string[] Requirements => new[]
        {
            "Использовать вложенные циклы for.",
            "Выровнять столбцы.",
            "Заголовки строк/столбцов не обязательны, но приветствуются."
        };

        public void Run()
        {
            const int size = 10;
            int width = 4;
            for (int i = 0; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    Console.Write("{0," + width + "}", i == 0 ? j : i * j);
                }
                Console.WriteLine();
            }
        }
    }
}
