namespace CreditSuisse.FinPort.Domain
{
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string message) : base(message) { }
    }

    public static class ExceptionExtensions
    {
        public static string GetFullMessage(this Exception exception) => $"An unexpected error occour: {exception.Message} {exception.GetBaseException().Message} | {exception.StackTrace}";
    }
}
