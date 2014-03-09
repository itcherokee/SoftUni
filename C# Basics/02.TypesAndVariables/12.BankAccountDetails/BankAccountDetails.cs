using System;

/// <summary>
/// Task:   14. A bank account has a holder name (first name, middle name and last name), available amount 
///         of money (balance), bank name, IBAN, 3 credit card numbers associated with the account. 
///         Declare the variables needed to keep the information for a single bank account using the appropriate 
///         data types and descriptive names.
/// </summary>
public class BankAccountDetails
{
    private string firstName;
    private string middleName;
    private string lastName;
    private decimal balance;
    private string bank;
    private string iban;
    private string bic;
    private ulong cardOne;
    private ulong cardTwo;
    private ulong cardThree;

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public string MiddleName
    {
        get { return this.middleName; }
        set { this.middleName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public decimal Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }

    public string Bank
    {
        get { return this.bank; }
        set { this.bank = value; }
    }

    public string Iban
    {
        get { return this.iban; }
        set { this.iban = value; }
    }

    public string Bic
    {
        get { return this.bic; }
        set { this.bic = value; }
    }

    public ulong CardOne
    {
        get { return this.cardOne; }
        set { this.cardOne = value; }
    }

    public ulong CardTwo
    {
        get { return this.cardTwo; }
        set { this.cardTwo = value; }
    }

    public ulong CardThree
    {
        get { return this.cardThree; }
        set { this.cardThree = value; }
    }
}
