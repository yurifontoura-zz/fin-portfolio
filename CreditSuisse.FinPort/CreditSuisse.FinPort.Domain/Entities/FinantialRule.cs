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

        /// <summary>
        /// Method responsible for validate the rule.
        /// </summary>
        /// <param name="instrument">An object that implements IFinantialInstrument interface, which will have it's content validated.</param>
        /// <returns>True if attends the rule, or false if it does not.</returns>
        public bool Applies(IFinantialInstrument instrument) => _selector.Invoke(instrument);

        /// <summary>
        /// Method responsible for validate the rule.
        /// </summary>
        /// <returns>True if all the instruments attends the rule, or false if even one does not.</returns>
        public Task<bool> Applies(IEnumerable<IFinantialInstrument> instruments) => Task.Run(() => instruments.ToList().TrueForAll(i => Applies(i)));
    }
}
