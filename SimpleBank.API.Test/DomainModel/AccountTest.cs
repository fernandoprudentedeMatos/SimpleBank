using SimpleBank.API.DomainModel;
using SimpleBank.API.DomainModel.Common;
using System;
using Xunit;

namespace SimpleBank.API.Test
{
    public class AccountTest
    {
        [Fact]
        public void AoConstruirUmNovoObjetoValoresIniciaisDevemEstarCorretos()
        {
            var valorSaldoIncial = 500m;
            var account = Account.Build(valorSaldoIncial);

            Assert.Equal(valorSaldoIncial, account.Balance);
            Assert.True(account.DateCreated > DateTime.MinValue);
            Assert.False(String.IsNullOrEmpty(account.Id));
        }

        [Fact]
        public void AoAdicionarValorSaldoDeveEstarCorreto()
        {
            var valorSaldoIncial = 500m;
            var valorAdicionado = 38m;
            var account = Account.Build(valorSaldoIncial);

            account.AddMoney(valorAdicionado);

            var saldoEsperado = valorSaldoIncial + valorAdicionado;
            Assert.Equal(account.Balance, saldoEsperado);
        }

        [Fact]
        public void AoSubtrairValorSaldoDeveEstarCorreto()
        {
            var valorSaldoIncial = 500m;
            var valorSubtraido = 38m;
            var account = Account.Build(valorSaldoIncial);

            account.SubtractMoney(valorSubtraido);

            var saldoEsperado = valorSaldoIncial - valorSubtraido;
            Assert.Equal(account.Balance, saldoEsperado);
        }

        [Fact]
        public void NaoPodePermitirAdicaoOuSubtracaoComValorNegativo()
        {
            var valorSaldoIncial = 500m;
            var valorSubtraido = -38m;
            var valorAdicionado = -50m;
            var account = Account.Build(valorSaldoIncial);
            var mensagemEsperadaSubtracaoValorNegativo = "Valor para subtração deve ser positivo.";
            var mensagemEsperadaAdicaoValorNegativo = "Valor para adição deve ser positivo.";

            var exceptionSubtracao = Assert.Throws<InvalidDomainException>(() => account.SubtractMoney(valorSubtraido));
            var exceptionAdicao = Assert.Throws<InvalidDomainException>(() => account.AddMoney(valorAdicionado));

            Assert.Equal(mensagemEsperadaSubtracaoValorNegativo, exceptionSubtracao.Message);
            Assert.Equal(mensagemEsperadaAdicaoValorNegativo, exceptionAdicao.Message);
        }

        [Fact]
        public void NaoPodePermitirSubtracaoDeValorSuperiorAoSaldoCorrente()
        {
            var valorSaldoIncial = 500m;
            var valorSubtraido = 501m;
            var account = Account.Build(valorSaldoIncial);
            var mensagemEsperada = "Saldo Insuficiente para concluir a operação.";

            var exception = Assert.Throws<InvalidDomainException>(() => account.SubtractMoney(valorSubtraido));

            Assert.Equal(mensagemEsperada, exception.Message);
        }
    }
}
