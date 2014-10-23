namespace Banking
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Accounts;

    public class Bank
    {
        private readonly List<Account> accounts = new List<Account>();
        private string name;

        public Bank(string name)
        {
            this.accounts = new List<Account>();
            this.name = name;
        }

        public IEnumerable<Account> Accounts
        {
            get
            {
                return this.accounts.AsReadOnly();
            }
        }

        public void CreateAccount(Account account)
        {
            if (account != null)
            {
                this.accounts.Add(account);
            }
            else
            {
                throw new ArgumentNullException("account", "Can not create null acount!");
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            if (this.accounts.Count > 0)
            {
                foreach (var account in this.Accounts)
                {
                    output.AppendLine(account.ToString());
                }
            }
            else
            {
                output.Append("none");
            }

            return output.ToString();
        }
    }
}