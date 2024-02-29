using CreditSuisse.FinPort.Domain.Interfaces;

namespace CreditSuisse.FinPort.Domain.Entities
{
    public class FinantialInstrument : IFinantialInstrument
    {
        public FinantialInstrument(decimal marketValue, string type)
        {
            if (marketValue < 0) throw new BusinessException($"Market value must be positive: {marketValue}");
            if (!string.IsNullOrEmpty(type)) throw new BusinessException("The provided type is null or empty.");

            _marketValue = marketValue;
            _type = type;
        }

        private decimal _marketValue;
        private string _type;

        public decimal MarketValue => _marketValue;

        public string Type => _type;
    }
}
