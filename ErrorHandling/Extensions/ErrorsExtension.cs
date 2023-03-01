using ErrorHandling.Models;

namespace ErrorHandling.Extensions;

public static class ErrorsExtension
{
    public static Error<T>? GetErrorByKey<T>(this IEnumerable<Error<T>> errors, string key)
    {
        return errors.FirstOrDefault(err => err.Key == key);
    }
}