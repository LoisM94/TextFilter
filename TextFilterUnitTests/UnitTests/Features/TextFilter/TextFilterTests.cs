using Application.Features.TextFilter;
using Application.Features.TextFilter.Strategies;
using FluentAssertions;

namespace Tests.UnitTests.Features.TextFilter
{
    [Trait("Category", "Unit")]
    public class TextFilterTests
    {
        private readonly ITextFilterProcessor _textFilter;
        private readonly List<IFilterStrategy> _filterStrategies;
        public TextFilterTests()
        {
            _filterStrategies =
            [
                new LessThanThreeCharFilterStrategy(),
                new VowelInMiddleFilterStrategy(),
                new LetterTFilterStrategy()
            ];

            _textFilter = new TextFilterProcessor();
            _filterStrategies.ForEach(strategy => _textFilter.AddFilterStrategy(strategy));
        }

        [Theory]
        [InlineData(" wonder ")]
        [InlineData(" she ")]
        [InlineData(" and ")]
        [InlineData(" considering ")]
        [InlineData("beginning ")]
        [InlineData(" never ")]
        [InlineData(" passed ")]
        [InlineData(" dipped ")]
        [InlineData(" killing ")]
        public void TextFilter_When_TextDoesNotRequireAnyFiltering_Then_ResultShouldContainWord(string word)
        {
            // Arrange
            using StreamReader arrangeReader = new(".\\Files\\Txt.txt");
            var setupTextFile = arrangeReader.ReadToEnd();

            // Act
            var result = _textFilter.FilterText(setupTextFile);

            // Assert
            result.Should().Contain(word);
        }

        [Theory]
        [InlineData(" for ")]
        [InlineData(" do ")]
        [InlineData(" as ")]
        [InlineData(" There ")]
        [InlineData("ORANGE ")]
        [InlineData(" MARMALADE ")]
        [InlineData(" 'So ")]
        [InlineData(" down, ")]
        [InlineData(" what ")]
        public void TextFilter_When_TextDoesRequireFiltering_Then_ResultShouldNotContainWord(string word)
        {
            // Arrange
            using StreamReader arrangeReader = new(".\\Files\\Txt.txt");
            var setupTextFile = arrangeReader.ReadToEnd();

            // Act
            var result = _textFilter.FilterText(setupTextFile);

            // Assert
            result.Should().NotContain(word);
        }

        [Fact]
        public void TextFilter_When_TextIsEmpty_Then_ResultShouldBeEmpty()
        {
            // Act
            var result = _textFilter.FilterText("");

            // Assert
            result.Should().BeEmpty();
        }
    }
}
