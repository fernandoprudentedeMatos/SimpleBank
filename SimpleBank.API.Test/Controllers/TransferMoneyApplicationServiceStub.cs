using SimpleBank.API.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleBank.API.Models;

namespace SimpleBank.API.Test.Controllers
{
    public class TransferMoneyApplicationServiceStub: TransferMoneyApplicationService
    {
        public int transferMoneyCount = 0;
        public object modelPassado;

        public TransferMoneyApplicationServiceStub(): base(null)
        {

        }

        public override void TransferMoney(OperationModel model)
        {
            transferMoneyCount++;
            modelPassado = model;
        }
    }
}
