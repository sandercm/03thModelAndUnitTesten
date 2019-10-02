using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Models.Domain {
    public class SavingsAccount : BankAccount {
        private const decimal WithdrawCost = 0.25M;
        public decimal InterestRate { get; private set; }
        public SavingsAccount(string account, decimal interestRate) : base(account) {
            InterestRate = interestRate;
        }

        public override void Withdraw(decimal amount) {
            base.Withdraw(amount);
            base.Withdraw(WithdrawCost);
        }
        public void AddInterest() {
            Deposit(Balance * InterestRate);
        }
    }
}
