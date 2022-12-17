namespace ErrorHandling.Exceptions;


public abstract class ErrorHandlerBaseException<T> : ApplicationException
{
    public virtual IEnumerable<T> Errors { get; internal set; }

    public ErrorHandlerBaseException(string message) : base(message)
    {
        Errors = new HashSet<T>();
    }
}

public abstract class ErrorHandlerBaseException : ErrorHandlerBaseException<object>
{
    public ErrorHandlerBaseException(string message) : base(message) { }
}