using CreditSuisse.FinPort.Application.Applications;
using CreditSuisse.FinPort.Application.Interface.Applications;
using Microsoft.Extensions.DependencyInjection;

namespace CreditSuisse.FinPort.CrossDomain
{
    public class DependencySolver
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IFinInstrumentApp, FinInstrumentApp>();
        }
    }
}
