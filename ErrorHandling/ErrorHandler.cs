using ErrorHandling.Exceptions;
using ErrorHandling.Extensions;
using ErrorHandling.Models;

namespace ErrorHandling;

public sealed class ErrorHandler<T> : IDisposable where T : class
{
    private readonly bool _distinct;

    public HashSet<Error<T>> Errors { get; }

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
        _distinct = distinct;
    }

    /// <summary>
    /// add error to list
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Add(string key, T? value)
    {
        var error = new Error<T>(key, value, _distinct);

        Errors.Add(error);
    }
    
    public T? this[string key]
    {
        get => Errors.GetErrorByKey(key)?.Value;
        set => Add(key, value);
    }

    public void Dispose()
    {
        var errors = Errors;

        if (_distinct)
            errors = Errors.Distinct().ToHashSet();


        if (errors.Any())
            throw new ErrorHandlerException<Error<T>>(Errors);
    }
}