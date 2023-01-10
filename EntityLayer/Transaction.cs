using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.EntityLayer
{
    public class Transaction
    {

        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public double Amount { get; set; }
        public int AccountNo { get; set; }
        public TransferMode Mode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }

        public Transaction()
        {
        }
        public Transaction(Account fromAcc, Account toAcc, double amount, TransferMode mode, DateTime transactionDate, string transactionType)
        {
            FromAccount = fromAcc;
            ToAccount = toAcc;
            Amount = amount;
            Mode = mode;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
        }
    }
}
