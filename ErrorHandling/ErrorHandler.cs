using ErrorHandling.Exceptions;
using ErrorHandling.Models;

namespace ErrorHandling;

public class ErrorHandler<T> : IDisposable where T : class
{
    private readonly bool __distinct;

    public IEnumerable<Error<T>> Errors { get; private set; }

    public ErrorHandler()
    {
        Errors = new HashSet<Error<T>>();
    }

    /// <summary>
    /// Pass true if you don't want errors with the same the
    /// </summary>
    /// <param name="distinct">if apply distinct</param>
    /// <returns></returns>
    public ErrorHandler(bool distinct) : this()
    {
        __distinct = distinct;
    }

    /// <summary>
    /// add an error to list
    /// </summary>
    /// <param name="error">error</param>
    public void Add(Error<T> error)
    {
        error.__distinct = __distinct;

        Errors = Errors.Append(error);
    }

    public void Dispose()
    {
        if (__distinct)
        {
            var errors = Errors.Distinct();

            if (errors.Any())
            {
                throw new ErrorHandlerException<Error<T>>(errors);
            }
        }
        else
        {
            if (Errors.Any())
            {
                throw new ErrorHandlerException<Error<T>>(Errors);
            }
        }
    }
}

public class ErrorHandler : ErrorHandler<string> { }