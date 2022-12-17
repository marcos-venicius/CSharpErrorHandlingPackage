
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
}