using BankOfSuccess.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    public class AccountLog
    {
        private static Dictionary< string ,List<Account>> Accounts = new Dictionary<string, List<Account>>();
        public static void AddToLog(Account account, string accType)
        {
            if(!Accounts.ContainsKey(accType)) 
            { 
                Accounts.Add(accType, new List<Account>()); 
                    
            }

            Accounts[accType].Add(account); 
        } 
        public static Dictionary< string,List<Account>> GetAccountsFromLog()
        {
            return Accounts;
        }
    }
}
