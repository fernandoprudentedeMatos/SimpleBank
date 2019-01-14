using SimpleBank.API.DomainModel.Service;
using SimpleBank.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.ApplicationService
{
    public class TransferMoneyApplicationService
    {
        private TransferMoneyService transferMoneyService;

        public TransferMoneyApplicationService(TransferMoneyService transferMoneyService)
        {
            this.transferMoneyService = transferMoneyService;
        }

        public virtual void TransferMoney(OperationModel model)
        {
            if (model == null)
                throw new InvalidApplicationException("dados não foram passados para o serviço.");

            if (string.IsNullOrWhiteSpace(model.AccountSourceId) || string.IsNullOrWhiteSpace(model.AcountDestinyId))
                throw new InvalidApplicationException("as contas de origem e destino devem ser passadas para o serviço.");
            

            transferMoneyService.TransferMoney(model.AccountSourceId, model.AcountDestinyId, model.Value);
        }        
    }
}
