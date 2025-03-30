using Application.Features.TextFilter;
using Application.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{
    private readonly IFileReader _fileReader;
    private readonly ITextFilterOrchestrator _textFilterOrchestrator;
    private readonly ILogger<Program> _logger;
    private readonly string _filePath = ".\\Resources\\TextInput.txt";

    public Program(IFileReader fileReader, ITextFilterOrchestrator textFilterOrchestrator, ILogger<Program> logger)
    {
        _fileReader = fileReader;
        _textFilterOrchestrator = textFilterOrchestrator;
        _logger = logger;
    }

    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information))
            .AddTransient<Program>()
            .AddTransient<IFileReader, FileReader>()
            .AddTransient<ITextFilterOrchestrator, TextFilterOrchestrator>()
            .AddTransient<ITextFilterProcessor, TextFilterProcessor>()
            .BuildServiceProvider();

        var program = serviceProvider.GetService<Program>();

        program?.Run();
    }

    private void Run()
    {
        _logger.LogInformation("Application started");
        try
        {
            var fileContent = _fileReader.ReadFile(_filePath);
            _logger.LogInformation("File read successfully");

            _logger.LogInformation("Filtering text...");
            var filteredText = _textFilterOrchestrator.FilterText(fileContent);
            _logger.LogInformation("Text filtering completed successfully");

            Console.WriteLine("\r\nFiltered text:");
            Console.WriteLine(filteredText);
            Console.WriteLine("\r\n");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during execution");
        }

        _logger.LogInformation("Application finished");
    }
}
