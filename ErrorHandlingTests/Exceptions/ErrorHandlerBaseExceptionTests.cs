using ErrorHandling.Exceptions;

namespace ErrorHandlingTests.Exceptions;

public class ErrorHandlerBaseExceptionTests
{
    private record CustomException;

    [Fact]
    public void Should_Catch_Exception_Of_Type_ErrorHandlerBaseException_When_Throw_With_Generics()
    {
        Assert.ThrowsAsync<ErrorHandlerBaseException>(() =>
            throw new ErrorHandlerException<CustomException>(new HashSet<CustomException>()));
    }

    [Fact]
    public void Should_Catch_Non_Generic_Exception()
    {
        Assert.ThrowsAsync<ErrorHandlerBaseException>(() =>
            throw new ErrorHandlerException<string>(new HashSet<string>()));
    }

    [Fact]
    public void Should_Catch_Especific_Exception_Types()
    {
        Assert.ThrowsAsync<ErrorHandlerException<CustomException>>(() =>
            throw new ErrorHandlerException<CustomException>(new HashSet<CustomException>()));
    }
}