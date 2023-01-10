using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.EntityLayer
{
    public class Transfer
    {

        //Entity class for defining structure of Transfer


        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public double Amount { get; set; }
        public int PinNumber { get; set; }
        public TransferMode Mode { get; set; }
      

        



    }
}
