using BankOfSuccrss.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.EntityLayer
{
    public class Account
    {
        static int count = 999;
        public DebitCard DebitCard { get; set; }
        public DebitCardStatus DebitCardStatus { get; set; }
         public CreditCard CreditCard { get; set; }
        public CreditCardStatus CreditCardStatus { get; set; }
        public InsurenceStatuse InsurenceStatuse { get; set; }
        public Insurence Insurences { get; set; }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public int PinNumber { get; set; }
        public double Balance { get; set; }
        public Privilge Privilge { get; set; }
        public bool IsActive { get; set; }
        public DateTime ActivatedDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public Account()
        {
            count++;
            this.AccountNumber = count;
        }

    }
    

    

}
