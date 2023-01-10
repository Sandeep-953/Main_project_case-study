using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class InvalidPinNumberException : Exception
    {
        public InvalidPinNumberException()
        {
        }

        public InvalidPinNumberException(string? message) : base(message)
        {
        }

        public InvalidPinNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPinNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}