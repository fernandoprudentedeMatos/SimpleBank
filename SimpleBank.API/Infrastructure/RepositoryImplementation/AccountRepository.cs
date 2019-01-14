using SimpleBank.API.DomainModel;
using SimpleBank.API.DomainModel.Repository;

namespace SimpleBank.API.Infrastructure.RepositoryImplementation
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(BankDbContext context): base(context)
        {
            
        }
    }
}
