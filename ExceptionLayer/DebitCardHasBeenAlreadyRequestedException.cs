using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class CreditCardHasBeenAlreadyRequestedException : Exception
    {
        private object value;

        public CreditCardHasBeenAlreadyRequestedException()
        {
        }

        public CreditCardHasBeenAlreadyRequestedException(object value)
        {
            this.value = value;
        }

        public CreditCardHasBeenAlreadyRequestedException(string? message) : base(message)
        {
        }

        public CreditCardHasBeenAlreadyRequestedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CreditCardHasBeenAlreadyRequestedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}