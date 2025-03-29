using FluentAssertions;
using TextFilter;

namespace TextFilterUnitTests
{
    [Trait("Category", "Unit")]
    public class TextFilterUnitTests
    {
        private readonly ITextFilter _textFilter;
        public TextFilterUnitTests()
        {
            _textFilter = new TextFilter.TextFilter();
        }

        [Theory]
        [InlineData(" feel ")]
        [InlineData(" jar ")]
        [InlineData(" clean ")]
        [InlineData(" made ")]
        [InlineData(" ORANGE ")]
        [InlineData(" down ")]
        [InlineData(" very ")]
        [InlineData(" cupboards ")]
        public void TextFilter_When_TextContainsVowelInMiddleOfWord_Then_ResultShouldNotContainWord(string wordWithVowelInMiddle)
        {
            // Arrange
            using StreamReader arrangeReader = new(".\\Files\\Txt.txt");
            var setupTextFile = arrangeReader.ReadToEnd();

            // Act
            var result = _textFilter.FilterText(setupTextFile);

            // Assert
            result.Should().NotContain(wordWithVowelInMiddle);
        }

        [Theory]
        [InlineData(" without ")]
        [InlineData(" what ")]
        [InlineData(" thought ")]
        [InlineData(" There ")]
        [InlineData(" White ")]
        [InlineData(" afterwards ")]
        [InlineData(" tired ")]
        [InlineData(" PAST ")]
        public void TextFilter_When_TextContainsLetterT_Then_ResultShouldNotContainWord(string wordWithLetterT)
        {
            // Arrange
            using StreamReader arrangeReader = new(".\\Files\\Txt.txt");
            var setupTextFile = arrangeReader.ReadToEnd();

            // Act
            var result = _textFilter.FilterText(setupTextFile);

            // Assert
            result.Should().NotContain(wordWithLetterT);
        }

        [Theory]
        [InlineData(" a ")]
        [InlineData(" do ")]
        [InlineData(" by ")]
        [InlineData(" at ")]
        [InlineData(" it ")]
        [InlineData(" as ")]
        [InlineData(" of ")]
        [InlineData(" so ")]
        [InlineData(" 'So ")]
        [InlineData(" it. ")]
        [InlineData(" it, ")]
        [InlineData(" do: ")]
        public void TextFiler_When_TextContainsWordWithLessThanThreeCharacters_Then_ResultShouldNotContainWord(string wordLessThanThreeChars)
        {
            // Arrange
            using StreamReader arrangeReader = new(".\\Files\\Txt.txt");
            var setupTextFile = arrangeReader.ReadToEnd();

            // Act
            var result = _textFilter.FilterText(setupTextFile);

            // Assert
            result.Should().NotContain(wordLessThanThreeChars);
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
    }
}
