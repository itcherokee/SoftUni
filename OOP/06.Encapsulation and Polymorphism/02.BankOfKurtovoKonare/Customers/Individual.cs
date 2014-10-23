namespace Banking.Customers
{
    using System;
    using Utils;

    public class Individual : Customer
    {
        private string egn;

        public Individual(string name, string address, string egn)
            : base(name, address)
        {
            this.Egn = egn;
        }

        public string Egn
        {
            get
            {
                return this.egn;
            }

            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("value", "No EGN provided!");
                }

                if (EgnValidator.IsValid(value))
                {
                    this.egn = value;
                }
                else
                {
                    throw new ArgumentException("Invalid EGN provided!");
                }
            }
        }
    }
}
