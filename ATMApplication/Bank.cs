using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication
{
    internal class Bank
    {
        private List<Account> accounts = new List<Account>();

        public Bank()
        {
            CreateDefaultAccounts();
        }

        private void CreateDefaultAccounts()
        {
            for (int i = 100; i < 110; i++)
            {
                accounts.Add(new Account(i, $"User{i}", 100));
            }
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account RetrieveAccount(int accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }
    }
}
