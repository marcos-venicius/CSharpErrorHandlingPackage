using ErrorHandling.Models;

namespace ErrorHandling.Models;

public static class ErrorExt
{
    public static Error<T>? GetErrorByKey<T>(this IEnumerable<Error<T>> errors, string key) where T : class
    {
        return errors.FirstOrDefault(x => x.Key == key);
    }
}