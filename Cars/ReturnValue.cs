using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars
{
    public class ReturnValue
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ReturnValue(bool success, string message)
        {
            Message = message;
            Success = success;
        }
    }
}
