using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Klasë bazë që përfaqëson një llogari bankare.
/// </summary>
public class BankAccount
{
    /// <summary>
    /// Numri unik i llogarisë.
    /// </summary>
    public string AccountNumber { get; private set; }

    /// <summary>
    /// Emri i pronarit të llogarisë.
    /// </summary>
    public string OwnerName { get; set; }

    /// <summary>
    /// Bilanci aktual i llogarisë.
    /// </summary>
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

    /// <summary>
    /// Metodë për të depozituar një shumë të caktuar në llogari.
    /// </summary>
    /// <param name="amount">Shuma që do të depozitohet.</param>
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

    /// <summary>
    /// Metodë virtuale për tërheqjen e fondeve nga llogaria.
    /// </summary>
    /// <param name="amount">Shuma që do të tërhiqet.</param>
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
            transactionHistory.RemoveAt(0); 
        }

        var transaction = new Transaction(type, amount);
        transactionHistory.Add(transaction);

        // Append to file
        File.AppendAllText("transactions.txt", $"{AccountNumber} | {transaction}\n");
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Owner Name: {OwnerName}");
        Console.WriteLine($"Balance: {Balance:C}");
    }

    public void ShowTransactionHistory()
    {
        Console.WriteLine($"Transaction History for {AccountNumber}:");
        foreach (var transaction in transactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
}
