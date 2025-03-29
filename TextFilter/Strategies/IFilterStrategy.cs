namespace TextFilter.Strategies
{
    public interface IFilterStrategy
    {
        string RequiresFilter(string text);
    }
}
