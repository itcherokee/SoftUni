namespace Banking.Accounts
{
    using System;
    using System.Text;
    using Customers;

    public abstract class Account
    {
        private decimal balance;
        private decimal monthlyInterestRate;

        protected Account(Customer customer, decimal monthlyInterestRate, DateTime accountStartDate = default(DateTime))
        {
            this.AccountStartDate = accountStartDate == default(DateTime) ? DateTime.Today : accountStartDate;
            this.MonthlyInterestRate = monthlyInterestRate;
            this.Customer = customer;
            this.Balance = 0.0m;
        }

        public Customer Customer { get; private set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                if (value >= 0.0m)
                {
                    this.balance = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "Negative amounts are not allowed!.");
                }
            }
        }

        public decimal MonthlyInterestRate
        {
            get
            {
                return this.monthlyInterestRate;
            }

            protected set
            {
                if (value >= 0.0m)
                {
                    this.monthlyInterestRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "Negative amounts are not allowed!.");
                }
            }
        }

        public DateTime AccountStartDate { get; private set; }

        protected int AccountAgeInMonths
        {
            get
            {
                return Math.Abs((DateTime.Today.Month - this.AccountStartDate.Month) + (12 * (DateTime.Today.Year - this.AccountStartDate.Year)));
            }
        }

        protected abstract int MonthsWithInterest { get; }

        public virtual decimal Interest()
        {
            return this.Balance * (1 + (this.MonthlyInterestRate * this.MonthsWithInterest));
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append("Acount:" + this.GetType().Name);
            return output.ToString();
        }
    }
}
