using SimpleBank.API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleBank.API.Test.Controllers
{
    public class TransferOperationsControllerTest
    {
        public void AoChamarTransferMoneyModelNaoPodeSerNuloAoConcluirOperacao()
        {
            var appService = new TransferMoneyApplicationServiceStub();
            var controller = new TransferOperationsController(appService);

            //esperado
            int numeroChamadaAppService = 1;
            //--model nao pode ser nulo apos concluir a operacao

            controller.TransferMoney(new Models.OperationModel { AccountSourceId = "001", AcountDestinyId = "002", Value = 300 });

            Assert.Equal(numeroChamadaAppService, appService.transferMoneyCount);
            Assert.NotNull(appService.modelPassado);
        }
    }
}
