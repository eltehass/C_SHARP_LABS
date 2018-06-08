using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_GassLE_IP_61
{
    class MInvalidCastException : Exception
    {
        public MInvalidCastException() { }

        public MInvalidCastException(string message) : base(message) { }

        public MInvalidCastException(string message, Exception inner) : base(message, inner) { }
    }
}
