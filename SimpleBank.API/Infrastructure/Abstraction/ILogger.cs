using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Infrastructure
{
    public interface ILogger
    {
        void Error(string message, Exception exception = null);
        void Warn(string message);
        void Info(string message);
    }
}
