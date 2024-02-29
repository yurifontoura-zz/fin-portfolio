namespace CreditSuisse.FinPort.Domain.Interfaces
{
    public interface IFinantialInstrument
    {
        decimal MarketValue { get; }
        string Type { get; }
    }
}
