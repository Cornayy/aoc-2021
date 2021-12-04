namespace AdventOfCode2021.Core.Interfaces;

public interface IFileReader
{
    string ReadAsString();
    IEnumerable<string> ReadAsEnumerable();
}
