using SimpleBank.API.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.Infrastructure
{
    public class BankDbContext: DbContext
    {
        public BankDbContext(DbContextOptions options): base(options)
        {
            Database.Migrate();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransferMoneyOperation> TransferMoneyOperations { get; set; }
    }
}
