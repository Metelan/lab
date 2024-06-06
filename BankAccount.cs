 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    // Класс BankAccount представляет банковский счет.
    public class BankAccount
    {
        //Переменная для генерации уникального номера аккаунта.
        private static int s_accountNumberSeed = 1234567890;
        //Свойства 
        public string Number { get; } //Номер аккаунта
        public string Owner { get; set; } //Имя аккаунта
        public decimal Balance //Текущий баланс аккаунта
        {
            get
            {
                decimal balance = 0; 
                foreach (var item in _allTransactions) //Вычисляем баланс путем суммирование всех транзакций 
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }
        private readonly decimal _minimumBalance;
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
        //Конструктор для создания нового банковского счета.
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            Number = s_accountNumberSeed.ToString(); //Присваиваем сид к новому аккаунту
            s_accountNumberSeed++; //Инкриментируем для изменение сида для следующего акаунта 

            Owner = name; //Присваиваем имя к новому аккаунту
            _minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance"); //Записываем начальный баланс через метод MakeDeposit

        }

        // Метод для получения истории транзакций по счету.
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");//Вывод 1 строки таблицы 
            foreach (var item in _allTransactions)//Цикл пока список транзакций не закончится
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");//Вывод строки таблицы 
            }

            return report.ToString();
        }

        // Список всех транзакций по счету.
        private List<Transaction> _allTransactions = new List<Transaction>();

        // Метод для создания депозита на счет.
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) //Если депозит меньше 0 то выводит ошибку
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note); //Запись текущего деопозита в журнал транзакции
            _allTransactions.Add(deposit);
        }


        // Метод для совершения снятия со счета.
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) //Если списание меньше 0 то выводит ошибку
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0) //Если списание больше чем текущий баланс то выводит ошибку
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);//Запись текущего списания в журнал транзакции
            _allTransactions.Add(withdrawal);
        }
        public virtual void PerformMonthEndTransactions() { }
    }
}
