using BankOfSuccess.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{/// <summary>
 /// //Class for store and retrive Transfers using list
 /// </summary>
    public class TransferLog
    {
        private static List<Transfer> Transfers = new List<Transfer>();
        //Adding transfer details to  Transfer log
        public static void AddToLog(Transfer transfer)
        {
            Transfers.Add(transfer);
        }
        //Retrive transfer details from Transfer(list) using GetTransferFromLog method and it return a list transfers
        public static List<Transfer> GetTransfersFromLog(Account fromAccount)
        {
            List<Transfer> transfers = new List<Transfer>();

            foreach (Transfer transfer in Transfers)
            {
                if (transfer.FromAccount.AccountNumber == fromAccount.AccountNumber)
                {
                    transfers.Add(transfer);
                }
            }
            return transfers;
        }
    }
}
