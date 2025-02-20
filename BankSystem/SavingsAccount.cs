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
}
