using ErrorHandling.Exceptions;

namespace ErrorHandlingTests.Exceptions;

public class ErrorHandlerBaseExceptionTests
{
    private record CustomExceptionType1(string test);

    [Fact]
    public void Should_Catch_Exception_Of_Type_ErrorHandlerBaseException_When_Throw_With_Generics()
    {
        Assert.ThrowsAsync<ErrorHandlerBaseException>(() =>
        {
            throw new ErrorHandlerBaseException<CustomExceptionType1>("my error");
        });
    }

    [Fact]
    public void Should_Catch_Non_Generic_Exception()
    {
        Assert.ThrowsAsync<ErrorHandlerBaseException>(() =>
        {
            throw new ErrorHandlerBaseException("my error");
        });
    }

    [Fact]
    public void Should_Catch_Especific_Exception_Types()
    {
        Assert.ThrowsAsync<ErrorHandlerBaseException<CustomExceptionType1>>(() =>
        {
            throw new ErrorHandlerBaseException<CustomExceptionType1>("my error");
        });
    }
}