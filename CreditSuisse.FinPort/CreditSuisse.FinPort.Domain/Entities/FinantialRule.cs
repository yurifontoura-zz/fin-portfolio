using CreditSuisse.FinPort.Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace CreditSuisse.FinPort.Domain.Entities
{
    /// <summary>
    /// This class represents a finantial rule and is responsible to carry the criteria of an instrument.
    /// </summary>
    public class FinantialRule
    {
        [SetsRequiredMembers]
        public FinantialRule(string name, decimal minValue, decimal maxValue)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
            _selector = fi => fi.MarketValue >= minValue && fi.MarketValue <= maxValue;
        }

        public string Name { get; init; }
        private Func<IFinantialInstrument, bool> _selector { get; set; }

        public bool Applies(IFinantialInstrument instrument) => _selector.Invoke(instrument);
    }
}
