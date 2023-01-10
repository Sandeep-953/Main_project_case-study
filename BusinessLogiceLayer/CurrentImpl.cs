
using BankOfSuccess.Console.EntityLayer;
using BankOfSuccrss.Console.ExceptionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    internal class CurrentImpl :IAccountImpl
    {
        public bool Open(Account account)
        {
            bool isAccountOpened = false;
            //downcasting
            Current current = account as Current;
            try
            {
                //check if account already exits
                CheckIsAccountActive(current);
                //check Registration number is not null
                CheckRegistrationNumberIsNotNull(current.RegistrationNo);

                //set IsActive to true
                if (activateAccount(current))
                {
                    AccountRepository.AddToRepository(current);
                    isAccountOpened = true;
                }
                return isAccountOpened;
            }
            catch (AccountAlreadyExistException ex)
            {
                throw ex;
            }
            catch (InvalidRegistrationNumberException ex)
            {
                throw ex;
            }
        }
        public bool CheckIsAccountActive(Account account)
        {
            if (account.IsActive)
            {
                throw new AccountAlreadyExistException("Account already Opened.");
            }
            return true;
        }
        public bool CheckRegistrationNumberIsNotNull(string registrationNo)
        {
            if (registrationNo == "" || registrationNo == "\n" || registrationNo == null)
                throw new InvalidRegistrationNumberException("Registration Number is null.");
            return true;
        }
        public bool activateAccount(Current current)
        {
            //Set IsActive variable true
            current.IsActive = true;
            //Set activated date as current date.. 
            current.ActivatedDate = DateTime.Now;
            return true;
        }
    }
}
