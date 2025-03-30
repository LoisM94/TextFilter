using Application.Features.TextFilter;
using Application.Features.TextFilter.Strategies;
using FluentAssertions;
using Moq;

namespace Tests.ComponentTests.Features.TextFilter
{
    public class TextFilterProcessorTests
    {
        private Mock<IFilterStrategy> _mockFilterStrategy = new();

        [Fact]
        public void FilterText_When_StrategiesAreAdded_FiltersCorrectly()
        {
            // Arrange
            var textFilterProcessor = new TextFilterProcessor();
            _mockFilterStrategy.Setup(s => s.RequiresFilter(It.Is<string>(word => word.ToLower().Contains("t")))).Returns(true);

            textFilterProcessor.AddFilterStrategy(_mockFilterStrategy.Object);

            // Act
            var result = textFilterProcessor.FilterText("This is a test string");

            // Assert
            result.Should().Be("is a");
            _mockFilterStrategy.Verify(s => s.RequiresFilter(It.IsAny<string>()), Times.Exactly(5)); // There are 5 words in the input string therefore filtering should occur exactly 5 times
        }
    }
}
