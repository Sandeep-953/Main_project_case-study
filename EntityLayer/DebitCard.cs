using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccrss.Console.EntityLayer
{
    public class DebitCard
    {
        public static long count = 999999999999;
        public static int cvvGenerator = 123;
        public static int pinGenerator = 1256;
        public long CardNumber { get; set; }
        public int Cvv { get; set; }
        public int Pin { get; set; }
        public bool IsCardActive { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public DebitCard()
        {
            count++;
            cvvGenerator++;
            pinGenerator++;
            CardNumber = count;
            Cvv = cvvGenerator;
            Pin = pinGenerator;
            IsCardActive = false;
            ExpiryDate = DateTime.Now.AddYears(5);
        }
    }
}
