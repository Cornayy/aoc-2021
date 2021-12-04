namespace AdventOfCode2021.Core;

public interface IFileReader
{
    string ReadAsString();
    IEnumerable<string> ReadWithNewLines();
}
