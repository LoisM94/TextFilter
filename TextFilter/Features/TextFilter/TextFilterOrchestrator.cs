using Application.Features.TextFilter.Strategies;

namespace Application.Features.TextFilter
{
    public class TextFilterOrchestrator : ITextFilterOrchestrator
    {
        private readonly ITextFilterProcessor _textFilter;

        public TextFilterOrchestrator(ITextFilterProcessor textFilter)
        {
            _textFilter = textFilter;
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
