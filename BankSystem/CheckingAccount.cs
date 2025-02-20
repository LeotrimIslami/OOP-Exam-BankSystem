public class CheckingAccount : BankAccount    //Krijimi i klases CheckingAccount nga klasa baze BankAccount
{

    public CheckingAccount(string accountNumber, string ownerName, decimal initialBalance)
        : base(accountNumber, ownerName, initialBalance) { }
}
