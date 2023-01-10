using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class InvalidRegistrationNumberException : Exception
    {
        public InvalidRegistrationNumberException()
        {
        }

        public InvalidRegistrationNumberException(string? message) : base(message)
        {
        }

        public InvalidRegistrationNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidRegistrationNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}