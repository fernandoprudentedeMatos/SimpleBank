using Microsoft.EntityFrameworkCore;
using SimpleBank.API.DomainModel.Repository;
using SimpleBank.API.ApplicationService;
using SimpleBank.API.Infrastructure;
using SimpleBank.API.Infrastructure.RepositoryImplementation;
using SimpleBank.API.DomainModel.Service;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleBank.API
{
    public static class ServicesRegisterExtensions
    {
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            serviceCollection.AddScoped<ITransferMoneyOperationRepository, TransferMoneyOperationRepository>();
            serviceCollection.AddScoped<TransferMoneyApplicationService>();
            serviceCollection.AddScoped<AccountApplicationService>();
            serviceCollection.AddScoped<TransferMoneyService>();
            serviceCollection.AddSingleton<ILogger, Logger>();                       
        }
    }
}
