namespace ErrorHandling.Exceptions;


public class ErrorHandlerBaseException<T> : ApplicationException
{
    public virtual IEnumerable<T> Errors { get; internal set; }

    public ErrorHandlerBaseException(string message) : base(message)
    {
        Errors = new HashSet<T>();
    }
}

public class ErrorHandlerBaseException : ErrorHandlerBaseException<object>
{
    public ErrorHandlerBaseException(string message) : base(message) { }
}