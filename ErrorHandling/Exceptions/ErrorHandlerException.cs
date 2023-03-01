namespace ErrorHandling.Exceptions;

public class ErrorHandlerException<T> : ErrorHandlerBaseException where T : class
{
    public override HashSet<T> Errors { get; }

    public ErrorHandlerException(HashSet<T> errors) : base(GetMessage(errors.Count))
    {
        Errors = errors;
    }

    private static string GetMessage(int count)
    {
        return count == 1 ? "Houve um erro" : $"Houveram {count} erros";
    }
}