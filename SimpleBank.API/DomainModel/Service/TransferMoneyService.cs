using SimpleBank.API.DomainModel.Common;
using SimpleBank.API.DomainModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.DomainModel.Service
{
    public class TransferMoneyService
    {
        IAccountRepository accountRepository;
        ITransferMoneyOperationRepository transferMoneyOperationRepository;

        public TransferMoneyService(IAccountRepository accountRepository, ITransferMoneyOperationRepository transferMoneyOperationRepository)
        {
            this.accountRepository = accountRepository;
            this.transferMoneyOperationRepository = transferMoneyOperationRepository;
        }

        public void TransferMoney(string accountSourceId, string accountDestinyId, decimal value)
        {
            var transferMoneyOperation = TransferMoneyOperation.Build();
            transferMoneyOperation.SetOperationDetail(new OperationDetail(accountSourceId, accountDestinyId, value));

            var accountSource = accountRepository.GetById(accountSourceId);
            var accountDestiny = accountRepository.GetById(accountDestinyId);

            if (accountSource == null)
                throw new InvalidDomainException("Conta de origem não existe.");

            if (accountDestiny == null)
                throw new InvalidDomainException("Conta de destino não existe.");

            accountSource.SubtractMoney(value);
            accountDestiny.AddMoney(value);

            transferMoneyOperationRepository.Insert(transferMoneyOperation);

            accountRepository.Update(accountSource);
            accountRepository.Update(accountDestiny);
        }
    }
}
