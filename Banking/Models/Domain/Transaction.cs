using System;

namespace Banking.Models.Domain {
    public class Transaction {
        public decimal Amount { get; }
        public DateTime DateOfTransaction { get; }
        public TransactionType TransactionType { get; }
        public bool isDeposit {
            get {
                return TransactionType == TransactionType.Deposit;
            }
        }
        public bool isWithdraw {
            get {
                return !isDeposit;
            }
        }
        public Transaction(decimal amount, TransactionType transactionType) {
            Amount = amount;
            TransactionType = transactionType;
            DateOfTransaction = DateTime.Now;
        }
    }
}
