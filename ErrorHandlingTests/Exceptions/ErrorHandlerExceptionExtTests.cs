using ErrorHandling.Models;

namespace ErrorHandlingTests.Exceptions;

public class ErrorHandlerExceptionExtTests
{
    [Fact]
    public void Should_Get_Error_By_Key_If_They_Exists_On_IEnumerable_Of_Error_Of_String()
    {
        var errors = new List<Error<string>>() {
            new("a", "error a"),
            new("b", "error b"),
        };

        var error = errors.GetErrorByKey("a");

        Assert.Equal("a", error?.Key);
        Assert.Equal("error a", error?.Value);
    }

    private class ASDF
    {
        public string Message { get; init; } = "";
    };

    [Fact]
    public void Should_Get_Error_By_Key_If_They_Exists_On_IEnumerable_Of_Error_Of_Any_Type()
    {
        var errors = new List<Error<ASDF>>() {
            new("test", new() { Message = "testing" }),
            new("test2", new() { Message = "testing 2" }),
        };

        var error = errors.GetErrorByKey("test");

        Assert.Equal("test", error?.Key);
        Assert.IsType<ASDF>(error?.Value);
    }

    [Fact]
    public void Should_Return_Null_When_Not_Found_An_Error()
    {
        var errors = new List<Error<string>>();

        var error = errors.GetErrorByKey("any");

        Assert.Null(error);
    }
}