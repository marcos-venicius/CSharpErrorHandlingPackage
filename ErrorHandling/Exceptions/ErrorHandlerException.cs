namespace ErrorHandling.Exceptions;

public class ErrorHandlerException<T> : ErrorHandlerBaseException where T : class
{
    public override IEnumerable<T> Errors { get; }

    public ErrorHandlerException(IEnumerable<T> errors) : base(GetMessage(errors.Count()))
    {
        Errors = errors;
    }

    private static string GetMessage(int count)
    {
        if (count == 1)
        {
            return "Houve um erro";
        }

        return $"Houveram {count} erros";
    }
}
