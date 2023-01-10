using BankOfSuccess.Console.EntityLayer;
using BankOfSuccrss.Console.ExceptionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    public class AccountRepository
    {
        private static List<Account> AccountLog = new List<Account>();

        //Adding account to Account log
        public static void AddToRepository(Account account)
        {
            AccountLog.Add(account);
        }

        //Retrive Account details from Account Log using GetAccount method
        public static Account GetAccount(int accNo)
        {
            Account account = null;
            foreach (Account acc in AccountLog)
            {
                if (acc.AccountNumber == accNo)
                {
                    account = acc;
                }

            }
            if (account == null)
            {
                throw new AccountNotFoundException("Account Not Found!");
            }
            return account;
        }
    }
}
