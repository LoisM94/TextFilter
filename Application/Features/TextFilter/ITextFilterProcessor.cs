using Application.Features.TextFilter.Strategies;

namespace Application.Features.TextFilter;

public interface ITextFilterProcessor
{
    string FilterText(string text);

    void AddFilterStrategy(IFilterStrategy filterStrategy);
}