using CreditSuisse.FinPort.Application.Interface.Applications;
using CreditSuisse.FinPort.Application.Interface.DTO;
using CreditSuisse.FinPort.Domain;

namespace CreditSuisse.FinPort.Application.Applications
{
    public class FinInstrumentApp : IFinInstrumentApp
    {
        public async Task<Envelope<string[]>> Categorize(IEnumerable<FinantialInstrumentDTO> finantialInstruments)
        {
			Envelope<string[]> envelope = new();

			try
			{

			}
			catch (BusinessException bex)
            {
                envelope.Success = false;
                envelope.Message = bex.Message;
            }
			catch (Exception ex)
            {
				envelope.Exception = ex;
                envelope.Message = ex.GetFullMessage();
                envelope.Success = false;
			}

			return envelope;
        }
    }
}
