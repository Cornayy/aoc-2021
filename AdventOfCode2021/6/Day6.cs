namespace AdventOfCode2021._6;

public class Day6 : Day
{
    private readonly IEnumerable<Fish> _lanternFishes;

    public Day6() : base(6)
    {
        _lanternFishes = FileReader.ReadAsString().Split(",").Select(x => new Fish { Timer = int.Parse(x), AmountOfFish = 1 });
    }

    protected override void SolveA()
    {
        var number = Simulate(80);
        Console.Write(number);
    }

    protected override void SolveB()
    {
        var number = Simulate(256);
        Console.Write(number);
    }

    private long Simulate(int days)
    {
        var fishes = _lanternFishes.ToList();

        for (var i = 0; i < days; i++)
        {
            var additions = AddFish(fishes);
            if (additions > 0)
            {
                fishes.Add(new Fish { Timer = 8, AmountOfFish = additions });
            }
        }

        return fishes.Sum(x => x.AmountOfFish);
    }

    private static long AddFish(List<Fish> fishes)
    {
        long count = 0;
        foreach (var fish in fishes)
        {
            if (fish.Timer == 0)
            {
                fish.Timer = 6;
                count += fish.AmountOfFish;
            }
            else
            {
                fish.Timer--;
            }
        }

        return count;
    }
}
