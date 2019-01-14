using SimpleBank.API.DomainModel;
using SimpleBank.API.DomainModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Infrastructure.RepositoryImplementation
{
    public class TransferMoneyOperationRepository: RepositoryBase<TransferMoneyOperation>, ITransferMoneyOperationRepository
    {
        public TransferMoneyOperationRepository(BankDbContext context): base(context)
        {

        }
    }
}
