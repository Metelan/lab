using System;

namespace Lab2
{
    // Главный класс программы, содержащий точку входа приложения.
    class Program
    {

        // Метод Main является точкой входа для выполнения программы.
        static void Main(string[] args)
        {   //Создание гифкарты
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());
            //Ввод денег
            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            // Создание нового банковского счета для пользователя с именем Vlad и начальным балансом 1000.
            var account = new BankAccount("Vlad", 1000);

            // Вывод информации о созданном аккаунте.
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            // Совершение операции снятия со счета.
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            // Вывод текущего баланса после снятия.
            Console.WriteLine(account.Balance);

            // Совершение операции депозита на счет.
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            // Вывод текущего баланса после депозита.
            Console.WriteLine(account.Balance);

            // Вывод истории транзакций по счету.
            Console.WriteLine(account.GetAccountHistory());

            // Попытка совершить снятие со счета, превышающее текущий баланс.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                // Обработка исключения, возникающего при попытке перерасхода средств.
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            // Попытка создать аккаунт с отрицательным балансом.
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Обработка исключения, возникающего при создании аккаунта с отрицательным балансом.
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return; // Завершение работы метода Main.
            }
        }
    }
}