using SimpleBank.API.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Infrastructure
{
    public static class BankDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this BankDbContext dbContext)
        {
            if (dbContext.Accounts.Any()) return;

            var lista = new List<Account>()
            {
                new Account { Id = "0001", Balance = 5000, DateCreated = DateTime.Now },
                new Account { Id = "0002", Balance = 5000, DateCreated = DateTime.Now },
                new Account { Id = "0003", Balance = 5000, DateCreated = DateTime.Now },
                new Account { Id = "0004", Balance = 5000, DateCreated = DateTime.Now },
                new Account { Id = "0005", Balance = 5000, DateCreated = DateTime.Now }
            };

            dbContext.Accounts.AddRange(lista);
            dbContext.SaveChanges();
        }
    }
}
