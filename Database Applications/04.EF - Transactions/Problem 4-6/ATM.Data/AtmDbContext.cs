namespace ATM.Data
{
    using System.Data.Entity;
    using Model;

    public class AtmDbContext : DbContext
    {
        public AtmDbContext()
            : base("Atm")
        {
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionHistory> TransactionsHistory { get; set; }
    }
}