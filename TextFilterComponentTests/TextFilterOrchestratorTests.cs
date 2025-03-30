using Moq;
using FluentAssertions;
using Application.Features.TextFilter;

namespace TextFilterComponentTests
{
    public class TextFilterOrchestratorTests
    {
        private readonly Mock<ITextFilterProcessor> _mockTextFilter = new();
        private TextFilterOrchestrator TextFilterOrchestrator;

        public TextFilterOrchestratorTests()
        {
            TextFilterOrchestrator = new TextFilterOrchestrator(_mockTextFilter.Object);
        }

        [Fact]
        public void FilterText_When_Called_Then_VerifyFilterTextInTextFilterIsInvoked()
        {
            // Arrange
            _mockTextFilter.Setup(x => x.FilterText(It.IsAny<string>())).Returns("Filtered result");



        }
    }
}
