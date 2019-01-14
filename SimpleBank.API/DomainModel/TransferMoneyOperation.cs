using SimpleBank.API.DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.DomainModel
{
    public class TransferMoneyOperation: EntityBase, IAggregateRoot
    {
        public static TransferMoneyOperation Build()
        {
            return new TransferMoneyOperation
            {
                DateCreated = DateTime.Now,
                Id = Guid.NewGuid().ToString()
            };
        }

        public decimal Value { get; set; }
        public DateTime DateCreated { get; set; }

        public Account AccountSource { get; set; }
        public string AccountSourceId { get; set; }

        public Account AccountDestiny { get; set; }
        public string AccountDestinyId { get; set; }

        public void SetOperationDetail(OperationDetail operationDetail)
        {
            if (operationDetail.accountDestinyId.Equals(operationDetail.accountSourceId))
                throw new InvalidDomainException("contas origem e destino devem ser diferentes.");

            AccountSourceId = operationDetail.accountSourceId;
            AccountDestinyId = operationDetail.accountDestinyId;
            Value = operationDetail.value;
        }
    }
}
