using AdventOfCode.Common.Models;
using ConsoleTables;

namespace AdventOfCode.Common.Extensions;

public static class PuzzleSolutionExtensions
{
    public static ConsoleTable ToConsoleTable(
        this IEnumerable<IPuzzleSolution> puzzleSolutions)
        => ConsoleTable
            .From(puzzleSolutions.Select(ToPuzzleSolutionAsStrings))
            .Configure(o => o.NumberAlignment = Alignment.Right);

    private static PuzzleSolution<string> ToPuzzleSolutionAsStrings(
        this IPuzzleSolution puzzleSolution)
        => puzzleSolution switch
        {
            PuzzleSolution<int> puzzleSolutionInt => new PuzzleSolution<string>
            {
                Day = puzzleSolutionInt.Day,
                Puzzle1 = puzzleSolutionInt.Puzzle1.ToString(),
                Puzzle2 = puzzleSolutionInt.Puzzle2.ToString()
            },
            PuzzleSolution<long> puzzleSolutionLong => new PuzzleSolution<string>
            {
                Day = puzzleSolutionLong.Day,
                Puzzle1 = puzzleSolutionLong.Puzzle1.ToString(),
                Puzzle2 = puzzleSolutionLong.Puzzle2.ToString()
            },
            _ => throw new ArgumentOutOfRangeException(nameof(puzzleSolution))
        };
}