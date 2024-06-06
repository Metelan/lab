using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    // Класс InterestEarningAccount, производный от BankAccount
    public class InterestEarningAccount : BankAccount
    {

       

            // Конструктор класса InterestEarningAccount
            public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
            {
                // Тело конструктора пустое, так как все необходимые действия выполняются в конструкторе базового класса
            }

            // Переопределенный метод для выполнения транзакций в конце месяца
            public override void PerformMonthEndTransactions()
            {
                // Если баланс превышает 500, начисляем проценты
                if (Balance > 500m)
                {
                    // Рассчитываем проценты как 2% от баланса
                    decimal interest = Balance * 0.02m;
                    // Выполняем депозит начисленных процентов
                    MakeDeposit(interest, DateTime.Now, "apply monthly interest");
                }
            }

    }
}
