namespace CloudSuite.Subscriptions.Domain.Exceptions
{
    public abstract class BadRequestException : Exception // Certifique-se de importar System;
    {
        protected BadRequestException(string message)
            : base(message) // Chama o construtor da classe base (Exception)
        {
        }
    }
}