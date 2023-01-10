using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class AccounthasAlreadyInsurencException : Exception
    {
        public AccounthasAlreadyInsurencException()
        {
        }

        public AccounthasAlreadyInsurencException(string? message) : base(message)
        {
        }

        public AccounthasAlreadyInsurencException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccounthasAlreadyInsurencException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}