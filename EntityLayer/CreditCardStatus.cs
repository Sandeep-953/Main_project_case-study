using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccrss.Console.EntityLayer
{
    public class CreditCardStatus
    {
        public static int TempId=12345;
        public DateTime RequestedDate { get; set; }
        public int  RequstId{ get; set; }
        public string Status { get; set; }
        public CreditCardStatus(string status)
        {
            TempId++;
            this.RequstId=TempId;
            this.RequestedDate=  DateTime.Now;
            this.Status = status;


        }


    }
}
