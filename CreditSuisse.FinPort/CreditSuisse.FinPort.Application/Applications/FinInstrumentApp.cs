using CreditSuisse.FinPort.Application.Interface.Applications;
using CreditSuisse.FinPort.Application.Interface.DTO;
using CreditSuisse.FinPort.Domain;
using CreditSuisse.FinPort.Domain.Entities;
using CreditSuisse.FinPort.Domain.Repositories;

namespace CreditSuisse.FinPort.Application.Applications
{
    public class FinInstrumentApp(IRuleRepository _ruleRepository) : IFinInstrumentApp
    {
        public async Task<Envelope<string[]>> Categorize(IEnumerable<FinantialInstrumentDTO> instrumentsDTO)
        {
			Envelope<string[]> envelope = new();

			try
			{
                List<FinantialInstrument> finantialInstruments = instrumentsDTO.Select(i => new FinantialInstrument(i.MarketValue, i.Type)).ToList();

                List<string> ruleNames = [];
                List<BasicRule> rules = [.. _ruleRepository.GetBasics()];

                foreach (FinantialInstrument instrument in finantialInstruments)
                {
                    BasicRule instrumentRule = rules.FirstOrDefault(r => r.Applies(instrument)) ??
                                               throw new BusinessException($"Instrument {instrument.Type} has no rule for it's value {instrument.MarketValue}."); ;

                    ruleNames.Add(instrumentRule.Name);
                }

                envelope.Data = [.. ruleNames];
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
