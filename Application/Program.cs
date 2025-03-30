using Application.Features.TextFilter;
using Application.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

internal class Program
{
    private readonly IFileReader _fileReader;
    private readonly ITextFilterOrchestrator _textFilterOrchestrator;
    private readonly ILogger<Program> _logger;

    public Program(IFileReader fileReader, ITextFilterOrchestrator textFilterOrchestrator, ILogger<Program> logger)
    {
        _fileReader = fileReader;
        _textFilterOrchestrator = textFilterOrchestrator;
        _logger = logger;
    }

    public static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder
                .AddConsole()
                .AddConfiguration(configuration.GetSection("Logging")))
            .AddTransient<Program>()
            .AddTransient<IFileReader, FileReader>()
            .AddTransient<ITextFilterOrchestrator, TextFilterOrchestrator>()
            .AddTransient<ITextFilterProcessor, TextFilterProcessor>()
            .BuildServiceProvider();

        var program = serviceProvider.GetService<Program>();

        program?.Run(configuration);
    }

    private void Run(IConfiguration configuration)
    {
        _logger.LogInformation("Application started");
        try
        {
            var filePath = configuration.GetValue<string>("FilePath");
            if(string.IsNullOrEmpty(filePath))
            {
                _logger.LogError("File path is not provided in the configuration");
                return;
            }

            _logger.LogInformation("Reading file...");
            var fileContent = _fileReader.ReadFile(filePath);
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
