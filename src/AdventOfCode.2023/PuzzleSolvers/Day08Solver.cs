using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day08Solver() : FilePuzzleSolverBase<long>(Day)
{
    public const int Day = 8;

    public override long SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .ToArray()
            .ToNetworkMap()
            .CountSteps();

    public override long SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .ToArray()
            .ToNetworkMap()
            .CountStepsMultiple();
}