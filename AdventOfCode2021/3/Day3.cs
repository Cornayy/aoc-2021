namespace AdventOfCode2021._3;

public class Day3 : Day
{
    public Day3() : base(3)
    {

    }

    protected override void SolveA()
    {
        var binaries = FileReader.ReadAsEnumerable();
        var first = binaries.FirstOrDefault();

        if (first == null) throw new Exception("Cannot parse empty binary.");

        var gamma = Convert.ToInt32(ConstructBinaryA(binaries, first.Length, common: true), 2);
        var epsilon = Convert.ToInt32(ConstructBinaryA(binaries, first.Length, common: false), 2);

        Console.Write(gamma * epsilon);
    }

    protected override void SolveB()
    {
        var binaries = FileReader.ReadAsEnumerable();
        var first = binaries.FirstOrDefault();

        if (first == null) throw new Exception("Cannot parse empty binary.");

        var oxygen = Convert.ToInt32(ConstructBinaryB(binaries, first.Length, common: true), 2);
        var co = Convert.ToInt32(ConstructBinaryB(binaries, first.Length, common: false), 2);

        Console.Write(oxygen * co);
    }

    private static string ConstructBinaryB(IEnumerable<string> binaries, int length, bool common)
    {
        var expression = binaries.Select(x => x.ToCharArray()).ToList();

        for (var i = 0; i < length; i++)
        {
            var oneCount = expression.Where(x => x[i] == '1').Count();
            var zeroCount = expression.Where(x => x[i] == '0').Count();
            var areEqual = zeroCount < oneCount || zeroCount == oneCount;

            if (common)
            {
                expression = areEqual ? expression.Where(x => x[i] == '1').ToList() : expression.Where(x => x[i] == '0').ToList();
            }
            else if (expression.Count > 1)
            {
                expression = areEqual ? expression.Where(x => x[i] == '0').ToList() : expression.Where(x => x[i] == '1').ToList();
            }
        }

        return new string(expression.First());
    }

    private static string ConstructBinaryA(IEnumerable<string> binaries, int length, bool common)
    {
        var binary = string.Empty;

        for (var i = 0; i < length; i++)
        {
            var expression = binaries.Select(x => x[i]).GroupBy(x => x);

            if (common) expression = expression.OrderByDescending(x => x.Count());
            else expression = expression.OrderBy(x => x.Count());

            var result = expression.First().Key;
            binary += result;
        }

        return binary;
    }
}
