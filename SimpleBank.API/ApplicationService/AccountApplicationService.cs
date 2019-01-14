using SimpleBank.API.DomainModel.Repository;
using SimpleBank.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.ApplicationService
{
    public class AccountApplicationService
    {
        private IAccountRepository accountRepository;

        public AccountApplicationService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IEnumerable<AccountModel> GetAccounts()
        {
            return accountRepository.GetAll().Select(account => new AccountModel
            {
                 AccountNumber = account.Id,
                 Balance = account.Balance
            });
        }
    }
}
