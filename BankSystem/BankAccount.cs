using System;
using System.Collections.Generic;
using System.IO;

public class BankAccount //Krijimi i klases baze BankAccount
{
    public string AccountNumber { get; private set; }
    public string OwnerName { get; set; }
    public decimal Balance { get; protected set; }


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
