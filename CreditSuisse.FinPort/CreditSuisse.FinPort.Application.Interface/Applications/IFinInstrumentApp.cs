using CreditSuisse.FinPort.Application.Interface.DTO;

namespace CreditSuisse.FinPort.Application.Interface.Applications
{
    public interface IFinInstrumentApp
    {
        /// <summary>
        /// This service's method will categorize the provided finantial instruments through the criteria of the registered rules.
        /// </summary>
        /// <returns>Returns an respective ordered array of strings with the rule names.</returns>
        Task<Envelope<string[]>> Categorize(IEnumerable<FinantialInstrumentDTO> finantialInstruments);
    }
}
