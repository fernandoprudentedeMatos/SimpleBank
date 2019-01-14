using SimpleBank.API.ApplicationService;
using SimpleBank.API.DomainModel;
using SimpleBank.API.DomainModel.Repository;
using SimpleBank.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SimpleBank.API.Controllers
{
    [Authorize]
    [Route("api/transfers")]
    public class TransferOperationsController: Controller
    {
        private TransferMoneyApplicationService applicationService;

        public TransferOperationsController(TransferMoneyApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPost()]
        public void TransferMoney([FromBody] OperationModel model)
        {
            applicationService.TransferMoney(model);
        }
    }
}
