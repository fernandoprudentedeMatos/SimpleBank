using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBank.API.ApplicationService;
using SimpleBank.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Controllers
{
    [Route("api/accounts")]
    [Authorize]
    public class AccountsController: Controller
    {
        private AccountApplicationService appService;

        public AccountsController(AccountApplicationService appService)
        {
            this.appService = appService;
        }

        [HttpGet()]
        public IActionResult GetAccounts()
        {
            var accountsModels = appService.GetAccounts();
            return Ok(accountsModels);
        }
    }
}
