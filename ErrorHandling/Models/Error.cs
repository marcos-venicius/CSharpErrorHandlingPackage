namespace ErrorHandling.Models;

public class Error<T> where T : class
{
    internal bool __distinct;

    public string Key { get; }
    public T Value { get; }

    public Error(string key, T value)
    {
        Key = key;
        Value = value;

        __distinct = false;
    }

    public override string ToString()
    {
        return $"{Key}:{Value}";
    }

    public override bool Equals(object? obj)
    {
        if (!__distinct)
        {
            return base.Equals(obj);
        }

        if (obj is null || obj is not Error<T>)
        {
            return false;
        }

        return (obj as Error<T>)!.Key == Key;
    }

    public override int GetHashCode()
    {
        if (!__distinct)
        {
            return base.GetHashCode();
        }
        else
        {
            return Key.GetHashCode();
        }
    }
}