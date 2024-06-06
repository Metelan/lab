using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class LineOfCreditAccount : BankAccount
    {
        // Конструктор класса LineOfCreditAccount
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
            // Тело конструктора пустое, так как все необходимые действия выполняются в конструкторе базового класса
        }

        // Метод, выполняющийся в конце месяца для обработки транзакций
        public override void PerformMonthEndTransactions()
        {
            // Если баланс отрицательный, начисляем проценты
            if (Balance < 0)
            {
                // Рассчитываем проценты как 7% от отрицательного баланса
                decimal interest = -Balance * 0.07m;
                // Выполняем снятие средств со счета в виде начисления процентов
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }

        // Проверка лимита снятия средств
        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
            // Если счет перерасходован, применяем комиссию за овердрафт
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
            : default; // В противном случае никаких действий не производим
    }
}
