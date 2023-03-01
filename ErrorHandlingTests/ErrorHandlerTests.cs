using ErrorHandling;
using ErrorHandling.Exceptions;
using ErrorHandling.Extensions;
using ErrorHandling.Models;

namespace ErrorHandlingTests;

public class ErrorHandlerTests
{
    [Fact]
    public void Should_Throw_Distinct_Errors_When_Distinct_Is_Enabled()
    {
        var exception = Assert.ThrowsAny<ErrorHandlerBaseException>(() =>
        {
            using var errorHandler = new ErrorHandler<string>(true);

            errorHandler.Add("error", "first error");
            errorHandler.Add("error", "second error");
        });

        Assert.Single(exception.Errors);
    }

    [Fact]
    public void Should_Throw_All_Errors_When_Distinct_Is_Disabled()
    {
        var exception = Assert.ThrowsAny<ErrorHandlerBaseException>(() =>
        {
            using var errorHandler = new ErrorHandler<string>();

            errorHandler.Add("error", "first error");
            errorHandler.Add("error", "second error");
        });

        Assert.Equal(2, exception.Errors.Count());
    }

    [Fact]
    public void Should_Not_Throw_Exception_If_No_Has_Errors()
    {
        var errorHandler = new ErrorHandler<string>();

        errorHandler.Dispose();

        Assert.Empty(errorHandler.Errors);
    }

    [Fact]
    public void Should_Assign_Errors_Via_Indexer()
    {
        var eh = new ErrorHandler<string>();

        eh["name"] = "nome inválido";
        eh["age"] = "idade inválida";

        Assert.Equal(2, eh.Errors.Count);
        Assert.Equal("nome inválido", eh["name"]);
        Assert.Equal("idade inválida", eh["age"]);
    }

    [Fact]
    public void Should_Assign_Errors_Via_Indexer_With_Custom_Error()
    {
        var eh = new ErrorHandler<CustomError>();

        eh["name"] = new CustomError("nome inválido");
        eh["age"] = new CustomError("idade inválida");

        Assert.Equal(2, eh.Errors.Count);
        Assert.Equal("nome inválido", eh["name"]?.Message);
        Assert.Equal("idade inválida", eh["age"]?.Message);
    }

    [Fact]
    public void Should_Deconstruct_Error()
    {
        var eh = new ErrorHandler<string>();

        eh["name"] = "nome inválido";
        eh["age"] = "idade inválida";

        var exception = Assert.Throws<ErrorHandlerException<Error<string>>>(() => { eh.Dispose(); });

        var error = exception.Errors.GetErrorByKey("name");

        var (key, message) = error!;

        Assert.Equal("name", key);
        Assert.Equal("nome inválido", message);
    }
}

/*
 * version 2.0.0

- reduce the verbosity adding errors by using indexers eh["error"] = "message"
- improve how to add new errors via method
- allow to get errors via indexers eh["error"] == "message"


 */

internal record CustomError(string Message);