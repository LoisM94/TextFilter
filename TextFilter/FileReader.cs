using Microsoft.Extensions.Logging;

namespace TextFilter
{
    public class FileReader : IFileReader
    {
        private readonly ILogger<FileReader> _logger;

        public FileReader(ILogger<FileReader> logger)
        {
            _logger = logger;
        }

        public string ReadFile(string filePath)
        {
            _logger.LogInformation($"Reading file from path: {filePath}");
            try
            {
                using StreamReader reader = new(filePath);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while reading the file");
                throw;
            }
        }
    }
}
