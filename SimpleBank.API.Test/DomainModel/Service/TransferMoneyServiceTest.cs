using SimpleBank.API.DomainModel;
using SimpleBank.API.DomainModel.Service;
using SimpleBank.API.Test.DomainModel.Service.Fakes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleBank.API.Test.DomainModel.Service
{
    public class TransferMoneyServiceTest
    {
        [Fact]
        public void AoEfetuarTransferenciaValoresDeSaldosEOperacaoEChamadasDevemEstarCorretos()
        {
            var accountSource = Account.Build(500);
            var accountDestiny = Account.Build(500);            
            var accountRepositoryStub = new AccountRepositoryStub(accountSource, accountDestiny);
            var transferMoneyOperationRepositoryStub = new TransferMoneyOperationRepositoryStub();
            var valorOperacao = 300m;

            var transferMoneyService = new TransferMoneyService(accountRepositoryStub, transferMoneyOperationRepositoryStub);

            //esperado
            var saldoAccountSource = 200m;
            var saldoAccountDestiny = 800m;
            var chamadasAccountRepositoryGetById = 2;
            var chamadasAccountRepositoryUpdate = 2;
            var chamadasTransferRepositoryInsert = 1;
            //-- Valores da operacao persistido
            
            //execute
            transferMoneyService.TransferMoney(accountSource.Id, accountDestiny.Id, valorOperacao);

            //Asserts
            Assert.Equal(saldoAccountSource, accountSource.Balance);
            Assert.Equal(saldoAccountDestiny, accountDestiny.Balance);
            Assert.Equal(chamadasAccountRepositoryGetById, accountRepositoryStub.GetByIdCount);
            Assert.Equal(chamadasAccountRepositoryUpdate, accountRepositoryStub.UpdateCount);
            Assert.Equal(chamadasTransferRepositoryInsert, transferMoneyOperationRepositoryStub.insertCount);

            Assert.Equal(accountSource.Id, transferMoneyOperationRepositoryStub.transferMoneyOperation.AccountSourceId);
            Assert.Equal(accountDestiny.Id, transferMoneyOperationRepositoryStub.transferMoneyOperation.AccountDestinyId);
            Assert.Equal(valorOperacao, transferMoneyOperationRepositoryStub.transferMoneyOperation.Value);

        }
    }
}
