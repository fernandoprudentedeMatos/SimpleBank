using SimpleBank.API.ApplicationService;
using SimpleBank.API.DomainModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Filters
{
    public class ApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string message = "ops, erro crítico ocorreu. :(";
            context.HttpContext.Response.StatusCode = 500;

            if (context.Exception is InvalidDomainException || context.Exception is InvalidApplicationException)
            {
                message = context.Exception.Message;
                context.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;                
            }
            else
            {
                //-- LOGGER
            }

            context.Exception = null;

            context.HttpContext.Response.WriteAsync(message);

            base.OnException(context);
        }
    }
}
