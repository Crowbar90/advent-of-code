using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day03Solver() : FilePuzzleSolverBase(Day)
{
    public const int Day = 3;

    public override int SolvePuzzle1(string inputFileName)
    {
        var (parts, symbols) = GetInputLines(inputFileName)
            .ToEngineSchematics();

        return parts
            .Where(p => symbols.Any(p.IsAdjacentTo))
            .Sum(p => p.Value);
    }

    public override int SolvePuzzle2(string inputFileName)
    {
        var (parts, symbols) = GetInputLines(inputFileName)
            .ToEngineSchematics();

        return symbols
            .GetGears(parts)
            .Select(g => g.CalculateGearRatio())
            .Sum();
    }
}