using System;
using System.Collections.Generic;

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();    //Shtimi i Listes se llogarive bankare

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Create Account\n2. Deposit\n3. Withdraw\n4. View Account\n5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    MakeDeposit();
                    break;
                case "3":
                    MakeWithdrawal();
                    break;
                case "4":
                    ViewAccount();
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0); // ✅ This closes the console
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        //Shtimi i metodes se krijimit te Llogarive
        static void CreateAccount()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter owner name: ");
            string ownerName = Console.ReadLine();
            Console.Write("Enter initial deposit: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            Console.Write("Account type (1 = Savings, 2 = Checking): ");
            string type = Console.ReadLine();

            BankAccount account;
            if (type == "1")
                account = new SavingsAccount(accountNumber, ownerName, initialBalance);
            else
                account = new CheckingAccount(accountNumber, ownerName, initialBalance);

            accounts.Add(account);
            Console.WriteLine("Account created successfully!");
        }

        static void MakeDeposit()
        {
            BankAccount account = FindAccount();
            if (account != null)
            {
                Console.Write("Enter deposit amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                account.Deposit(amount);
            }
        }


        static void MakeWithdrawal()
        {
            BankAccount account = FindAccount();
            if (account != null)
            {
                Console.Write("Enter withdrawal amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                account.Withdraw(amount);
            }
        }
    }
}
