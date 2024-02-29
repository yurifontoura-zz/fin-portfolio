namespace CreditSuisse.FinPort.Application.Interface.DTO
{
    public class FinantialInstrumentDTO(decimal marketValue, string type)
    {
        public decimal MarketValue { get; init; } = marketValue;
        public string Type { get; init; } = type;
    }
}
