using BankOfSuccess.Console.EntityLayer;
using BankOfSuccrss.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccrss.Console.BusinessLogiceLayer
{
    
    public class InsurenceLog
    {

        private static Dictionary<string, List<Insurence>> Insurences = new Dictionary<string, List<Insurence>>();
        public static void AddToLog(Insurence insurence, string accType)
        {
            if (!Insurences.ContainsKey(accType))
            {
                Insurences .Add(accType, new List<Insurence>());

            }

            Insurences[accType].Add(insurence);
        }
        public static Dictionary<string, List<Insurence>> GetAccountsFromLog()
        {
            return Insurences;
        }
    }
}
//private static Dictionary<string, List<Account>> Accounts = new Dictionary<string, List<Account>>();
//public static void AddToLog(Account account, string accType)
//{
//    if (!Accounts.ContainsKey(accType))
//    {
//        Accounts.Add(accType, new List<Account>());

//    }

//    Accounts[accType].Add(account);
//}
//public static Dictionary<string, List<Account>> GetAccountsFromLog()
//{
//    return Accounts;
//}