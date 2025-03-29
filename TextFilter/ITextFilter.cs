using TextFilter.Strategies;
namespace TextFilter
{
    public interface ITextFilter
    {
        string FilterText(string text);

        void AddFilterStrategy(IFilterStrategy filterStrategy);
    }
}