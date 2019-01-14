using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.DomainModel
{
    public class TokenRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
