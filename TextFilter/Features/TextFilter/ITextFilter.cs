using TextFilter.Strategies;
namespace TextFilter.Features.TextFilter
{
    public interface ITextFilter
    {
        string FilterText(string text);

        void AddFilterStrategy(IFilterStrategy filterStrategy);
    }
}