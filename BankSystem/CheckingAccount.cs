
/// <summary>
/// Klasë që përfaqëson një llogari rrjedhëse, e cila trashëgon nga BankAccount.
/// </summary>
public class CheckingAccount : BankAccount
{
    private int dailyWithdrawals = 0;
    private const int MaxWithdrawalsPerDay = 3;   //Shtimi i limitit per terheqje maksimale mbrenda dites

    public CheckingAccount(string accountNumber, string ownerName, decimal initialBalance)
        : base(accountNumber, ownerName, initialBalance) { }


    /// <summary>
    /// Metodë e mbishkruar që kufizon tërheqjet në maksimum 3 herë brenda një dite.
    /// </summary>
    /// <param name="amount">Shuma që do të tërhiqet.</param>
    public override bool Withdraw(decimal amount)
    {
        if (dailyWithdrawals < MaxWithdrawalsPerDay)
        {
            if (base.Withdraw(amount))
            {
                dailyWithdrawals++;
                return true;
            }
        }
        else
        {
            Console.WriteLine("Daily withdrawal limit reached.");
        }
        return false;
    }
}
