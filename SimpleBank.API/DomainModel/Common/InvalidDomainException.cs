using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.DomainModel.Common
{
    [Serializable]
    public class InvalidDomainException : Exception
    {
        public InvalidDomainException(string message) : base(message) { }
    }
}
