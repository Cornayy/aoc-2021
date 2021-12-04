namespace AdventOfCode2021.Core;

public class TextFileReader : IFileReader
{
    private const string ErrorMessage = "Something went wrong while trying to read file with given file path.";
    private readonly int _day;
    private readonly string _filePath;

    public TextFileReader(int day, string filePath)
    {
        _day = day;
        _filePath = filePath;
    }

    public string ReadAsString()
    {
        try
        {
            return File.ReadAllText($"{_filePath}/{_day}/input.txt");
        }
        catch (Exception)
        {
            Console.WriteLine(ErrorMessage);
        }

        return string.Empty;
    }

    public IEnumerable<string> ReadWithNewLines()
    {
        try
        {
            return File.ReadAllLines(Path.Combine(_filePath, $"{_day}/input.txt"));
        }
        catch (Exception)
        {
            Console.WriteLine(ErrorMessage);
        }

        return new List<string>();
    }
}
