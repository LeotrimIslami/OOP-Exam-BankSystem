using System;
using System.Collections.Generic;
using System.IO;

public class BankAccount //Krijimi i klases baze BankAccount
{
    public string AccountNumber { get; private set; }
    public string OwnerName { get; set; }
    public decimal Balance { get; protected set; }

    //Shtimi i listes per transaksione
    private List<Transaction> transactionHistory = new List<Transaction>();


    //Krijimi i llogaris me detaje
    public BankAccount(string accountNumber, string ownerName, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }
}

public void Deposit(decimal amount)   //Depozimi i parave ne llogari
{
    if (amount > 0)
    {
        Balance += amount;
        AddTransaction("Deposit", amount);
        Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
    }
    else
    {
        Console.WriteLine("Deposit amount must be positive.");
    }
}

public virtual bool Withdraw(decimal amount)   //Terheqja e parave nga llogaria nese balanci eshte i mjaftueshem
{
    if (amount > 0 && amount <= Balance)
    {
        Balance -= amount;
        AddTransaction("Withdraw", amount);
        Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
        return true;
    }
    else
    {
        Console.WriteLine("Insufficient funds or invalid amount.");
        return false;
    }
}

private void AddTransaction(string type, decimal amount)
{
    if (transactionHistory.Count == 10)
    {
        transactionHistory.RemoveAt(0); // Remove oldest transaction
    }

    var transaction = new Transaction(type, amount);
    transactionHistory.Add(transaction);

    // Append to file
    File.AppendAllText("transactions.txt", $"{AccountNumber} | {transaction}\n");
}
}