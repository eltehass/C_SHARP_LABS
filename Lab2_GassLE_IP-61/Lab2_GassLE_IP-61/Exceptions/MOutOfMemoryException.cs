using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_GassLE_IP_61
{
    class MOutOfMemoryException : Exception
    {
        public MOutOfMemoryException() { }

        public MOutOfMemoryException(string message) : base(message) { }

        public MOutOfMemoryException(string message, Exception inner) : base(message, inner) { }
    }
}
