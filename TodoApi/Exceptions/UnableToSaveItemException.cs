using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Exceptions
{
    public class UnableToSaveItemException : Exception
    {
        public UnableToSaveItemException()
        {
        }

        public UnableToSaveItemException(string msg)
        {
            throw new Exception(String.Format("Error: {0}", msg));
        }
    }
}
