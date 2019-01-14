using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.DomainModel.Common
{
    public class EntityBase
    {
        public virtual string Id { get; set; }

        protected EntityBase()
        {

        }
    }
}
