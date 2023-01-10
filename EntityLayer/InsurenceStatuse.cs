using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccrss.Console.EntityLayer
{
    public class InsurenceStatuse
    {
        public static int temp = 1234;
        public DateTime RequstDate { get; set; }
        public int RequstId {  get; set; }
        public string  Statuse { get; set; }
        public InsurenceStatuse( string Statuse)
        {
            temp++;
            RequstId = temp;
            this.Statuse= Statuse;
        }

    }
}
