namespace AdventOfCode2021._7;

public class Day7 : Day
{
    private readonly IEnumerable<int> _positions;

    public Day7() : base(7)
    {
        _positions = FileReader.ReadAsString().Split(",").ConvertToIntegerEnumerable();
    }

    protected override void SolveA()
    {
        var cost = GetMinimumFuelCost();
        Console.Write(cost);
    }

    protected override void SolveB()
    {
        var cost = GetMinimumFuelCost(expensive: true);
        Console.Write(cost);
    }

    private int GetMinimumFuelCost(bool expensive = false)
    {
        var max = _positions.Max();
        var sums = new Dictionary<int, int>();
        var result = new List<int>();

        for (var dest = 0; dest <= max; dest++)
        {
            sums[dest] = Enumerable.Range(1, dest).Sum();
        }

        for (var dest = 0; dest <= max; dest++)
        {
            var fuel = _positions
                .Select(crab => Math.Abs(crab - dest))
                .Select(change => expensive ? sums[change] : change)
                .Sum();

            result.Add(fuel);
        }

        return result.Min();
    }
}
