using BankOfSuccess.Console.EntityLayer;
using BankOfSuccrss.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    public class AccountReportManager
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Insurence> insurences= new List<Insurence>();
        public static List<Account> GetAccountsOpenedBetweenDate(DateTime fromDate, DateTime toDate)
       
        {
            // write code to get Accountn from Account log which are between given about
            Dictionary<string, List<Account>> Accountsreoprt = AccountLog.GetAccountsFromLog();

            foreach (KeyValuePair<string, List<Account>> account in Accountsreoprt)
            {

                foreach (var value in account.Value)
                {
                    if ((value.ActivatedDate >= fromDate) && (value.ActivatedDate <= toDate))
                    {
                        accounts.Add(value);
                        
                    }
                }
            }
            return accounts;
        }
        


        
    }
}
