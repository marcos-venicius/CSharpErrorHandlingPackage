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
            throw new ErrorHandlerException<CustomExceptionType1>(new List<CustomExceptionType1>());
        });
    }

    [Fact]
    public void Should_Catch_Non_Generic_Exception()
    {
        Assert.ThrowsAsync<ErrorHandlerBaseException>(() =>
        {
            throw new ErrorHandlerException<string>(new List<string>());
        });
    }

    [Fact]
    public void Should_Catch_Especific_Exception_Types()
    {
        Assert.ThrowsAsync<ErrorHandlerException<CustomExceptionType1>>(() =>
        {
            throw new ErrorHandlerException<CustomExceptionType1>(new List<CustomExceptionType1>());
        });
    }
}