using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_GassLE_IP_61
{
    class MArrayTypeMismatchException : Exception
    {
        public MArrayTypeMismatchException() { }

        public MArrayTypeMismatchException(string message) : base(message) { }

        public MArrayTypeMismatchException(string message, Exception inner) : base(message, inner) { }
    }
}
