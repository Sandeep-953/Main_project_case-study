using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class AccountHasAlreadyCreditCard : Exception
    {
        public AccountHasAlreadyCreditCard()
        {
        }

        public AccountHasAlreadyCreditCard(string? message) : base(message)
        {
        }

        public AccountHasAlreadyCreditCard(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccountHasAlreadyCreditCard(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}