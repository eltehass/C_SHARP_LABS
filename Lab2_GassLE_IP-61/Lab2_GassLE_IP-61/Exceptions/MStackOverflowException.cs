using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_GassLE_IP_61
{
    public class MStackOverflowException : Exception
    {
        public MStackOverflowException() { }

        public MStackOverflowException(string message) : base(message) { }

        public MStackOverflowException(string message, Exception inner) : base(message, inner) { }
    }
}
