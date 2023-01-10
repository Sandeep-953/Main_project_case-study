using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    public class AccountImplFactory
    {

        //Static Method which return type IAccountImpl we can access this using  class name. 
        public static IAccountImpl Create(string accType)
        {
            
            IAccountImpl accountImpl = null;
            //If account type savings then it create instance of savings
            if (accType.Equals("Savings"))
                accountImpl = new SavingsImpl();

            //If account type savings then it create instance of current
            if (accType.Equals("Current"))
                accountImpl = new CurrentImpl();

            return accountImpl;

        }
    }
}
