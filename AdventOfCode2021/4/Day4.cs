namespace AdventOfCode2021._4;

public class Day4 : Day
{
    private readonly IEnumerable<int> _numbers;
    private readonly List<BingoBoard> _boards;

    public Day4() : base(4)
    {
        var input = FileReader.ReadAsEnumerable().ToList();
        _numbers = input
            .First()
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse);
        _boards = new List<BingoBoard>();

        foreach (var chunk in input.Skip(2).Chunk(6))
        {
            var board = chunk.Take(5)
                .Select(l => l
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(i => new Number() { Value = int.Parse(i) })
                    .ToArray())
                .ToArray();
            _boards.Add(new BingoBoard { Numbers = board });
        }
    }

    protected override void SolveA()
    {
        var (number, board) = GetWinnerBoard();
        var unmarkedSum = board.Numbers
            .SelectMany(x => x)
            .Where(x => !x.IsDrawn)
            .Sum(x => x.Value);

        Console.Write(unmarkedSum * number);
    }

    protected override void SolveB()
    {
        var (number, board) = GetLastBoard();
        var unmarkedSum = board.Numbers
              .SelectMany(x => x)
              .Where(x => !x.IsDrawn)
              .Sum(x => x.Value);

        Console.Write(unmarkedSum * number);
    }

    private (int number, BingoBoard board) GetLastBoard()
    {
        var winnerBoards = new HashSet<BingoBoard>();

        foreach (var number in _numbers)
        {
            foreach (var board in _boards.Where(board => BoardWins(board, number)))
            {
                winnerBoards.Add(board);

                if (winnerBoards.Count == _boards.Count)
                {
                    return (number, board);
                }
            }
        }

        return default;
    }

    private (int number, BingoBoard board) GetWinnerBoard()
    {
        foreach (var number in _numbers)
        {
            foreach (var board in _boards)
            {
                if (BoardWins(board, number))
                {
                    return (number, board);
                }
            }
        }

        return default;
    }

    private static bool BoardWins(BingoBoard board, int number)
    {
        foreach (var row in board.Numbers)
        {
            foreach (var (i, boardNumber) in row.Select((item, index) => (index, item)))
            {
                if (boardNumber.Value == number)
                {
                    boardNumber.IsDrawn = true;
                }

                var colWins = board.Numbers.Select(x => x[i]).All(x => x.IsDrawn);
                if (colWins)
                {
                    return true;
                }
            }

            var rowWins = row.All(x => x.IsDrawn);
            if (rowWins)
            {
                return true;
            }
        }

        return false;
    }
}
