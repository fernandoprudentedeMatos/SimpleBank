using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.ApplicationService
{
    [Serializable]
    public class InvalidApplicationException : Exception
    {
        public InvalidApplicationException(string message) : base(message) { }
    }
}
