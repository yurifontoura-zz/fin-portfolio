using CreditSuisse.FinPort.Application.Applications;
using CreditSuisse.FinPort.Application.Interface.Applications;
using CreditSuisse.FinPort.Domain.Repositories;
using CreditSuisse.FinPort.Repository.MS.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CreditSuisse.FinPort.CrossDomain
{
    public class DependencySolver
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IFinInstrumentApp, FinInstrumentApp>();

            services.AddTransient<IRuleRepository, RuleRepository>();
        }
    }
}
