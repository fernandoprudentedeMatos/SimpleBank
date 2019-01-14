using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Models
{
    public class AccountModel
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
