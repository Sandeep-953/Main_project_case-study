using BankOfSuccess.Console.EntityLayer;
using BankOfSuccrss.Console.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccrss.Console.BusinessLogiceLayer
{
   

    public class InsurenceLimitmanger
    {
        private static Dictionary<InsurenceLimit, double> TnsurenceLimit = new Dictionary<InsurenceLimit, double>();

        static InsurenceLimitmanger()
        {
            TnsurenceLimit.Add(InsurenceLimit.Current, 20000000);
            TnsurenceLimit.Add(InsurenceLimit.Saving, 10000000);


        }
        public static double GetInsurenceLimitmanger(InsurenceLimit insurenceLimit)
        {
            return TnsurenceLimit[insurenceLimit];
        }
        
        

    }
}
