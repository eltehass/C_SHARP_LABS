using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_GassLE_IP_61
{
    public class UpdatedElementHandler : AbstractHandler
    {
        public void Message()
        {
            Console.WriteLine("Message: element updated!");
        }
    }
}
