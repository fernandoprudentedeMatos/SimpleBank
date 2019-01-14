using SimpleBank.API.DomainModel;
using SimpleBank.API.DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleBank.API.Test.DomainModel
{
    public class TransferMoneyOperationTest
    {
        [Fact]
        public void AoConstruirUmNovoObjetoValoresIniciaisDevemSerSetados()
        {
            var transferMoneyOperation = TransferMoneyOperation.Build();

            Assert.NotNull(transferMoneyOperation.Id);
            Assert.True(transferMoneyOperation.DateCreated > DateTime.MinValue);
        }

        [Fact]
        public void AoInformarDetalhesDeOperacaoValoresDevemEstarCorretos()
        {
            var transferMoneyOperation = TransferMoneyOperation.Build();
            var accountSourceId = "SourceId_01";
            var accountDestinyId = "DestinyId_01";
            var valor = 120m;

            transferMoneyOperation.SetOperationDetail(new OperationDetail(accountSourceId, accountDestinyId, valor));

            Assert.Equal(accountSourceId, transferMoneyOperation.AccountSourceId);
            Assert.Equal(accountDestinyId, transferMoneyOperation.AccountDestinyId);
            Assert.Equal(valor, transferMoneyOperation.Value);
        }

        [Fact]
        public void NaoPodePermitirInformacaoDeContasIguaisParaOrigemEDestino()
        {
            var transferMoneyOperation = TransferMoneyOperation.Build();
            var accountSourceId = "SourceId_01";
            var accountDestinyId = "SourceId_01";
            var valor = 120m;
            var mensagemEsperada = "contas origem e destino devem ser diferentes.";

            var exception = Assert.Throws<InvalidDomainException>(() => transferMoneyOperation.SetOperationDetail(new OperationDetail(accountSourceId, accountDestinyId, valor)));

            Assert.Equal(mensagemEsperada, exception.Message);
        }
    }
}
