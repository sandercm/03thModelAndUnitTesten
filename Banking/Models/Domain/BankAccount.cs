using System;
using System.Collections.Generic;

namespace Banking.Models.Domain {
    class BankAccount {
        #region Properties & Fields
        private ICollection<Transaction> _transactions;
        public decimal Balance { get; private set; }

        public string AccountNumber { get; }
        #endregion

        #region Constructors
        public BankAccount(string account) {
            AccountNumber = account;
            Balance = Decimal.Zero;
            _transactions = new List<Transaction>();
        }
        #endregion

        #region Methods
        public void Withdraw(decimal amount) {
            _transactions.Add(new Transaction(amount, TransactionType.Withdraw));
            Balance -= amount;
        }

        public void Deposit(decimal amount) {
            _transactions.Add(new Transaction(amount, TransactionType.Deposit));
            Balance += amount;
        }
        public IEnumerable<Transaction> GetTransactions(DateTime? from = null, DateTime? till = null) {
            DateTime fromDate = from ?? DateTime.MinValue;
            DateTime tillDate = till ?? DateTime.MaxValue;
            ICollection<Transaction> result = new List<Transaction>();
            foreach (var transaction in _transactions) {
                if (transaction.DateOfTransaction >= fromDate && transaction.DateOfTransaction <= tillDate) {
                    result.Add(transaction);
                }
            }
            return result;
        }
        #endregion
    }
}
