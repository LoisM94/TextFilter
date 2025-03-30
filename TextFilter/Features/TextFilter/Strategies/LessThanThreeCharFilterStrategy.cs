using Application.Extensions;

namespace Application.Features.TextFilter.Strategies
{
    public class LessThanThreeCharFilterStrategy : IFilterStrategy
    {
        public bool RequiresFilter(string word)
        {
            return word.StripPunctuation().Trim().Length < 3;
        }
    }
}