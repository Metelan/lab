using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    // Класс Transaction представляет собой финансовую транзакцию в банковском приложении.
    public class Transaction
    {
        // Свойство для хранения суммы транзакции.
        public decimal Amount { get; }
        // Свойство для хранения даты транзакции.
        public DateTime Date { get; }
        // Свойство для хранения примечания к транзакции.
        public string Notes { get; }

        // Конструктор для создания новой транзакции.
        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount; // Присваиваем значение суммы.
            Date = date;     // Присваиваем значение даты.
            Notes = note;    // Присваиваем значение примечания.
        }
    }
}