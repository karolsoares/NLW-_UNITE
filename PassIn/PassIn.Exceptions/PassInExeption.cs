using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Exceptions
{
    public class PassInExeption : SystemException
    {
        public  PassInExeption(string message) : base(message)
        {

        }
    }
}
