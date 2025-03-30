namespace Application.Features.TextFilter.Strategies;

public interface IFilterStrategy
{
    bool RequiresFilter(string text);
}