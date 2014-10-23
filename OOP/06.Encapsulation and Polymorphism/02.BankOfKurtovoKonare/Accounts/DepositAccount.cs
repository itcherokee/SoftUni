namespace Banking.Accounts
{
    using System;
    using Customers;
    using Interfaces;

    public class DepositAccount : Account, IWithdrawable, IDepositable
    {
        public DepositAccount(Customer customer, decimal monthlyInterestRate, decimal initialAmount, DateTime accountStartDate = default(DateTime))
            : base(customer, monthlyInterestRate, accountStartDate)
        {
            this.Deposit(initialAmount);
        }

        protected override int MonthsWithInterest
        {
            get
            {
                return this.Balance < 1000 ? 0 : this.AccountAgeInMonths;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("amount", "Negative or Zero withdraws are not allowed!");
            }

            if (this.Balance - amount < 0.0m)
            {
                throw new ArgumentOutOfRangeException("amount", "Not enought money in the account!");
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("amount", "Negative or Zero deposits are not allowed!");
            }

            this.Balance += amount;
        }
    }
}
