using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class InsurenceHasBeenAlreadyRequestedException : Exception
    {
        public InsurenceHasBeenAlreadyRequestedException()
        {
        }

        public InsurenceHasBeenAlreadyRequestedException(string? message) : base(message)
        {
        }

        public InsurenceHasBeenAlreadyRequestedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InsurenceHasBeenAlreadyRequestedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}