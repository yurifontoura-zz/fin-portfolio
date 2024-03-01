using System.Diagnostics.CodeAnalysis;

namespace CreditSuisse.FinPort.Domain.Entities
{
    public class BasicRule : FinantialRule
    {
        public BasicRule()
        {
            ID = Guid.NewGuid();
            MaxValue = 0M;
        }

        [SetsRequiredMembers]
        public BasicRule(string name, decimal? minValue, decimal? maxValue) : base(name, minValue, maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Name = name;
        }

        public required Guid ID { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
    }
}
