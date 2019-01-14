using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Models
{
    public class OperationModel
    {
        public string AccountSourceId { get; set; }
        public string AcountDestinyId { get; set; }
        public Decimal Value { get; set; }
    }
}
