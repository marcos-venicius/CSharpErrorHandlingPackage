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

    [Fact]
    public void Should_Not_Allow_Many_Errors_With_Same_Key_When_Distinct_Is_Enabled()
    {
        var errors = new List<Error<string>>() {
            new Error<string>("error", "first error").SetDistinct(true),
            new Error<string>("error", "second error").SetDistinct(true),
        };

        Assert.Single(errors.Distinct());
    }
}