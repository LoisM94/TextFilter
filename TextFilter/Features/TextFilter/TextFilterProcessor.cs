using Application.Features.TextFilter.Strategies;
using System.Text;

namespace Application.Features.TextFilter
{
    public class TextFilterProcessor : ITextFilterProcessor
    {
        private readonly List<IFilterStrategy> _filterStrategies = new();
        private readonly char[]? DelimiterChars = { ' ', ',', '.', ':', ';' };

        public void AddFilterStrategy(IFilterStrategy filterStrategy)
        {
            _filterStrategies.Add(filterStrategy);
        }

        public string FilterText(string inputText)
        {
            var stringBuilder = new StringBuilder();
            string[] words = inputText.Split(DelimiterChars, StringSplitOptions.None);

            foreach (string word in words.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                if (_filterStrategies.Any(strategy => strategy.RequiresFilter(word)))
                {
                    // If the word requires filtering don't append to the String Builder 
                    continue;
                }

                stringBuilder.Append(word + " ");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
