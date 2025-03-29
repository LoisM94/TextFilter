using System.Text;
using TextFilter.Extensions;

namespace TextFilter
{
    public class TextFilter : ITextFilter
    {
        private bool _requiresFilter = false;
        private List<char> ListOfVowels = new() { 'a', 'e', 'i', 'o', 'u' };
        private readonly char[]? DelimiterChars = { ' ', ',', '.', ':', ';' };

        public string FilterText(string inputText)
        {
            var stringBuilder = new StringBuilder();
            string[] words = inputText.Split(DelimiterChars, StringSplitOptions.None);

            foreach (string word in words)
            {
                var lowerCaseWord = word.ToLower();

                if (lowerCaseWord.StripPunctuation().Length < 3)
                {
                    continue;
                }

                FilterOutWordsContainingVowelsInMiddle(lowerCaseWord);

                FilterOutWordsContainingLetterT(lowerCaseWord);

                if (!_requiresFilter)
                {
                    stringBuilder.Append(word + " ");
                }

                _requiresFilter = false;
            }

            return stringBuilder.ToString().Trim();
        }

        private void FilterOutWordsContainingVowelsInMiddle(string word)
        {
            var strippedWord = word.StripPunctuation();
            decimal middlePositionInWord = strippedWord.Length / 2m;

            if (middlePositionInWord % 1 == 0)
            {
                var firstMiddlePositionInWord = strippedWord[(int)middlePositionInWord - 1];
                var secondMiddlePositionInWord = strippedWord[(int)middlePositionInWord];

                if (ListOfVowels.Contains(firstMiddlePositionInWord) || ListOfVowels.Contains(secondMiddlePositionInWord))
                {
                    _requiresFilter = true;
                    return;
                }
            }
            else
            {
                var middlePostition = strippedWord[(int)Math.Floor(middlePositionInWord)];

                if (ListOfVowels.Contains(middlePostition))
                {
                    _requiresFilter = true;
                    return;
                }
            }
        }

        private void FilterOutWordsContainingLetterT(string word)
        {
            if (word.Contains("t"))
            {
                _requiresFilter = true;
            }
        }
    }
}
