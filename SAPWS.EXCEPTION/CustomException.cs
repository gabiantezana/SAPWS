using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWS.EXCEPTION
{
    public class CustomException : Exception
    {
        public String Message { get; set; }
        public Object o { get; set; }

        public CustomException() { }
        public CustomException(Object o)
        {
            this.o = o;
        }

        public CustomException(string message) : base(message) { Message = message; }

    }
}
