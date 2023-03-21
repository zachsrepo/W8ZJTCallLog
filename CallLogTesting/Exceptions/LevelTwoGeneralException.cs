using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallLogTesting.Exceptions
{
    internal class LevelTwoGeneralException : Exception
    {
        public LevelTwoGeneralException() : base() { }
        public LevelTwoGeneralException(string message) : base(message) { }
        public LevelTwoGeneralException(string message, Exception innerException) : base(message, innerException) { }
    }
}
