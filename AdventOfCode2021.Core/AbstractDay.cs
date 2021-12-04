using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode2021.Core;

public abstract class AbstractDay : IDay
{
    protected IFileReader FileReader { get; private set; }

    public AbstractDay(int day)
    {
        var basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.CurrentProjectFolder());
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
        SolveAndLogElapsedSeconds(SolveA);
        SolveAndLogElapsedSeconds(SolveB);
    }

    private static void SolveAndLogElapsedSeconds(Action action)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        action();
        Console.WriteLine($"Executed {action.Method.Name} ({stopWatch.ElapsedMilliseconds} ms)");

        stopWatch.Stop();
    }
}
