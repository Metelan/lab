using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class GiftCardAccount : BankAccount
    {
        // Приватное поле для хранения ежемесячного депозита
        private readonly decimal _monthlyDeposit = 0m;

        // Конструктор класса GiftCardAccount
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
            // Инициализация ежемесячного депозита
            => _monthlyDeposit = monthlyDeposit;

        // Переопределенный метод для выполнения транзакций в конце месяца
        public override void PerformMonthEndTransactions()
        {
            // Если ежемесячный депозит не равен нулю, добавляем его на счет
            if (_monthlyDeposit != 0)
            {
                // Выполнение депозита
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }
    }
