
using BankOfSuccess.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    public class TransactionLog
    {
        private static List<Transaction> Transactions = new List<Transaction>();
        public static void AddToLog(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
        public static List<Transaction> GetTransfersFromLog(Account fromAccount)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (Transaction t in Transactions)
            {
                if (t.FromAccount.AccountNumber == fromAccount.AccountNumber)
                {
                    transactions.Add(t);
                }
            }
            return transactions;
        }
    }
}
