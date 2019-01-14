using SimpleBank.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Infrastructure
{
    public class Logger: ILogger
    {
        public void Error(string message, Exception exception = null)
        {
           //blabla
        }

        public void Warn(string message)
        {
            //blabla
        }

        public void Info(string message)
        {
            //blabla
        }
    }
}
