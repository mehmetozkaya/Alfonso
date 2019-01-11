using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Exceptions
{
    public class CompareNotFoundException : Exception
    {
        public CompareNotFoundException(int basketId) : base($"No basket found with id {basketId}")
        {
        }

        protected CompareNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public CompareNotFoundException(string message) : base(message)
        {
        }

        public CompareNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
