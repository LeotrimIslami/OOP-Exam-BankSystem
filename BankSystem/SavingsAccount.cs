
/// <summary>
/// Klasë që përfaqëson një llogari kursimi, e cila trashëgon nga BankAccount.
/// </summary>
public class SavingsAccount : BankAccount    //Krijimi i klases SavingsAccount duke perdorur klasen baze BankAccount
{
    private const decimal InterestRate = 0.03m; // 3% interest

    //Llogaria dhe shtimi i interesit ne balance
    public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance)
        : base(accountNumber, ownerName, initialBalance) { }

    /// <summary>
    /// Metodë që llogarit interesin vjetor për llogarinë e kursimit.
    /// </summary>
    /// <returns>Shuma e interesit të fituar.</returns>
    public void CalculateInterest()
    {
        decimal interest = Balance * InterestRate;
        Deposit(interest);
        Console.WriteLine($"Interest of {interest:C} added.");
    }

    /// <summary>
    /// Metodë e mbishkruar që kufizon tërheqjen e fondeve në maksimum 50% të bilancës.
    /// </summary>
    /// <param name="amount">Shuma që do të tërhiqet.</param>
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

