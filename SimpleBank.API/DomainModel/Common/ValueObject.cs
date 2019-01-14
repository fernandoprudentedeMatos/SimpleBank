using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.DomainModel.Common
{
    public abstract class ValueObject
    {     
        public abstract bool Equals(object obj);
    }
}
