using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccrss.Console.EntityLayer
{
    public class CreditCard
    {
        public static int cvvGenerator = 123;
        public static int PinGenerator = 1234;
        public static int count = 999999999;
        public long CardNumber { get; set; }
        public int Cvv { get; set; }
        public int Pin { get; set; }
        public bool IsCardActive { get; set; }
        public DateTime ActivateionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public CreditCard()
        {
            count++;
            cvvGenerator++;
            PinGenerator++;
            CardNumber= count;
            Cvv=cvvGenerator;
            Pin=PinGenerator; 
            IsCardActive= false;
            ExpiryDate= DateTime.Now.AddYears(5);

        }

    }
}
