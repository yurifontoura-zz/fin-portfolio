using CreditSuisse.FinPort.Domain.Entities;

namespace CreditSuisse.FinPort.Domain.Repositories
{
    public interface IRuleRepository
    {
        IQueryable<BasicRule> GetBasics();
    }
}
