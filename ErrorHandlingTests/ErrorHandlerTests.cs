
using ErrorHandling;
using ErrorHandling.Exceptions;

namespace ErrorHandlingTests;

public class ErrorHandlerTests
{
    [Fact]
    public void Should_Throw_Distinct_Errors_When_Distinct_Is_Enabled()
    {
        var exception = Assert.ThrowsAny<ErrorHandlerBaseException>(() =>
        {
            using (var errorHandler = new ErrorHandler(true))
            {
                errorHandler.Add(new("error", "first error"));
                errorHandler.Add(new("error", "second error"));
            }
        });

        Assert.Single(exception.Errors);
    }

    [Fact]
    public void Should_Throw_All_Errors_When_Distinct_Is_Disabled()
    {
        var exception = Assert.ThrowsAny<ErrorHandlerBaseException>(() =>
        {
            using (var errorHandler = new ErrorHandler())
            {
                errorHandler.Add(new("error", "first error"));
                errorHandler.Add(new("error", "second error"));
            }
        });

        Assert.Equal(2, exception.Errors.Count());
    }

    [Fact]
    public void Should_Not_Throw_Exception_If_No_Has_Errors()
    {
        var errorHandler = new ErrorHandler();

        errorHandler.Dispose();

        Assert.Empty(errorHandler.Errors);
    }
}