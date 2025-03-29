using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TextFilter.Strategies;

internal class Program
{
    private readonly ILogger<Program> _logger;

    public Program(ILogger<Program> logger)
    {
        _logger = logger;
    }
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information))
            .AddTransient<Program>()
            .BuildServiceProvider();

        var program = serviceProvider.GetService<Program>();

        program.Run();
    }

    private void Run()
    {
        _logger.LogInformation("Application started");

        string output = ReadFile(".\\Files\\TextInput.txt");

        try
        {
            var textFilter = new TextFilter.TextFilter();
            textFilter.AddFilterStrategy(new LessThanThreeCharFilterStrategy());
            textFilter.AddFilterStrategy(new VowelInMiddleFilterStrategy());
            textFilter.AddFilterStrategy(new LetterTFilterStrategy());

            _logger.LogInformation("Filtering text...");
            var filteredText = textFilter.FilterText(output);
            _logger.LogInformation("Text filtering completed successfully");

            Console.WriteLine("Filtered text displayed below:");
            Console.WriteLine(filteredText);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during text filtering");
        }

        _logger.LogInformation("Application finished");
    }

    private string ReadFile(string filePath)
    {
        try
        {
            _logger.LogInformation($"Reading file from path: {filePath}");
            using StreamReader reader = new(filePath);
            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while reading the file");
            return string.Empty;
        }
    }
}
