using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool launchControl = true;

            while (launchControl)
            {
                Console.Clear();
                Console.WriteLine("=== Практикум по C# ===");
                Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
                Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
                Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
                Console.WriteLine("0. Выход");
                Console.WriteLine("\nВыберите уровень:");

                string inputnum = Console.ReadLine();

                if (int.TryParse(inputnum, out int num))
                {
                    switch (num)
                    {
                        case 1:
                            RunLevelEasy();
                            break;
                        case 2:
                            RunLevelMedium();
                            break;
                        case 3:
                            RunLevelHard();
                            break;
                        case 0:
                            Console.WriteLine("До скорых встреч!");
                            launchControl = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка такой цыфры не предусмотренно. Пожалуйста, выберите число от 1 до 3.");
                            PressAnyToContinue();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nОшибка: пожалуйста, введите число 1 - 3.");
                    PressAnyToContinue();
                }
            }
        }

        static void PressAnyToContinue()
        {
            Console.Write("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        static void RunLevelEasy()
        {
            bool isInLevelMenu = true;

            while (isInLevelMenu)
            {
                Console.Clear();//очистка
                ShowEasyTasksList();//лист с заадниями легкого уровня

                Console.Write("Ваш выбор: ");
                string inputEasy = Console.ReadLine();

                if (int.TryParse(inputEasy, out int taskNum))
                {
                    switch (taskNum)
                    {
                        case 0:
                            isInLevelMenu = false;
                            break;

                        case 1:
                            Task_HelloWorld();
                            PressAnyToContinue();
                            break;

                        case 2:
                            Task_Variables();
                            PressAnyToContinue();
                            break;

                        case 3:
                            Task_Calculator();
                            PressAnyToContinue();
                            break;

                        case 4:
                            Task_ParityNum();
                            PressAnyToContinue();
                            break;

                        case 5:
                            Task_MultiplicationTable();
                            PressAnyToContinue();
                            break;

                        case 6:
                            Task_SumDM();
                            PressAnyToContinue();
                            break;

                        case 7:
                            Task_Reverse();
                            PressAnyToContinue();
                            break;

                        case 8:
                            Task_FizzBuzz();
                            PressAnyToContinue();
                            break;

                        case 9:
                            Task_Arrays();
                            PressAnyToContinue();
                            break;

                        case 10:
                            Task_BubbleAndInsertionSort();
                            PressAnyToContinue();
                            break;

                        case 11:
                            Task_MatricesNxN();
                            PressAnyToContinue();
                            break;

                        case 12:
                            Task_Palindrome();
                            PressAnyToContinue();
                            break;

                        case 13:
                            Task_Dictionary();
                            PressAnyToContinue();
                            break;

                        case 14:
                            Task_BirthDate();
                            PressAnyToContinue();
                            break;

                        case 15:
                            Task_GitWorkflow();
                            PressAnyToContinue();
                            break;

                        default:
                            Console.WriteLine("\nТакого задания нет. Попробуйте снова.");
                            PressAnyToContinue();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nПожалуйста, введите число (или 0 для выхода).");
                    PressAnyToContinue();
                }
            }
        }
        static void ShowEasyTasksList()//Список 1ого уровня
        {
            Console.WriteLine("1. Hello, World + текущая дата");
            Console.WriteLine("2. Переменные примитивных типов");
            Console.WriteLine("3. Калькулятор с делением на ноль");
            Console.WriteLine("4. Чётность числа (два способа)");
            Console.WriteLine("5. Таблица умножения 10*10");
            Console.WriteLine("6. Сумма цифр числа (строка + арифметика)");
            Console.WriteLine("7. Реверс строки без LINQ");
            Console.WriteLine("8. FizzBuzz 1–100");
            Console.WriteLine("9. Массивы: min/max/sum/avg");
            Console.WriteLine("10. Сортировка пузырьком + вставками");
            Console.WriteLine("11. Диагональ матрицы NxN");
            Console.WriteLine("12. Палиндром (без учёта регистра/пробелов)");
            Console.WriteLine("13. Счётчик вхождений слов в тексте (Dictionary)");
            Console.WriteLine("14. Возраст по дате рождения");
            Console.WriteLine("15. Git: репозиторий → ветка → merge → разрешение конфликта");
            Console.WriteLine("0. Выход");
            Console.WriteLine("\nВыберите задание:");
        }
        static void Task_HelloWorld()//номер 1
        {
            Console.Clear();
            Console.WriteLine("Задание 1. Hello, World + текущая дата");
            Console.WriteLine("Hello, World!");
            Console.WriteLine($"Сегодня: {DateTime.Now:dd.MM.yyyy}");
        }
        static void Task_Variables()//номер 2
        {
            Console.Clear();
            Console.WriteLine("Задание 2. Переменные примитивных типов");
            int integer = 100;//число
            long lng = 200;//число
            double dbl = 500.5;//число с десятичными сотыми и тд.
            float flt = 3.141592653589793238462643383279502884197169399375105820974944592f;//число с плавающей точкой + F в конце
            decimal dcml = 19.95m;//число с плавающей точкой + M в конце
            bool bl = false;//логика true/false
            char chr = 'a';//одиночный символ
            string strng = "abcdef";//строка символов
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
        static void PrintVariables<T>(string name, T value)//метод для получения видв строки
        {
            Console.WriteLine($"{name} = {value} ({value.GetType().Name})");
        }
        static void Task_Calculator()//номер 3
        {
            bool CALC = true;
            
            while (CALC)
            {

                Console.Clear();
                Console.WriteLine("Задание 3. Калькулятор с делением на ноль");
                Console.WriteLine("Выберите тип операции");
                Console.WriteLine("1. Сложение (+)");
                Console.WriteLine("2. Вычитание (-)");
                Console.WriteLine("3. Умножение (*)");
                Console.WriteLine("4. Деление (/)");
                Console.WriteLine("0. Выход");

                string inputCalc = Console.ReadLine(); 
                if(int.TryParse(inputCalc, out int Operation))
                {
                    switch (Operation)
                    {
                        case 0:
                            CALC = false;
                            break;
                        case 1:
                            OperationAddition();
                            PressAnyToContinue();
                            break;
                        case 2:
                            OperationSubtraction();
                            PressAnyToContinue();
                            break;
                        case 3:
                            OperationMultiplication();
                            PressAnyToContinue();
                            break;
                        case 4:
                            OperationDivision();
                            PressAnyToContinue();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nПожалуйста, операцию (или 0 для выхода).");
                    PressAnyToContinue();
                }
            }
        }
        static void OperationAddition()//метод для сложения
        {
            double a, b;

            Console.WriteLine("Введите первое значение(a): ");
            while (!double.TryParse(Console.ReadLine(), out a))//перебор и чтение для а
            {
                Console.Write("Некороректный ввод.");
            }

            Console.WriteLine("Введите первое значение(b): ");
            while (!double.TryParse(Console.ReadLine(), out b))//перебор и чтение для а
            {
                Console.Write("Некороректный ввод.");
            }

            double result = a + b;
            Console.WriteLine($"Результат сложения {a} + {b} = {result}");
        }
        static void OperationSubtraction()//метод для вычитания
        {
            double a, b;

            Console.WriteLine("Введите первое значение(a): ");
            while (!double.TryParse(Console.ReadLine(), out a))//перебор и чтение для а
            {
                Console.Write("Некороректный ввод.");
            }

            Console.WriteLine("Введите первое значение(b): ");
            while (!double.TryParse(Console.ReadLine(), out b))//перебор и чтение для а
            {
                Console.Write("Некороректный ввод.");
            }

            double result = a - b;
            Console.WriteLine($"Результат вычитания {a} - {b} = {result}");
        }
        static void OperationMultiplication()//метод для умножения
        {
            double a, b;

            Console.WriteLine("Введите первое значение(a): ");
            while (!double.TryParse(Console.ReadLine(), out a))//перебор и чтение для а
            {
                Console.Write("Некороректный ввод.");
            }

            Console.WriteLine("Введите первое значение(b): ");
            while (!double.TryParse(Console.ReadLine(), out b))//перебор и чтение для а
            {
                Console.Write("Некороректный ввод.");
            }

            double result = a * b;
            Console.WriteLine($"Результат умножения {a} * {b} = {result}");
        }
        static void OperationDivision()//метод для деления
        {
            double a, b;

            Console.WriteLine("Введите первое значение(a): ");
            while (!double.TryParse(Console.ReadLine(), out a))//перебор и чтение для а
            {
                Console.Write("Некороректный ввод.");
            }

            Console.WriteLine("Введите первое значение(b): ");
            while (!double.TryParse(Console.ReadLine(), out b))//перебор и чтение для а
            {
                Console.Write("Некороректный ввод.");
            }

            if (b == 0)
            {
                Console.WriteLine("Ошибка: деление на ноль невозможно");
                return;
            }

            double result = a / b;
            Console.WriteLine($"Результат деления {a} / {b} = {result}");
        }
        static void Task_ParityNum()//номер 4
        {
            Console.Clear();
            Console.WriteLine("Задание 4. Чётность числа (два способа)");

            int num = ParityNumINPUT("Введите целое число: ");

            ParityNumPercent(num);
            ParityNumByQuestion(num);
        }
        static int ParityNumINPUT(string say)//ввод и проверка числа
        {
            while (true)
            {
                Console.Write(say);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                }
            }
        }
        static void ParityNumPercent(int a)//номер 4 способ 1
        {
            Console.Write("Способ 1 (if-else): ");

            if (a % 2 == 0)
            {
                Console.WriteLine($"{a} - четное");
            }
            else
            {
                Console.WriteLine($"{a} - нечетное");
            }
        }
        static void ParityNumByQuestion(int a)//номер 4 способ 2
        {
            Console.Write("Способ 2 (?:): ");
            string result = (a % 2 == 0) ? $"{a} - чётное" : $"{a} - нечётное";
            Console.WriteLine(result);
        }
        static void Task_MultiplicationTable()//номер 5
        {
            Console.Clear ();
            Console.WriteLine("Задание 5. Таблица умножения 10*10");
            const int size = 10;
            int width = 4;
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0," + width + "}", i);

                for (int j = 1; j <= size; j++)
                {
                    Console.Write("{0," + width + "}", i * j);
                }
                Console.WriteLine();
            }
        }
        static void Task_SumDM()//номер 6
        {
            Console.Clear();
            Console.WriteLine("Задание 6. Сумма цифр числа (строка + арифметика)");

            Console.WriteLine("Введите целое число");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Ошибка введено не корректное число.");
                return;
            }

            int sumString = SumString(number);
            int sumMath = SumMath(number);

            Console.WriteLine($"Введено число: {number}");
            Console.WriteLine($"Через строку: {sumString}");
            Console.WriteLine($"Через арифметику: {sumMath}");

            if (sumString == sumMath)
            {
                Console.WriteLine("Решения совпадают");
            }
            else
            {
                Console.WriteLine("Решения не совпадают");
            }
        }
        static int SumString(int n)//номер 6 способ 1
        {
            n = Math.Abs(n);
            string numberStr = n.ToString();
            int sum = 0;

            foreach (char c in numberStr)
            {
                int digit = int.Parse(c.ToString());
                sum += digit;
            }
            return sum;
        }
        static int SumMath(int n)//номер 6 способ 2
        {
            n = Math.Abs(n);
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
        static void Task_Reverse()//номер 7
        {
            Console.Clear();
            Console.WriteLine("Задание 7. Реверс строки без LINQ");

            Console.WriteLine("Как будем получать строку?");
            Console.WriteLine("1 - Ввести вручную");
            Console.WriteLine("2 - Сгенерировать случайную");
            Console.Write("Выберите вариант (1 или 2): ");
            string mode = Console.ReadLine();

            string input = "";
            var random = new Random();

            if (mode == "1")
            {
                Console.Write("Введите строку: ");
                input = Console.ReadLine();
            }
            else if (mode == "2")
            {
                Console.Write("Укажите длину строки: ");
                string lenStr = Console.ReadLine();

                if (!int.TryParse(lenStr, out int len) || len <= 0) len = 10;

                const string alphabet = "abcdefghijklmnopqrstuvwxyz";
                var sb = new System.Text.StringBuilder(len);
                for (int i = 0; i < len; i++)
                {
                    int idx = random.Next(alphabet.Length);
                    sb.Append(alphabet[idx]);
                }
                input = sb.ToString();
                Console.WriteLine($"Сгенерировано: {input}");
            }
            else
            {
                Console.WriteLine("Некорректный выбор, используем пустую строку.");
                input = "";
            }

            char[] mas = input.ToCharArray();
            int left = 0;
            int right = mas.Length - 1;

            while (left < right)
            {
                char temp = mas[left];
                mas[left] = mas[right];
                mas[right] = temp;

                left++;
                right--;
            }
            string result = new string(mas);

            Console.WriteLine($"Реверс: \"{result}\"");            
        }
        static void Task_FizzBuzz()//номер 8
        {
            Console.Clear();
            Console.WriteLine("Задание 8. FizzBuzz 1–100");

            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine($"{i}");
                }
            }
        }
        static void Task_Arrays()//номер 9
        {
            Console.Clear();
            Console.WriteLine("Задание 9. Массивы: min/max/sum/avg");

            int[] numbers = new int[20];
            var rnd = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(1, 101);
            }
            Console.WriteLine();

            int min = GetMin(numbers);
            int max = GetMax(numbers);
            long sum = GetSum(numbers);
            double avg = GetAvg(numbers);

            Console.WriteLine($"Минимум: {min}");
            Console.WriteLine($"Максимум: {max}");
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Среднее: {avg:F3}");//до 3х знаков после запятой
        }
        static int GetMin(int[] arr)
        {            
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Ошибка: массив пуст!");
                return 0;
            }
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i]< min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        static int GetMax(int[] arr)
        {            
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Ошибка: массив пуст!");
                return 0;
            }
            int max = arr[0];
            for (int i = 1;i < arr.Length; i++)
            {
                if (arr[i]> max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        static long GetSum(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Ошибка: массив пуст!");
                return 0;
            }
            long sum = 0;
            for (int i = 0;i < arr.Length;i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        static double GetAvg(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Ошибка: массив пуст!");
                return 0;
            }
            long summ = GetSum(arr);
            double avarage = (double)summ / arr.Length;
            return avarage;
        }
        static void Task_BubbleAndInsertionSort()//номер 10
        {
            Console.Clear();
            Console.WriteLine("Задание 10. Сортировка пузырьком + вставками");

            const int size = 10000;
            var rnd = new Random();

            int[] originalArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                originalArray[i] = rnd.Next(1, 1000);//1-999
            }

            //создание копий 
            int[] arrayForBubble = (int[])originalArray.Clone();
            int[] arrayForInsertion = (int[])originalArray.Clone();

            var SWB = new System.Diagnostics.Stopwatch();
            SWB.Start();
            BubbleSort(arrayForBubble);
            SWB.Stop();

            var SWI = new System.Diagnostics.Stopwatch();
            SWI.Start();
            InsertionSort(arrayForInsertion);
            SWI.Stop();

            Console.WriteLine($"Размер массива: {size}");
            Console.WriteLine($"Время пузырька: {SWB.ElapsedMilliseconds} мс.");
            Console.WriteLine($"Время пузырька: {SWI.ElapsedMilliseconds} мс.");

            //проверка 
            bool isSame = true;
            for (int i = 0; i < size; i++)
            {
                if (arrayForBubble[i] != arrayForInsertion[i])
                {
                    isSame = false;
                    break;
                }
            }
            if (isSame)
            {
                Console.WriteLine("\nПроверка пройдена: оба массива отсортированы идентично.");
                Console.WriteLine($"Первые 5 чисел: {arrayForBubble[0]}, {arrayForBubble[1]}, {arrayForBubble[2]}, {arrayForBubble[3]}, {arrayForBubble[4]}");
                Console.WriteLine($"Последние 5 чисел: {arrayForBubble[size - 5]}, {arrayForBubble[size - 4]}, {arrayForBubble[size - 3]}, {arrayForBubble[size - 2]}, {arrayForBubble[size - 1]}");
            }
            else
            {
                Console.WriteLine(" Ошибка: массивы отличаются!");
            }
        }
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1;  i < n ; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
        static void Task_MatricesNxN()//номер 11
        {
            Console.Clear();
            Console.WriteLine("Задание 10. Сортировка пузырьком + вставками");

            int n;
            while (true)
            {
                Console.WriteLine("Введите размер матрицы N (минимум 2): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out n) && n > 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод! Введите целое число >= 2.");
                }
            }

            int[,] matrix = new int[n,n];
            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(1, 100);
                }
            }

            Console.WriteLine($"\nМатрица {n}x{n}:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }

            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine($"Сумма элементов главной диагонали: {sum}");
        }
        static void Task_Palindrome()//номер 12
        {
            Console.Clear();
            Console.WriteLine("Задание 12. Проверка на палиндром");

            string[] tests = {
                "Абажуру — дом, а самодуру — жаба",
                "Ежу хуже",
                "Дорог Рим город или дорог Миргород?!",
                "hello",
                "Madam",
                "А роза упала на лапу Азора",
                "A man, a plan, a canal: Panama",
                "No 'x' in Nixon"
            };
            foreach (var test in tests)
            {
                bool result = IsPalindrome(test);
                Console.WriteLine($"Строка: \"{test}\" -> {(result ? "Палиндром" : "Не палиндром")}");
            }
            Console.WriteLine("\nПопробуйте ввести свою строку:");
            Console.Write("Ввод: ");
            string userInput = Console.ReadLine();

            if (IsPalindrome(userInput))
            {
                Console.WriteLine("Это палиндром!");
            }
            else
            {
                Console.WriteLine("Это не палиндром.");
            }

        }
        static bool IsPalindrome(string str)
        {
            if (str == null) return false;

            int left = 0;
            int right = str.Length - 1;

            while(left < right)
            {
                while(left < right && !char.IsLetterOrDigit(str[left]))
                {
                    left ++;
                }
                if (char.ToLower(str[left]) != char.ToLower(str[right]))
                {
                    return false;
                }

                left ++;
                right --;
            }
            return true;
        }
        static void Task_Dictionary()//номер 13
        {
            Console.Clear();
            Console.WriteLine("Задание 13. Счётчик вхождений слов");

            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();

            Console.WriteLine($"Исходный текст:\n{text}\n");

            char[] separators = { ' ', '.', ',', '!', '?', ';', ':', '"', '(', ')', '\n', '\r', '-' };
            string[] rawWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var counts = new Dictionary<string, int>();

            foreach (var word in rawWords)
            {
                string cleanWord = word.Trim().ToLower();
                if (string.IsNullOrEmpty(cleanWord)) continue;

                if (counts.ContainsKey(cleanWord))
                {
                    counts[cleanWord]++;
                }
                else
                {
                    counts.Add(cleanWord, 1);
                }
            }
            var sortedList = new List<KeyValuePair<string, int>>(counts);

            sortedList.Sort((x, y) => y.Value.CompareTo(x.Value));

            Console.WriteLine("Результаты (слово → количество):");
            Console.WriteLine(new string('-', 30));

            foreach (var pair in sortedList)
            {
                Console.WriteLine($"{pair.Key,-15} -> {pair.Value}");
            }

        }
        static void Task_BirthDate()//номер 14
        {
            Console.Clear();
            Console.WriteLine("Задание 14. Расчет возраста");

            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            string input = Console.ReadLine();

            if (!DateTime.TryParseExact(input, "dd.MM.yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime birthDate))
            {
                Console.WriteLine("Ошибка: неверный формат даты. Пожалуйста, используйте формат дд.мм.гггг (например, 25.12.1995).");
                PressAnyToContinue();
                return;
            }

            DateTime today = DateTime.Today;

            if (birthDate > today)
            {
                Console.WriteLine("Ошибка: дата рождения не может быть в будущем!");
                PressAnyToContinue();
                return;
            }

            int years = today.Year - birthDate.Year;

            if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day))
            {
                years--;
            }

            DateTime tempDate = birthDate.AddYears(years);

            int months = today.Month - tempDate.Month;

            if (today.Day < tempDate.Day)
            {
                months--;
            }

            if (months < 0)
            {
                months += 12;
                years--;
            }

            DateTime startOfLastMonth = tempDate.AddMonths(months);

            int days = (today - startOfLastMonth).Days;

            Console.WriteLine($"\nВозраст: {years} лет, {months} месяцев, {days} дней.");
        }
        static void Task_GitWorkflow()//номер 15
        {
        }

        //mid
        static void RunLevelMedium()
        {
            Console.WriteLine("\n== Вы выбрали средний уровень сложности (16 - 35)");
            Console.Write("\nНажмите любую клавишу для возврата в меню...");
            PressAnyToContinue();
        }

        //hard
        static void RunLevelHard()
        {
            Console.WriteLine("\n== Вы выбрали продвинутый уровень сложности (36 - 50)");
            Console.Write("\nНажмите любую клавишу для возврата в меню...");
            PressAnyToContinue();
        }
    }
}
