
using BankOfSuccess.Console.EntityLayer;
using BankOfSuccrss.Console.BusinessLogiceLayer;
using BankOfSuccrss.Console.EntityLayer;
using BankOfSuccrss.Console.ExceptionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Console.BusinessLogiceLayer
{
    /// <summary>
    /// class that manages then activates of  Account
    /// Control class -Recieve  the  data from the  user and validate the  rules and and apply same
    /// </summary>
    public  class AccountManager
    {

        //Method for opening account
        public bool OpenAccount(Account account, string accType)
        {
            //Declaration..
            bool isAccountOpened = false;

            //Check wether account is saving or not(Dynamic Polymorphism)
            IAccountImpl accountImpl = AccountImplFactory.Create(accType);
            isAccountOpened = accountImpl.Open(account);
            // Add Account To log
            AccountLog.AddToLog(account,accType);
            // Add Insurance to log
            //InsurenceLog.AddToLog(insurence,accType);
            //InsurenceLog.AddToLog(insurence, accType);
            //add Account report mangere

            //Return status
            return isAccountOpened;
        }

        //Close account which are Opened
        public bool CloseAccount(Account account)
        {
            bool isAccountClosed = false;
            try
            {
                //Check if account already Closed
                CheckIsAccountClosed(account);
                CheckIsAccountActive(account.IsActive);
                DiscloseAccount(account);

            }
            catch (AccountIsAlreadyClosedException ex)
            {
                throw ex;
            }
            catch (AccountIsNotActiveException ex)
            {
                throw ex;
            }
            isAccountClosed = true;
            return isAccountClosed;
        }

        //Method for withdraw money from account
        public double Withdraw(int pin, double withdrawAmt, Account account)
        {
            bool isWithdrawn = false;
            try
            {
                if (CheckIsAccountActive(account.IsActive))
                {
                    if (CheckIfPinIsValid(pin, account.PinNumber))
                    {
                        if (IsSufficientBalance(account.Balance, withdrawAmt))
                        {
                            isWithdrawn = WithdrawnFunds(account, withdrawAmt);
                            // Transaction transaction = new Transaction(account, null, withdrawAmt, TransferMode.none, DateTime.Now, "Withdraw");
                            //TransactionLog.AddToLog(transaction);

                        }
                    }
                }
            }
            catch (AccountIsNotActiveException ex)
            {
                throw ex;
            }
            catch (InvalidPinNumberException ex)
            {
                throw ex;
            }
            catch (InSufficientBalanceException ex)
            {
                throw ex;
            }

            return account.Balance;
        }

        //Method for deposit money in account
        public double Deposit(Account account, double depositAmt)
        {
            bool isDeposited = false;
            try
            {
                if (CheckIsAccountActive(account.IsActive))
                {
                    isDeposited = DepositFunds(account, depositAmt);
                    //Transaction transaction = new Transaction(null, account, depositAmt, TransferMode.none, DateTime.Now, "Deposit");
                    //TransactionLog.AddToLog(transaction);
                }
            }
            catch (AccountIsNotActiveException ex)
            {
                throw ex;
            }
            return account.Balance;
        }

        //Transfer money from one account to another
        public double Transfer(Transfer transfer)
        {
            bool isTransferred = false;

            try
            {
                if (CheckIsAccountActive(transfer.FromAccount.IsActive) && CheckIsAccountActive(transfer.ToAccount.IsActive))
                {
                    if (CheckIfPinIsValid(transfer.FromAccount.PinNumber, transfer.PinNumber))
                    {
                        if (IsSufficientBalance(transfer.FromAccount.Balance, transfer.Amount))
                        {
                            //get daily transfer limit
                            double dailyTransferLimit = TransferLimitManager.GetTransferLimit(transfer.FromAccount.Privilge);

                            CheckIfTransferLimitExceeded(transfer, dailyTransferLimit);

                            if (WithdrawnFunds(transfer.FromAccount, transfer.Amount))
                            {
                                if (DepositFunds(transfer.ToAccount, transfer.Amount))
                                {
                                    TransferLog.AddToLog(transfer);
                                    //dTransfer.Invoke(transfer);

                                    isTransferred = true;
                                    //Transaction transaction = new Transaction(transfer.FromAccount, transfer.ToAccount, transfer.Amount, transfer.Mode, DateTime.Now, "Transfer");
                                    //TransactionLog.AddToLog(transaction);
                                }
                            }
                        }
                    }
                }
            }
            catch (AccountIsNotActiveException ex)
            {
                throw ex;
            }
            catch (InvalidPinNumberException ex)
            {
                throw ex;
            }
            catch (InSufficientBalanceException ex)
            {
                throw ex;
            }
            catch (TransferLimitExceededException ex)
            {
                throw ex;
            }

            return transfer.FromAccount.Balance;
        }

        // Add method to apployee iunsurence 
        public bool ApplyInsurence(Account accObj)
        {
            bool orderPlacced = false;
            // 1 chech account is active
            //2 account has alredy insurence
            // 3  chech 
            try
            {
                if (CheckIsAccountActive(accObj.IsActive))
                {

                    if (IfAccountHasAlreadyInsurence(accObj))
                    {
                        throw new AccountHasAlreadyInsurence("Insurence card has been already issued for this account .");
                    }

                    else if (CheckIfAppliedForInsurence(accObj))
                    {
                        throw new InsurenceHasBeenAlreadyRequestedException("Debit card has been already requested for this account and status is " + accObj.DebitCardStatus.Status);
                    }
                    else
                    {
                        //accObj.InsurenceRequest = new InsurenceRequest("requested");
                        // InsurenceStatus cardReq = new InsurencStatus("requested");
                        InsurenceStatuse insurenceReq = new InsurenceStatuse("requested");
                        accObj.InsurenceStatuse = insurenceReq;
                        //DebitCardRequestedRepository.AddToRepository(cardReq);
                       // accObj.Insurences = new Insurence();
                        //InsurenceRepository.AddToRepository(accObj.DebitCard);
                    }
                }
            }
            
            catch (AccountIsNotActiveException ex) { throw; }
            orderPlacced= true;
            return orderPlacced;

        }

       

        public bool ApplyDebitCard(Account accObj)
        {
            bool orderPlaced = false;
            try
            {
                if (CheckIsAccountActive(accObj.IsActive))
                {

                    if (IfAccountHasAlreadyDebitCard(accObj))
                    {
                        throw new AccountHasAlreadyCreditCard("Debit card has been already issued for this account .");
                    }

                    else if (CheckIfAppliedForCreditCard(accObj))
                    {
                        throw new CreditCardHasBeenAlreadyRequestedException("Debit card has been already requested for this account and status is " + accObj.DebitCardStatus.Status);
                    }
                    else
                    {
                        //accObj.DebitCardRequest = new DebitCardRequest("requested");
                        DebitCardStatus cardReq = new DebitCardStatus("requested");
                        accObj.DebitCardStatus = cardReq;
                        //DebitCardRequestedRepository.AddToRepository(cardReq);
                        accObj.DebitCard = new DebitCard();
                        //DebitCardRepository.AddToRepository(accObj.DebitCard);
                    }
                }

            }
            catch (Exception ex) { throw; }
            orderPlaced = true;
            return orderPlaced;
        }
        public bool ApplyCreditCard(Account accObj)
        {
            bool orderPlaced = false;
            try
            {
                if (CheckIsAccountActive(accObj.IsActive))
                {

                    if (IfAccountHasAlreadyCreditCard(accObj))
                    {
                        throw new AccountHasAlreadyCreditCard("credit card has been already issued for this account .");
                    }

                    else if (CheckIfAppliedForCreditCard(accObj))
                    {
                        throw new CreditCardHasBeenAlreadyRequestedException("Debit card has been already requested for this account and status is " + accObj.DebitCardStatus.Status);
                    }
                    else
                    {
                        //accObj.DebitCardRequest = new DebitCardRequest("requested");
                        CreditCardStatus cardReq = new CreditCardStatus("requested");
                        accObj.CreditCardStatus = cardReq;
                        //DebitCardRequestedRepository.AddToRepository(cardReq);
                        accObj.CreditCard = new CreditCard();
                        //DebitCardRepository.AddToRepository(accObj.DebitCard);
                    }
                }

            }
            catch (Exception ex) { throw; }
            orderPlaced = true;
            return orderPlaced;
        }

       

        public bool SetPinDebitCard(Account accObj, int pin, int newPin, int confirmPin)
        {

            if (CheckStatusOfcreditCardReq(accObj))
            {
                if (CheckIfDebitCardIsNotExpired(accObj))
                {
                    if (CheckIfPinIsValid(pin, accObj.DebitCard.Pin))
                    {
                        if (ChangePin(accObj, newPin, confirmPin))
                        {
                            if (accObj.DebitCardStatus.Status.Equals("requested"))
                            {
                                accObj.DebitCardStatus.Status = "completed";
                                accObj.DebitCard.ActivationDate = DateTime.Now;
                                accObj.DebitCard.IsCardActive = true;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public bool SetPinCreditCard(Account accObj, int pin, int newPin, int confirmPin)
        {

            if (CheckStatusOfcreditCardReq(accObj))
            {
                if (CheckIfCreditCardIsNotExpired(accObj))
                {
                    if (CheckIfPinIsValid(pin, accObj.DebitCard.Pin))
                    {
                        if (ChangePin(accObj, newPin, confirmPin))
                        {
                            if (accObj.CreditCardStatus.Status.Equals("requested"))
                            {
                                accObj.CreditCardStatus.Status = "completed";
                                accObj.CreditCard.ActivateionDate = DateTime.Now;
                                accObj.CreditCard.IsCardActive = true;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool CheckIfCreditCardIsNotExpired(Account accObj)
        {
            if (accObj.CreditCard != null && accObj.CreditCard.ExpiryDate < DateTime.Now)
            {
                accObj.CreditCard.IsCardActive = false;
                accObj.CreditCardStatus.Status = "expired";
                throw new DebitCardExpiredException("Your Credit card card is expired.");
            }
            return true;
        }

        //Method for Cancel service of debit card
        public bool CancelDebitCard(Account accObj, int pin)
        {
            bool orderCancel = false;
            try
            {
                if (CheckIsAccountActive(accObj.IsActive))
                {
                    if (CheckIfPinIsValid(pin, accObj.PinNumber))
                    {
                        if (CheckIfAppliedForCreditCard(accObj))
                        {
                            accObj.DebitCardStatus.Status = "cancel";
                            //throw new DebitCardHasBeenAlreadyRequestedException("Debit card has been already requested for this account and status is " + accObj.DebitCardRequest.Status);
                        }
                        else if (!IfAccountHasAlreadyCreditCard(accObj))
                        {
                            throw new AccountHasAlreadyCreditCard("Debit card has not issued for this account .");
                        }
                        else
                        {
                            //accObj.DebitCardRequest = new DebitCardRequest("requested");

                            accObj.DebitCardStatus.Status = "cancel";
                            accObj.DebitCard.IsCardActive = false;

                        }
                    }
                }

            }
            catch (Exception ex) { throw; }
            orderCancel = true;
            return orderCancel;
        }
        //Method for Cancel service of Credit card
        public bool CancelCreditCard(Account accObj, int pin)
        {
            bool orderCancel = false;
            try
            {
                if (CheckIsAccountActive(accObj.IsActive))
                {
                    if (CheckIfPinIsValid(pin, accObj.PinNumber))
                    {
                        if (CheckIfAppliedForCreditCard(accObj))
                        {
                            accObj.DebitCardStatus.Status = "cancel";
                            //throw new DebitCardHasBeenAlreadyRequestedException("Debit card has been already requested for this account and status is " + accObj.DebitCardRequest.Status);
                        }
                        else if (!IfAccountHasAlreadyCreditCard(accObj))
                        {
                            throw new AccountHasAlreadyCreditCard("Credit card has not issued for this account .");
                        }
                        else
                        {
                            //accObj.DebitCardRequest = new DebitCardRequest("requested");

                            accObj.CreditCardStatus.Status = "cancel";
                            accObj.CreditCard.IsCardActive = false;

                        }
                    }
                }

            }
            catch (Exception ex) { throw; }
            orderCancel = true;
            return orderCancel;
        }
        //Helping methods to build unit testable code-------------------------------------------------------------
        private bool IfAccountHasAlreadyDebitCard(Account account)
        {
            bool temp = false;
            if (account.DebitCard == null)
            {
                return temp;
            }
            else if (account.DebitCard.IsCardActive)
            {
                temp = true;
            }
            return temp;
        }
        private bool IfAccountHasAlreadyCreditCard(Account accObj)
        {
            bool temp = false;
            if (accObj.CreditCard == null)
            {
                return temp;
            }
            else if (accObj.CreditCard.IsCardActive)
            {
                temp = true;
            }
            return temp;
        }

        private bool CheckIfAppliedForCreditCard(Account acc)
        {
            if (acc.DebitCardStatus == null || acc.DebitCardStatus.Status.Equals("expired"))
                return false;
            return true;
        }
        private bool CheckIfAppliedForInsurence(Account accObj)
        {
            throw new NotImplementedException();
        }

        private bool IfAccountHasAlreadyInsurence(Account accObj)
        {

            bool temp = false;
            //if (accObj.Insurences == null)
            //{
            //    return temp;
            //}
            //else if (accObj.Insurences.IsInsurenceActive)
            //{
            //    temp = true;
            //}
            return temp;
        }

        private bool CheckStatusOfcreditCardReq(Account accObj)
        {
            if (accObj.DebitCardStatus == null)
            {
                throw new AccountHadNoDebitCards("Your Account has no debit card service. Apply for debit card.");
            }
            return true;
        }
        private bool CheckIfDebitCardIsNotExpired(Account accObj)
        {
            if (accObj.DebitCard != null && accObj.DebitCard.ExpiryDate < DateTime.Now)
            {
                accObj.DebitCard.IsCardActive = false;
                accObj.DebitCardStatus.Status = "expired";
                throw new DebitCardExpiredException("Your Debit card is expired.");
            }
            return true;
        }
        private bool ChangePin(Account accObj, int newPin, int confirmPin)
        {
            if (newPin == confirmPin)
                accObj.DebitCard.Pin = newPin;
            else
                throw new BothPinNotSameException("Both pin should be same. You entered wrong pin.");
            return true;
        }


       

        private bool CheckIfAppliedInsurence(Account accObj)
        {
            bool temp = false;
            if (accObj.Insurences==null)
            {
                return temp;
            }
            else if (accObj.Insurences.IsActive)
            {
                temp= true;
            }
            return temp;
        }

        private bool ifAccountHasAlreadyInsurence(Account acc)
        {
            if (acc.Insurences==null || acc.InsurenceStatuse.Equals("expired"))
                return false;
            return true;
           
        }

        private bool CheckIsAccountClosed(Account account)
        {
            if (!account.IsActive)
                throw new AccountIsAlreadyClosedException("This account is already closed.");
            return true;
        }
        private bool DiscloseAccount(Account account)
        {
            account.IsActive = false;
            account.ClosedDate = DateTime.Now;
            return true;
        }

        private bool CheckIsAccountActive(bool isActive)
        {
            if (!isActive)
                throw new AccountIsNotActiveException("Account is InActive.");
            return true;
        }
        private bool CheckIfPinIsValid(int enteredPinNumber, int accountPinNumber)
        {
            if (enteredPinNumber != accountPinNumber)
                throw new InvalidPinNumberException("You entered wrong pin number.");
            return true;
        }
        private bool IsSufficientBalance(double balance, double withdrawAmt)
        {
            if (balance < withdrawAmt)
                throw new InSufficientBalanceException("Insufficient  balance in account.");
            return true;
        }

        private bool WithdrawnFunds(Account account, double withdrawAmt)
        {
            account.Balance -= withdrawAmt;
            return true;
        }
        private bool DepositFunds(Account account, double depositAmt)
        {
            account.Balance += depositAmt;
            return true;
        }

        private bool CheckIfTransferLimitExceeded(Transfer transfer, double dailyTransferLimit)
        {
            //get transfers done by FromAccount for a day 
            List<Transfer> transfers = TransferLog.GetTransfersFromLog(transfer.FromAccount);
            double amountTransferred = 0.00;
            foreach (Transfer t in transfers)
            {
                amountTransferred += transfer.Amount;
            }
            //check if transfer done for the day already exceeded the limit. 
            if (amountTransferred + transfer.Amount >= dailyTransferLimit)
            {
                throw new TransferLimitExceededException("Daily Transfer Limit Exceeded");
            }
            return true;
        }

        public void GetTransactionDetail(Transaction transaction)
        {
            if (transaction.AccountNo == transaction.FromAccount.AccountNumber)
            {

            }
        }
    }
}
