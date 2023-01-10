using BankOfSuccess.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    public interface IAccountImpl
    {
        bool Open(Account account);

    }
}
