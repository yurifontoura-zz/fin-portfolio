using CreditSuisse.FinPort.Domain.Entities;
using CreditSuisse.FinPort.Domain.Repositories;

namespace CreditSuisse.FinPort.Repository.MS.Repositories
{
    /// <summary>
    /// MOCK REPOSITORY
    /// </summary>
    public class RuleRepository : IRuleRepository
    {
        /// <summary>
        /// MOCK METHOD
        /// </summary>

        public IQueryable<BasicRule> GetBasics()
        {
            List<BasicRule> rules =
                [
                    new("Low Value", null, 999999),
                    new("Medium Value", 1000000, 5000000),
                    new("High Value", 5000001, null)
                ];

            return rules.AsQueryable();
        }
    }
}
