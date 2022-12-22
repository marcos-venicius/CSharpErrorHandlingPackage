# ErrorHandling

## Installation

```sh
dotnet add package DevOne.Utils.ErrorHandling --version 1.1.0
```

### Usage

- ErrorHandler with value as string

```cs
{
    string name = "marcos test";

    using (var eh = new ErrorHandler())
    {
        switch (name.Length)
        {
            case < 3:
                eh.Add(new(nameof(name), "name length must be greater than 2"));
                break;
            case > 25:
                eh.Add(new(nameof(name), "name length must be less than 26"));
                break;
            default:
                break;
        }

        var regex = new Regex(@"^[a-z0-9]+$");

        if (!regex.IsMatch(name))
        {
            eh.Add(new(nameof(name), "name format is invalid"));
        }
    }
}
```

when the program get out of the `using` scope, if exists some error an exception of type
`new ErrorHandlerException<Error<string>>` will throws.

if you want to verify errors in a specific part of your code, you can avoid `using` and use like that:

```cs
{
    string name = "marcos test";

    var eh = new ErrorHandler();

    switch (name.Length)
    {
        case < 3:
            eh.Add(new(nameof(name), "name length must be greater than 2"));
            break;
        case > 25:
            eh.Add(new(nameof(name), "name length must be less than 26"));
            break;
        default:
            break;
    }

    var regex = new Regex(@"^[a-z0-9]+$");

    if (!regex.IsMatch(name))
    {
        eh.Add(new(nameof(name), "name format is invalid"));
    }

    ...

    eh.Dispose(); // verify the errors
}
```

if you want a diferent error value type use can do this like that:

* create a custom error value
```cs
{
    record CustomErrorValue(string Message, string Id, string Location);
}
```

* use this error value on error handler instance
```cs
{
    using (var eh = new ErrorHandler<CustomErrorValue>()) {}
}
```

* and now you need pass this type as the value
```cs
{
    eh.Add(new("my key", new CustomErrorValue("message", "id", "location")));
}
```

you can catch any exceptions from error handler like that:

```cs
try {
    ...
}
catch (ErrorHandlerBaseException exception)
{
    Console.WriteLine(exception.Message);

    foreach (var error in exception.Errors)
    {
        Console.WriteLine(error);
    }
}
```

this way will catch any type of exception that the ErrorHandler throws
if you want to catch a specific exception type you can:

```cs
try {
    ...
}
catch (ErrorHandlerException<Error<string>> exception)
{
    Console.WriteLine(exception.Message);

    foreach (var error in exception.Errors)
    {
        Console.WriteLine($"{error.Key}: {error.Value}"); // you have intellisense
    }
}
```
