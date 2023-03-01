namespace ErrorHandling.Models;

public sealed class Error<T>
{
    internal bool Distinct;

    public string Key { get; }
    public T? Value { get; }

    public Error(string key, T? value)
    {
        Key = key;
        Value = value;

        Distinct = false;
    }

    internal Error(string key, T? value, bool distinct) : this(key, value)
    {
        Distinct = distinct;
    }

    public override string ToString()
    {
        return $"{Key}:{Value}";
    }

    public void Deconstruct(out string key, out T? value)
    {
        key = Key;
        value = Value;
    }

    public override bool Equals(object? obj)
    {
        if (!Distinct)
            return obj is Error<T> err && err.Key == Key && Value?.Equals(err.Value) is not null;

        return (obj as Error<T>)!.Key == Key;
    }

    public override int GetHashCode()
    {
        return !Distinct ? HashCode.Combine(Key, Value) : Key.GetHashCode();
    }
}