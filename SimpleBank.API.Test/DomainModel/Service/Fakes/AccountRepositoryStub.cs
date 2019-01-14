using SimpleBank.API.DomainModel.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleBank.API.DomainModel;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleBank.API.Test.DomainModel.Service
{
    public class AccountRepositoryStub : IAccountRepository
    {
        public Account accountSource;
        public Account accountDestiny;

        public int UpdateCount = 0;
        public int GetByIdCount = 0;

        public AccountRepositoryStub(Account accountSource, Account accountDestiny)
        {
            this.accountSource = accountSource;
            this.accountDestiny = accountDestiny;
        }

        public void Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetById(params object[] keys)
        {
            GetByIdCount++;

            var id = keys[0].ToString();

            Account result = null;

            if (id.Equals(accountSource.Id)) result = accountSource;
            if (id.Equals(accountDestiny.Id)) result = accountDestiny;

            return result;
        }

        public void Insert(Account entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> SearchFor(Expression<Func<Account, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Account entity)
        {
            UpdateCount++;
        }
    }
}
