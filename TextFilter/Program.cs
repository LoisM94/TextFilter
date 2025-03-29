internal class Program
{
    private static void Main(string[] args)
    {
        string output = string.Empty;
        try
        {
            using StreamReader reader = new(".\\Files\\TextInput.txt");

            output = reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(ex.Message);
        }
        var textFilter = new TextFilter.TextFilter();

        var filteredText = textFilter.FilterText(output);

        Console.WriteLine(filteredText);
    }
}