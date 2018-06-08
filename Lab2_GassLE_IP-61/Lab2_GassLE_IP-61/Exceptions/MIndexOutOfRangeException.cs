using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_GassLE_IP_61
{
    class MIndexOutOfRangeException : Exception
    {
        public MIndexOutOfRangeException() { }

        public MIndexOutOfRangeException(string message) : base(message) { }

        public MIndexOutOfRangeException(string message, Exception inner) : base(message, inner) { }
    }
}
