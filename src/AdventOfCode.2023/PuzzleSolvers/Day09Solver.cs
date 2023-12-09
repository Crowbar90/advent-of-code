using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day09Solver() : FilePuzzleSolverBase<long>(Day)
{
    public const int Day = 9;

    public override long SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .ToReadings()
            .Sum(r => r.GetAllDifferences().ExtrapolateNextElement());

    public override long SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .ToReadings()
            .Sum(r => r.GetAllDifferences().ExtrapolatePreviousElement());
}