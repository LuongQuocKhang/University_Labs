using System;
using System.Runtime.Serialization;

namespace University.Worker.Exceptions
{
    [Serializable]
    internal class WorkerConsecutiveException : Exception
    {
        public WorkerConsecutiveException()
        {
        }

        public WorkerConsecutiveException(int consecutiveCount, Exception e) : base($"Failed {consecutiveCount} times in a row to run", e)
        {
        }

        public WorkerConsecutiveException(string message) : base(message)
        {
        }

        public WorkerConsecutiveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WorkerConsecutiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}