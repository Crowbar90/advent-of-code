using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day07Solver() : FilePuzzleSolverBase<int>(Day)
{
    public const int Day = 7;

    public override int SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .ToCamelCardsHands(false)
            .OrderByDescending(h => h)
            .Select((h, i) => h.CalculateWinning(i + 1))
            .Sum();

    public override int SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .ToCamelCardsHands(true)
            .OrderByDescending(h => h)
            .Select((h, i) => h.CalculateWinning(i + 1))
            .Sum();
}