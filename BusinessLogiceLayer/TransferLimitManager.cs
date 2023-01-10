using BankOfSuccess.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    public class TransferLimitManager
    {
        //Dictionary for Privilge(key value pair)
        private static Dictionary<Privilge, double> TransferLimit = new Dictionary<Privilge, double>();

        //TransferLimitmanager which check transfer limit on daily basis  
        static TransferLimitManager()
        {
            //Store limits in the dictionary
            TransferLimit.Add(Privilge.PREMIUM, 100000.00);
            TransferLimit.Add(Privilge.GOLD, 50000.00);
            TransferLimit.Add(Privilge.SILVER, 25000);
        }

        //Getting the transfer limit from dictionary TransferLimit
        public static double GetTransferLimit(Privilge privilge)
        {
            return TransferLimit[privilge];
        }

    }
}
