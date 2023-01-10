using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class AccountIsNotActiveException : Exception
    {
        public AccountIsNotActiveException()
        {
        }

        public AccountIsNotActiveException(string? message) : base(message)
        {
        }

        public AccountIsNotActiveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccountIsNotActiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}