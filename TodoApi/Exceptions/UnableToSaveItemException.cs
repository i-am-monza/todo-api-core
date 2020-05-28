using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Exceptions
{
    public class UnableToSaveItemException : Exception
    {
        public int StatusCode { get; }
        public UnableToSaveItemException()
        {
        }

        public UnableToSaveItemException(string msg)
        {
            this.StatusCode = 409;

            throw new Exception(String.Format("Error: {0}", msg));
        }
    }
}
