using System;
using System.Runtime.Serialization;

namespace Klasice
{
    [Serializable]
    internal class CorruptedFileException : Exception
    {
        public CorruptedFileException()
        {
        }

        public CorruptedFileException(string message) : base(message)
        {
        }

        public CorruptedFileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CorruptedFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}