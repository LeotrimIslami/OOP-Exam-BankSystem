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
    }
}
