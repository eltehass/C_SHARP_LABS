using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_GassLE_IP_61
{
    class MDivideByZeroException : Exception
    {
        public MDivideByZeroException() { }

        public MDivideByZeroException(string message) : base(message) { }

        public MDivideByZeroException(string message, Exception inner) : base(message, inner) { }
    }
}
