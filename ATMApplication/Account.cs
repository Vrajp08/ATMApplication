using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication
{
    internal class Account
    {
        public int AccountNumber { get; }
        public string AccountHolderName { get; }
        public double Balance { get; private set; }
        private List<string> Transactions;

        public Account(int accountNumber, string accountHolderName, double initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
            Transactions = new List<string>();
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transactions.Add($"Deposited: ${amount}");
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Transactions.Add($"Withdrawn: ${amount}");
                Console.WriteLine("Withdrawal successful.");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: ${Balance}");
        }

        public void DisplayTransactions()
        {
            Console.WriteLine("Transaction History:");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
