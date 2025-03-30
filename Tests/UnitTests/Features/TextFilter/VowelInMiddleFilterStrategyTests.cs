using Application.Features.TextFilter.Strategies;
using FluentAssertions;

namespace Tests.UnitTests.Features.TextFilter;

public class VowelInMiddleFilterStrategyTests
{
    private readonly IFilterStrategy _filterStrategy = new VowelInMiddleFilterStrategy();

    [Theory]
    [InlineData("feel")]
    [InlineData("feel ")]
    [InlineData("jar")]
    [InlineData("clean")]
    [InlineData("made")]
    [InlineData("ORANGE")]
    [InlineData("down")]
    [InlineData("down,")]
    [InlineData("very")]
    [InlineData("cupboards")]
    public void RequiresFilter_When_TextContainsVowelInMiddleOfWord_Then_ResultShouldReturnTrue(string wordWithVowelInMiddle)
    {
        // Act
        var result = _filterStrategy.RequiresFilter(wordWithVowelInMiddle);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("bye")]
    [InlineData("right")]
    [InlineData("SHE")]
    [InlineData("and")]
    [InlineData("biginning")]
    [InlineData("she.")]
    public void RequiresFilter_When_TextDoesNotContainVowelInMiddleOfWord_Then_ResultShouldReturnFalse(string wordWithoutVowelInMiddle)
    {
        // Act
        var result = _filterStrategy.RequiresFilter(wordWithoutVowelInMiddle);

        // Assert
        result.Should().BeFalse();
    }

}
