using AdventOfCode._2015.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2015.PuzzleSolvers;

public class Day01Solver() : FilePuzzleSolverBase(Day)
{
    public const int Day = 1;

    public override int SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .First()
            .GetFloorNumber();

    public override int SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .First()
            .GetFirstBasementPosition();
}