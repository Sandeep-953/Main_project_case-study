using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccrss.Console.EntityLayer
{
    public class DebitCardStatus
    {
        public static int tempId = 11191;
        public DateTime RequestedDate { get; set; }
        public int RequestId { get; set; }
        public string Status { get; set; }

        public DebitCardStatus(string status)
        {
            tempId++;
            RequestId = tempId;
            RequestedDate = DateTime.Now;
            Status = status;
        }

    }
}
