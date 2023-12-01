using AdventOfCode.Common.Models;
using ConsoleTables;

namespace AdventOfCode.Common.Extensions;

public static class PuzzleSolutionExtensions
{
    public static ConsoleTable ToConsoleTable(
        this IEnumerable<PuzzleSolution> puzzleSolutions)
        => ConsoleTable
            .From(puzzleSolutions)
            .Configure(o => o.NumberAlignment = Alignment.Right);
}