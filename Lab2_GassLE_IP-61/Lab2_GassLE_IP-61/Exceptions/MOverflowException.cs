using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_GassLE_IP_61
{
    class MOverflowException : Exception
    {
        public MOverflowException() { }

        public MOverflowException(string message) : base(message) { }

        public MOverflowException(string message, Exception inner) : base(message, inner) { }
    }
}
