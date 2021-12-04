using AdventOfCode2021.Core.Interfaces;

namespace AdventOfCode2021.Core.Common;

public class TextFileReader : IFileReader
{
    private readonly string _filePath;

    public TextFileReader(int day, string filePath)
    {
        _filePath = Path.Combine(filePath, $"{day}/input.txt");
    }

    public string ReadAsString()
    {
        try
        {
            return File.ReadAllText(_filePath);
        }
        catch (Exception)
        {
            Console.WriteLine($"Unable to read {_filePath} with method {nameof(ReadAsString)}.");
        }

        return string.Empty;
    }

    public IEnumerable<string> ReadAsEnumerable()
    {
        try
        {
            return File.ReadAllLines(_filePath);
        }
        catch (Exception)
        {
            Console.WriteLine($"Unable to read {_filePath} with method {nameof(ReadAsEnumerable)}.");
        }

        return new List<string>();
    }
}
