namespace Banking.Accounts
{
    using System;
    using Customers;
    using Interfaces;

    public class LoanAccount : Account, IDepositable
    {
        private decimal loanAmount;

        public LoanAccount(Customer customer, decimal monthlyInterestRate, decimal loanAmount, DateTime accountStartDate = default(DateTime))
            : base(customer, monthlyInterestRate, accountStartDate)
        {
            this.LoanAmount = loanAmount;
            this.Balance = this.LoanAmount;
        }

        public decimal LoanAmount
        {
            get
            {
                return this.loanAmount;
            }

            private set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("value", "Negative or Zero loans are not allowed!");
                }

                this.loanAmount = value;
            }
        }

        public decimal LoanDueAmount
        {
            get
            {
                return this.LoanAmount + this.Interest() - this.Balance;
            }
        }

        protected override int MonthsWithInterest
        {
            get
            {
                if (this.Customer is Individual)
                {
                    return ((this.AccountAgeInMonths - 3) <= 0) ? 0 : this.AccountAgeInMonths - 3;
                }

                return ((this.AccountAgeInMonths - 2) <= 0) ? 0 : this.AccountAgeInMonths - 2;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("amount", "Negative or Zero loan's deposits are not allowed!");
            }

            if (amount > this.LoanDueAmount)
            {
                throw new ArgumentOutOfRangeException("amount", "Deposit overcome the loan amount + interest! Reduce the deposit!");
            }

            this.Balance += amount;
        }
    }
}