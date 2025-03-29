namespace TextFilter.Strategies
{
    public class LetterTFilterStrategy : IFilterStrategy
    {
        public bool RequiresFilter(string word)
        {
            return word.ToLower().Contains('t');
        }
    }
}
