using ErrorHandling.Models;

namespace ErrorHandlingTests.Models;

public class ErrorTests
{
    [Fact]
    public void Should_Allow_Many_Errors_With_Same_Key_When_Distinct_Is_Disabled()
    {
        var errors = new List<Error<string>>() {
            new("error", "first error"),
            new("error", "second error"),
        };

        Assert.Equal(2, errors.Distinct().Count());
    }
}