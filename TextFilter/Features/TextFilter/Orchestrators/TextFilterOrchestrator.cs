using TextFilter.Features.TextFilter;
using TextFilter.Strategies;

namespace TextFilter.Orchestrators
{
    public class TextFilterOrchestrator : ITextFilterOrchestrator
    {
        private readonly ITextFilter _textFilter;

        public TextFilterOrchestrator()
        {
            _textFilter = new Features.TextFilter.TextFilter();
            _textFilter.AddFilterStrategy(new LessThanThreeCharFilterStrategy());
            _textFilter.AddFilterStrategy(new VowelInMiddleFilterStrategy());
            _textFilter.AddFilterStrategy(new LetterTFilterStrategy());
        }

        public string FilterText(string inputText)
        {
            return _textFilter.FilterText(inputText);
        }
    }
}
