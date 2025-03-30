using Application.Features.TextFilter.Strategies;
using FluentAssertions;

namespace Tests.UnitTests.Features.TextFilter;

public class LetterTFilterStrategyTests
{
    private readonly IFilterStrategy _filterStrategy = new LetterTFilterStrategy();

    [Theory]
    [InlineData("without")]
    [InlineData("what")]
    [InlineData("thought")]
    [InlineData("There")]
    [InlineData("White")]
    [InlineData("afterwards")]
    [InlineData("tired")]
    [InlineData("PAST")]
    public void RequiresFilter_When_TextContainsLetterT_Then_ResultShouldReturnTrue(string wordWithLetterT)
    {
        // Arrange
        var result = _filterStrategy.RequiresFilter(wordWithLetterT);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("bye")]
    [InlineData("FEEL")]
    [InlineData("far,")]
    [InlineData("considering")]
    [InlineData("where")]
    public void RequiresFilter_When_TextContainsLetterT_Then_ResultShouldReturnFalse(string wordWithoutLetterT)
    {
        // Act
        var result = _filterStrategy.RequiresFilter(wordWithoutLetterT);

        // Assert
        result.Should().BeFalse();
    }

}
