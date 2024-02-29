namespace CreditSuisse.FinPort.Application.Interface.DTO
{
    public class Envelope
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
    }
    
    public class Envelope<T> : Envelope
    {
        public T? Data { get; set; }
    }
}
