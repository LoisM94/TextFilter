using Application.Features.TextFilter.Strategies;
using FluentAssertions;

namespace Tests.UnitTests.Features.TextFilter
{
    public class LessThanThreeCharFilterStrategyTests
    {
        private readonly IFilterStrategy _filterStrategy = new LessThanThreeCharFilterStrategy();

        [Theory]
        [InlineData("a")]
        [InlineData("do")]
        [InlineData(" do ")]
        [InlineData("by")]
        [InlineData("at")]
        [InlineData("it")]
        [InlineData("as")]
        [InlineData("of")]
        [InlineData("so")]
        [InlineData("'So")]
        [InlineData("it.")]
        [InlineData("it,")]
        [InlineData("do:")]
        public void RequiresFilter_When_TextContainsWordWithLessThanThreeCharacters_Then_ResultShouldReturnTrue(string wordLessThanThreeChars)
        {
            // Act
            var result = _filterStrategy.RequiresFilter(wordLessThanThreeChars);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("bye")]
        [InlineData("far,")]
        [InlineData("considering")]
        [InlineData("where")]
        [InlineData("FEEL")]
        public void RequiresFilter_When_TextContainsWordWithMoreThanThanThreeCharacters_Then_ResultShouldReturnFalse(string wordMoreThanThreeChars)
        {
            // Act
            var result = _filterStrategy.RequiresFilter(wordMoreThanThreeChars);

            // Assert
            result.Should().BeFalse();
        }

    }
}
