using CreditSuisse.FinPort.Application.Interface.DTO;

namespace CreditSuisse.FinPort.Application.Interface.Applications
{
    public interface IFinInstrumentApp
    {
        Task<Envelope<string[]>> Categorize(IEnumerable<FinantialInstrumentDTO> finantialInstruments);
    }
}
