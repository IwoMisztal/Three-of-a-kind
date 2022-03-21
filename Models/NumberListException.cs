using System.Runtime.Serialization;

namespace LookingForThree.Models
{
    [Serializable]
    internal class NumberListException : Exception
    {
        public NumberListException()
        {
        }

        public NumberListException(string? message) : base(message)
        {
        }

        public NumberListException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NumberListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}