using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccrss.Console.EntityLayer
{
    public class Insurence
    {
        public static int count = 1111;
        public int InsuraceNo { get; set; }
        public string NameOfInsurance{ get; set; }
        public DateTime ExpiryMonth { get; set; }
        public DateOnly Year { get; set; }
        public DateTime Issued { get; set; }
        public bool IsActive { get; set; }
        public Nominee Nominees { get; set; }
        Insurence()
        {
            count++;
            InsuraceNo= count;
        }
    }
     public enum InsurenceLimit
    {
        Saving,Current
    }
}
