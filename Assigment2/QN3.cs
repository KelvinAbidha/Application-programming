using System;

// Base class for both account types
class BankAccount
{
    public string AccountNo;
    public string Name;
    public decimal Balance;

    public BankAccount(string no, string name, decimal bal)
    {
        AccountNo = no;
        Name = name;
        Balance = bal;
    }

    // Deposit money into the account
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine("Deposited: " + amount);
    }

    // Check current account balance
    public void CheckBalance()
    {
        Console.WriteLine("Balance: " + Balance);
    }
}

// Savings account: earns interest and doesn't allow overdraft
class SavingsAccount : BankAccount
{
    public SavingsAccount(string no, string name, decimal bal) : base(no, name, bal) { }

    // Withdraw only if balance is enough
    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
        else
        {
            Console.WriteLine("Not enough balance.");
        }
    }

    // Add interest to the balance
    public void AddInterest(decimal rate)
    {
        Balance += Balance * rate;
        Console.WriteLine("Interest added.");
    }
}

// Current account: allows overdraft up to a limit
class CurrentAccount : BankAccount
{
    public decimal Overdraft;

    public CurrentAccount(string no, string name, decimal bal, decimal overdraft)
        : base(no, name, bal)
    {
        Overdraft = overdraft;
    }

    // Withdraw allowed up to (balance + overdraft)
    public void Withdraw(decimal amount)
    {
        if (amount <= Balance + Overdraft)
        {
            Balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
        else
        {
            Console.WriteLine("Overdraft limit exceeded.");
        }
    }
}

// Test program
class Program
{
    static void Main()
    {
        SavingsAccount sa = new SavingsAccount("S01", "Alice", 1000);
        Console.WriteLine($"Account Holder: {sa.Name} | Account No: {sa.AccountNo}");

        sa.CheckBalance();
        sa.Deposit(100);
        sa.Withdraw(200);
        sa.AddInterest(0.05m); // 5% annual interest
        sa.CheckBalance();

        Console.WriteLine("");
        CurrentAccount ca = new CurrentAccount("C01", "Bob", 500, 300);
        Console.WriteLine($"Account Holder: {ca.Name} | Account No: {ca.AccountNo}");

        ca.CheckBalance();
        ca.Withdraw(600); // allowed with overdraft
        ca.CheckBalance();
        ca.Withdraw(300); // exceeds overdraft
        ca.CheckBalance();
    }
}
