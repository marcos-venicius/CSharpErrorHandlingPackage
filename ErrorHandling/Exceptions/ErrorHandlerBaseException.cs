namespace ErrorHandling.Exceptions;

public class ErrorHandlerBaseException : ApplicationException
{
    public virtual IEnumerable<object> Errors { get; }

    public ErrorHandlerBaseException(string message) : base(message)
    {
        Errors = new HashSet<object>();
    }
}
