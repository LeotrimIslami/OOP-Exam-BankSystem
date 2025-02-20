public class CheckingAccount : BankAccount    //Krijimi i klases CheckingAccount nga klasa baze BankAccount
{
    private int dailyWithdrawals = 0;
    private const int MaxWithdrawalsPerDay = 3;   //Shtimi i limitit per terheqje maksimale mbrenda dites

    public CheckingAccount(string accountNumber, string ownerName, decimal initialBalance)
        : base(accountNumber, ownerName, initialBalance) { }


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
