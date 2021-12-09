using System.Drawing;

namespace AdventOfCode2021._5;

public class Day5 : Day
{
    private readonly IEnumerable<Line> _lines;

    public Day5() : base(5)
    {
        _lines = FileReader.ReadAsEnumerable().Select(x =>
        {
            var coordinates = x.Split(" -> ");
            if (coordinates.Length != 2) throw new Exception("Invalid amount of coordinates.");

            var start = coordinates[0].Split(",");
            var end = coordinates[1].Split(",");
            if (start.Length != 2 || end.Length != 2) throw new Exception("Invalid amount of points.");

            return new Line
            {
                Start = new Point()
                {
                    X = TryParsePointMember(start[0]),
                    Y = TryParsePointMember(start[1])
                },
                End = new Point()
                {
                    X = TryParsePointMember(end[0]),
                    Y = TryParsePointMember(end[1])
                }
            };
        });
    }

    protected override void SolveA()
    {
        var overlap = GetAmountOfOverlappedLines();
        Console.Write(overlap);
    }

    protected override void SolveB()
    {
        var overlap = GetAmountOfOverlappedLines(diagonal: true);
        Console.Write(overlap);
    }

    private int GetAmountOfOverlappedLines(bool diagonal = false)
    {
        var map = new int[1000, 1000];

        foreach (var line in _lines)
        {
            var startX = line.Start.X;
            var startY = line.Start.Y;
            var endX = line.End.X;
            var endY = line.End.Y;

            if (diagonal || startX == endX || startY == endY)
            {
                map[endY, endX]++;

                while (startX != endX || startY != endY)
                {
                    map[startY, startX]++;

                    if (startX != endX)
                    {
                        startX += startX < endX ? 1 : -1;
                    }

                    if (startY != endY)
                    {
                        startY += startY < endY ? 1 : -1;
                    }
                }
            }
        }

        return map.Flat().Count(item => item.value >= 2);
    }

    private static int TryParsePointMember(string member)
    {
        var isParsed = int.TryParse(member, out var pointMember);
        if (!isParsed) throw new Exception($"Could not parse point member {member}.");
        return pointMember;
    }
}
