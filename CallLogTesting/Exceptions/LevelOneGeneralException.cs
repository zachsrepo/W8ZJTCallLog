using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallLogTesting.Exceptions
{
    internal class LevelOneGeneralException : Exception
    {
        public LevelOneGeneralException() : base() { }
        public LevelOneGeneralException(string message) : base(message) { }
        public LevelOneGeneralException(string message, Exception innerException) : base(message, innerException) { }
    }
}
