using BankOfSuccess.Console.EntityLayer;
using BankOfSuccrss.Console.ExceptionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    public class SavingsImpl : IAccountImpl
    {

        public bool Open(Account account)
        {
            bool isAccountOpened = false;
            //Downcast-Typecast
            Savings savings = account as Savings;
            try
            {
                IsAccountActive(savings);

                //1.Check if age<18 else throw exception
                IsAgeValid(savings.DateOfBirth);

                //activate account
                if (activateAccount(savings))
                {
                    //AccountRepository.AllAccounts.Add(savings);
                    AccountRepository.AddToRepository(savings);
                    isAccountOpened = true;
                }
                return isAccountOpened;
            }
            catch (AccountAlreadyExistException ex)
            {
                throw ex;
            }
            catch (InvalidAgeException ex)
            {
                throw ex;
            }
        }

        private bool IsAccountActive(Account account)
        {
            if (account.IsActive)
            {
                throw new AccountAlreadyExistException("Account already Opened.");
            }
            return true;
        }


        private bool IsAgeValid(DateTime dateOfBirth)
        {
            if (DateTime.Now.Year - dateOfBirth.Year < 18)
                throw new InvalidAgeException("Age is less than 18.");
            return true;
        }
        private bool activateAccount(Savings savings)
        {
            //Set IsActive variable true
            savings.IsActive = true;

            //Set activated date as current date.. 
            savings.ActivatedDate = DateTime.Now;
            return true;
        }
    }
}
