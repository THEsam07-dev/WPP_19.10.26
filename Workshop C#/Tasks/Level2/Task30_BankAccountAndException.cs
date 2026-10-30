using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task30_BankAccountAndException  : ITask
    {
        public string Title => "BankAccount + свой Exception";
        public string Description => "Реализовать банковский счёт с собственным исключением.";
        public string[] Requirements => new[]
        {
            "Класс BankAccount с приватным балансом.",
            "Методы Deposit(decimal), Withdraw(decimal).",
            "Свой класс InsufficientFundsException : Exception.",
            "Withdraw бросает исключение, если сумма больше баланса.",
            "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)."
        };
        public void Run()
        {
            Console.WriteLine("Демонстрация работы BankAccount\n");

            var account = new BankAccount();
            Console.WriteLine($"Начальный баланс: {account.Balance:C}");

            //пополнение депозита
            account.Deposit(1000m);
            Console.WriteLine($"После пополнения на 1000: {account.Balance:C}\n");

            //успешние снятие
            try
            {
                Console.WriteLine("Попытка снять 300.....");
                account.Withdraw(300m);
                Console.WriteLine($"Успешно! Текущий баланс: {account.Balance:C}\n");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }
            //безуспешние снятие
            try
            {
                Console.WriteLine("Попытка снять 1000 (больше, чем остаток).....");
                account.Withdraw(1000m);
                Console.WriteLine("Эта строка не должна выполниться.");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Поймано кастомное исключение: {ex.Message}");
                Console.WriteLine($"Не хватает: {(ex.WithdrawAmount - ex.CurrentBalance):C}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Поймано другое исключение: {ex.Message}\n");
            }
            Console.WriteLine($"Итоговый баланс: {account.Balance:C} (ушел ли в минус? {(account.Balance < 0 ? "ДА" : "НЕТ")})");

            //ошибка пополнении отрицательной суммы
            try
            {
                Console.WriteLine("\nПопытка пополнить на -50.....");
                account.Deposit(-50m);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
            }
        }
        //bank account
        public class BankAccount
        {
            private decimal _balance;
            public decimal Balance => _balance;
            public void Deposit(decimal amount)
            {
                if (amount <= 0)//-отрицательные и нулевые попалненния
                {
                    throw new ArgumentException("Сумма пополнения должна быть больше нуля!");
                }
                _balance += amount;
            }
            public void Withdraw(decimal amount)
            {
                if (amount <= 0)//-отрицательные и нулевые снятия 
                {
                    throw new ArgumentException("Сумма снятия должна быть больше нуля!");
                }
                if (amount > _balance)//-проверка на достаточность средств
                {
                    throw new InsufficientFundsException(_balance, amount);
                }
                _balance -= amount;
            }
        }
        public class InsufficientFundsException : Exception
        {
            public decimal CurrentBalance { get; }
            public decimal WithdrawAmount { get; }
            public InsufficientFundsException(decimal currentBalance, decimal withdrawAmount)
                : base($"Недостаточно средств. На счету: {currentBalance:C}, запрошено: {withdrawAmount:C}.")
            {
                CurrentBalance = currentBalance;
                WithdrawAmount = withdrawAmount;
            }
            //базовые кострукторы для исключений \|/
            public InsufficientFundsException() : base() { }
            public InsufficientFundsException(string message) : base(message) { }
            public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { }
        }
    }
}
