using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level1
{
    public class Task02_Primitives : ITask
    {
        public string Title => "Переменные примитивных типов";
        public string Description => "Объявить переменные всех примитивных типов и вывести их значения и типы.";
        public string[] Requirements => new[]
        {
            "Объявить минимум: int, long, double, float, decimal, bool, char, string.",
            "Для каждой переменной вывести значение и GetType().Name.",
            "decimal — с суффиксом m, float — с f."
        };

        public void Run()
        {
            int integer = 100;
            long lng = 200;
            double dbl = 500.5;
            float flt = 3.141592653589793238462643383279502884197169399375105820974944592f;
            decimal dcml = 19.95m;
            bool bl = false;
            char chr = 'a';
            string strng = "abcdef";
            sbyte sbt = 23;
            short shrt = 13;
            ushort ush = 3;
            ulong ulng = 8;

            PrintVariables("integer", integer);
            PrintVariables("long", lng);
            PrintVariables("dbl", dbl);
            PrintVariables("flt", flt);
            PrintVariables("dcml", dcml);
            PrintVariables("bl", bl);
            PrintVariables("chr", chr);
            PrintVariables("strng", strng);
            PrintVariables("sbt", sbt);
            PrintVariables("shrt", shrt);
            PrintVariables("ush", ush);
            PrintVariables("ulng", ulng);
        }

        private void PrintVariables<T>(string name, T value)
        {
            Console.WriteLine($"{name} = {value} ({value.GetType().Name})");
        }
    }
}