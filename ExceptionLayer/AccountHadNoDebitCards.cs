using System.Runtime.Serialization;

namespace BankOfSuccrss.Console.ExceptionLayer
{
    [Serializable]
    internal class AccountHadNoDebitCards : Exception
    {
        public AccountHadNoDebitCards()
        {
        }

        public AccountHadNoDebitCards(string message) : base(message)
        {
        }

        public AccountHadNoDebitCards(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountHadNoDebitCards(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}