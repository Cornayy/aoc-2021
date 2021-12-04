using AdventOfCode2021.Core.Interfaces;
using System.Diagnostics;

namespace AdventOfCode2021.Core.Common;

public abstract class Day : IDay
{
    protected IFileReader FileReader { get; private set; }

    public Day(int day)
    {
        var basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.GetCurrentProjectFolder());
        if (string.IsNullOrEmpty(basePath)) throw new Exception("Base directory path could not be found.");

        FileReader = new TextFileReader(
            day,
            basePath
        );
    }

    protected abstract void SolveA();

    protected abstract void SolveB();

    public void Solve()
    {
        Console.Write($"[{nameof(SolveA)}]: ");
        SolveAndLogElapsedSeconds(SolveA);

        Console.Write($"[{nameof(SolveB)}]: ");
        SolveAndLogElapsedSeconds(SolveB);
    }

    private static void SolveAndLogElapsedSeconds(Action action)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        action();
        Console.WriteLine($" ({stopWatch.ElapsedMilliseconds} ms)");

        stopWatch.Stop();
    }
}
