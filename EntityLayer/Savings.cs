using BankOfSuccrss.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.EntityLayer
{
    public class Savings :Account
    {
        //Entity class-that defines the structure of Current inherting from Account
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string PhoneNo { get; set; }
        public Nominee nominee{ get; set; }
    }
}
