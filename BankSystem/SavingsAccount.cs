public class SavingsAccount : BankAccount    //Krijimi i klases SavingsAccount duke perdorur klasen baze BankAccount
{
    private const decimal InterestRate = 0.03m; // 3% interest

    //Llogaria dhe shtimi i interesit ne balance
    public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance)
        : base(accountNumber, ownerName, initialBalance) { }

    public void CalculateInterest()
    {
        decimal interest = Balance * InterestRate;
        Deposit(interest);
        Console.WriteLine($"Interest of {interest:C} added.");
    }

    //Vendosja e limit per terheqje nen 50% te depozites
public override bool Withdraw(decimal amount)
    {
        if (amount > Balance * 0.5m)
        {
            Console.WriteLine("Cannot withdraw more than 50% of balance.");
            return false;
        }
        return base.Withdraw(amount);
    }
}

