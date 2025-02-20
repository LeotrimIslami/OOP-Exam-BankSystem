using System;

public class Transaction
{
    public DateTime Date { get; }
    public string Type { get; }
    public decimal Amount { get; }

    public Transaction(string type, decimal amount)
    {
        Date = DateTime.Now;
        Type = type;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Date:G} | {Type} | {Amount:C}";
    }
}
