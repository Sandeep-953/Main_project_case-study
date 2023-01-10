using BankOfSuccrss.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.EntityLayer
{
    public class Current:Account
    {
        //Entity Class-that defines the structure of current inherting from Account class
        //Entity Class-that defines the structure of current inherting from Account class
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string RegistrationNo { get; set; }
        public Nominee nominee { get; set; }

    }
}