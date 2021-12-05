namespace AdventOfCode2021._2;

public class Day2 : Day
{
    public Day2() : base(2)
    {

    }

    protected override void SolveA()
    {
        var commands = FileReader.ReadAsEnumerable();
        var depth = 0;
        var x = 0;

        foreach (var command in commands)
        {
            var instruction = ParseCommand(command);

            switch (instruction.Item1)
            {
                case "forward":
                    x += instruction.Item2;
                    break;
                case "down":
                    depth += instruction.Item2;
                    break;
                case "up":
                    depth -= instruction.Item2;
                    break;
                default:
                    throw new Exception($"Direction {instruction.Item1} is not supported.");
            }
        }

        Console.Write(x * depth);
    }

    protected override void SolveB()
    {
        var commands = FileReader.ReadAsEnumerable();
        var depth = 0;
        var x = 0;
        var aim = 0;

        foreach (var command in commands)
        {
            var instruction = ParseCommand(command);

            switch (instruction.Item1)
            {
                case "forward":
                    x += instruction.Item2;
                    depth += aim * instruction.Item2;
                    break;
                case "down":
                    aim += instruction.Item2;
                    break;
                case "up":
                    aim -= instruction.Item2;
                    break;
                default:
                    throw new Exception($"Direction {instruction.Item1} is not supported.");
            }
        }

        Console.Write(x * depth);
    }

    private static Tuple<string, int> ParseCommand(string command)
    {
        var instructions = command.Split();
        if (instructions.Length != 2) throw new Exception("Instruction size is incorrect.");

        var direction = instructions[0];
        var unitParsed = int.TryParse(instructions[1], out var unit);
        if (string.IsNullOrEmpty(direction) || !unitParsed) throw new Exception("Could not parse instruction, direction or unit is incorrect.");

        return Tuple.Create(direction, unit);
    }
}
