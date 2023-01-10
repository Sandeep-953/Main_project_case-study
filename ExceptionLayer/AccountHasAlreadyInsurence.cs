using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class AccountHasAlreadyInsurence : Exception
    {
        public AccountHasAlreadyInsurence()
        {
        }

        public AccountHasAlreadyInsurence(string? message) : base(message)
        {
        }

        public AccountHasAlreadyInsurence(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccountHasAlreadyInsurence(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}