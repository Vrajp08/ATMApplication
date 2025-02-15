using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication
{
    internal class AtmApplication
    {
        private Bank bank = new Bank();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nATM Menu:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Select Account");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        SelectAccount();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            Console.Write("Enter Account Number: ");
            int accNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Account Holder Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Initial Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accNumber, name, balance);
            bank.AddAccount(newAccount);
            Console.WriteLine("Account successfully created!");
        }

        private void SelectAccount()
        {
            Console.Write("Enter Account Number: ");
            int accNumber = int.Parse(Console.ReadLine());
            Account account = bank.RetrieveAccount(accNumber);

            if (account != null)
            {
                while (true)
                {
                    Console.WriteLine("\nAccount Menu:");
                    Console.WriteLine("1. Check Balance");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. View Transactions");
                    Console.WriteLine("5. Exit");
                    Console.Write("Select an option: ");

                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            account.CheckBalance();
                            break;
                        case "2":
                            Console.Write("Enter amount to deposit: ");
                            double deposit = double.Parse(Console.ReadLine());
                            account.Deposit(deposit);
                            break;
                        case "3":
                            Console.Write("Enter amount to withdraw: ");
                            double withdraw = double.Parse(Console.ReadLine());
                            account.Withdraw(withdraw);
                            break;
                        case "4":
                            account.DisplayTransactions();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found. Please enter a valid account number.");
            }
        }
    }
}
