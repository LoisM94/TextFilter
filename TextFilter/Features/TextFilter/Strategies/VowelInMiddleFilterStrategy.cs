using Application.Extensions;

namespace Application.Features.TextFilter.Strategies;

public class VowelInMiddleFilterStrategy : IFilterStrategy
{
    private readonly List<char> _listOfVowels = ['a', 'e', 'i', 'o', 'u'];

    public bool RequiresFilter(string word)
    {
        var strippedWord = word.ToLower().Trim().StripPunctuation();
        decimal middlePositionInWord = strippedWord.Length / 2m;

        if (middlePositionInWord % 1 == 0)
        {
            var firstMiddlePositionInWord = strippedWord[(int)middlePositionInWord - 1];
            var secondMiddlePositionInWord = strippedWord[(int)middlePositionInWord];

            return _listOfVowels.Contains(firstMiddlePositionInWord) || _listOfVowels.Contains(secondMiddlePositionInWord);
        }
        else
        {
            var middlePosition = strippedWord[(int)Math.Floor(middlePositionInWord)];
            return _listOfVowels.Contains(middlePosition);
        }
    }
}
