using SimpleBank.API.DomainModel.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleBank.API.DomainModel;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleBank.API.Test.DomainModel.Service.Fakes
{
    public class TransferMoneyOperationRepositoryStub : ITransferMoneyOperationRepository
    {
        public TransferMoneyOperation transferMoneyOperation;
        public int insertCount = 0;

        public void Delete(TransferMoneyOperation entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TransferMoneyOperation> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransferMoneyOperation GetById(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public void Insert(TransferMoneyOperation entity)
        {
            insertCount++;
            transferMoneyOperation = entity;
        }

        public IQueryable<TransferMoneyOperation> SearchFor(Expression<Func<TransferMoneyOperation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TransferMoneyOperation entity)
        {
            throw new NotImplementedException();
        }
    }
}
