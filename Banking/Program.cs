using Banking.Models.Domain;
using System;
using System.Collections.Generic;

namespace Banking {
    class Program {
        static void Main(string[] args) {
            BankAccount account = new BankAccount("123-4567890-02");
            Console.WriteLine($"AccountNumber: {account.AccountNumber} ");
            Console.WriteLine($"Balance: {account.Balance} ");
            account.Deposit(200M);
            Console.WriteLine($"Balance after deposit of 200 euros: {account.Balance} ");
            account.Withdraw(100);
            Console.WriteLine($"Balance after withdraw of 100 euros: {account.Balance} ");
            IEnumerable<Transaction> transactions = account.GetTransactions(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1));
            foreach (var transaction in transactions) {
                Console.WriteLine($"On { transaction.DateOfTransaction}: {transaction.TransactionType}: {transaction.Amount}");
            }
            Console.WriteLine("$=============");
            SavingsAccount sa = new SavingsAccount("123-45678902-02", 0.01M);
            sa.Deposit(100);
            Console.WriteLine($"Balance:{sa.Balance} ");
            sa.Withdraw(50);
            Console.WriteLine($"Balance:{sa.Balance} ");
            sa.AddInterest();
            Console.WriteLine($"Balance:{sa.Balance} ");
        }
    }
}
