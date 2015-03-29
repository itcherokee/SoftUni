namespace ATM.Client
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Core;
    using System.Linq;

    using Data;
    using Model;

    public class AtmClient
    {
        public static void Main()
        {
            // Uncomment below line if you have no database import (SQL script) and need DB + data to be created by EF
            // SeedData();

            if (Withdraw("1234567890", "0000", 200))
            {
                Console.WriteLine("Money have been successfuly withdrawn!");
            }
        }

        private static void SeedData()
        {
            using (var context = new AtmDbContext())
            {
                IList<CardAccount> accounts = new List<CardAccount>
               {
                   new CardAccount {CardNumber = "1234567890", CardPIN = "0000", CardCash = 1000m},
                   new CardAccount {CardNumber = "0123456789", CardPIN = "1234", CardCash = 0},
                   new CardAccount {CardNumber = "2034567899", CardPIN = "4321", CardCash = 199},
                   new CardAccount {CardNumber = "1111111111", CardPIN = "0001", CardCash = 200},
               };

                if (!context.CardAccounts.Any())
                {
                    foreach (var account in accounts)
                    {
                        context.CardAccounts.Add(account);
                    }

                    context.SaveChanges();
                }
            }
        }

        private static bool Withdraw(string account, string pin, decimal amount)
        {
            bool isSuccessful = false;

            using (var context = new AtmDbContext())
            {
                using (var transaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    var accountToWithdraw = context.CardAccounts.FirstOrDefault(n => n.CardNumber == account);
                    try
                    {
                        ValidateAccount(accountToWithdraw, pin);
                        CheckForEnoughFunds(accountToWithdraw, amount);
                        accountToWithdraw.CardCash -= amount;
                        context.SaveChanges();
                        transaction.Commit();
                        RecordWithdrawOperation(context, accountToWithdraw, amount);
                        isSuccessful = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                    catch (OptimisticConcurrencyException e)
                    {
                        Console.WriteLine("There is a conflict with that transaction, try again.");
                        transaction.Rollback();
                    }
                }
            }

            return isSuccessful;
        }

        private static void RecordWithdrawOperation(AtmDbContext context, CardAccount account, decimal amount)
        {
            context.TransactionsHistory.Add(new TransactionHistory
            {
                CardNumber = account.CardNumber,
                TransactionDate = DateTime.Now,
                Amount = amount
            });

            context.SaveChanges();
        }

        private static void CheckForEnoughFunds(CardAccount account, decimal amount)
        {
            if (account == null)
            {
                throw new ArgumentNullException("account", "There is no such account in the DB");
            }

            if (account.CardCash < amount)
            {
                throw new ArgumentException("Not enough funds available in the selected account.", "amount");
            }
        }

        private static void ValidateAccount(CardAccount account, string pin)
        {
            if (account == null)
            {
                throw new ArgumentNullException("account", "There is no such account in the DB");
            }

            if (account.CardPIN != pin)
            {
                throw new ArgumentException("Invalid PIN for the selected account provided.", "pin");
            }
        }
    }
}
