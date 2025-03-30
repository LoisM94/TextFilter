using Application.Features.TextFilter;
using FluentAssertions;
using Moq;

namespace Tests.ComponentTests.Features.TextFilter;

public class TextFilterOrchestratorTests
{
    private readonly Mock<ITextFilterProcessor> _mockTextFilter = new();
    private TextFilterOrchestrator TextFilterOrchestrator;

    public TextFilterOrchestratorTests()
    {
        TextFilterOrchestrator = new TextFilterOrchestrator(_mockTextFilter.Object);
    }

    [Fact]
    public void FilterText_When_Called_Then_ReturnFilteredResult()
    {
        // Arrange
        _mockTextFilter.Setup(x => x.FilterText(It.IsAny<string>())).Returns("Filtered result");

        // Act
        var result = TextFilterOrchestrator.FilterText("Text to filter");

        // Assert
        result.Should().Be("Filtered result");
    }
}
