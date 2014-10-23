namespace Banking
{
    using System;
    using Accounts;
    using Customers;

    public class TestRun
    {
        public static void Main()
        {
            Bank bank = new Bank("SoftUni Bank");
            var e = bank.Accounts;
            foreach (var account in e)
            {
                Console.WriteLine(account);
            }

            try
            {
                Individual clientOne = new Individual("Pencho Pitankata", "Neyde", "1212121230");
                Company clientTwo = new Company("SoftUni", "Hadji Dimitar", "831251119", true);
                DepositAccount depositOne = new DepositAccount(clientOne, 5, 10000);
                DepositAccount depositTwo = new DepositAccount(clientOne, 2, 100, new DateTime(2000, 01, 01));
                DepositAccount depositThree = new DepositAccount(clientOne, 2, 10000, new DateTime(2008, 01, 01));
                LoanAccount loanOne = new LoanAccount(clientOne, 14, 10000, new DateTime(2003, 01, 01));
                LoanAccount loanTwo = new LoanAccount(clientTwo, 14, 10000, new DateTime(2003, 01, 01));
                MortgageAccount mortgageOne = new MortgageAccount(clientOne, 7, 100000, new DateTime(2013, 08, 01));
                MortgageAccount mortgageTwo = new MortgageAccount(clientTwo, 7, 100000, new DateTime(2014, 08, 01));
                Console.WriteLine("Deposit Account 1 Interest: {0:F2}", depositOne.Interest());
                Console.WriteLine("Deposit Account 2 Interest: {0:F2}", depositTwo.Interest());
                Console.WriteLine("Deposit Account 3 Interest: {0:F2}", depositThree.Interest());
                Console.WriteLine("Loan Account Individual Interest: {0:F2}", loanOne.Interest());
                Console.WriteLine("Loan Account Company Interest: {0:F2}", loanTwo.Interest());
                Console.WriteLine("Mortgage Account Interest: {0:F2}", mortgageOne.Interest());
                Console.WriteLine("Mortgage Account Interest: {0:F2}", mortgageTwo.Interest());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}