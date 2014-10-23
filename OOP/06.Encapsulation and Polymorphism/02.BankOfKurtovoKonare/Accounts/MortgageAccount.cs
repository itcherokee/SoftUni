namespace Banking.Accounts
{
    using System;
    using Customers;
    using Interfaces;

    public class MortgageAccount : Account, IDepositable
    {
        private decimal mortageAmount;

        public MortgageAccount(Customer customer, decimal monthlyInterestRate, decimal mortageAmount, DateTime accountStartDate = default(DateTime))
            : base(customer, monthlyInterestRate, accountStartDate)
        {
            this.MortageAmount = mortageAmount;
            this.Balance = this.MortageAmount;
        }

        public decimal MortageAmount
        {
            get
            {
                return this.mortageAmount;
            }

            private set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("value", "Negative or Zero mortages are not allowed!");
                }

                this.mortageAmount = value;
            }
        }

        public decimal MortageDueAmount
        {
            get
            {
                return this.MortageAmount + this.Interest() - this.Balance;
            }
        }

        protected override int MonthsWithInterest
        {
            get
            {
                if (this.Customer is Individual)
                {
                    return this.AccountAgeInMonths - 6 <= 0 ? 0 : this.AccountAgeInMonths - 6;
                }

                if (this.AccountAgeInMonths >= 12)
                {
                    // Company has account for more than 12 months: first 12 months are on half interest
                    return this.AccountAgeInMonths - 6;
                }

                // Company has account for less than 12 months
                return this.AccountAgeInMonths / 2;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("amount", "Negative or Zero mortage's deposits are not allowed!");
            }

            if (amount > this.MortageDueAmount)
            {
                throw new ArgumentOutOfRangeException("amount", "Deposit overcome the mortage amount + interest! Reduce the deposit!");
            }

            this.Balance += amount;
        }
    }
}