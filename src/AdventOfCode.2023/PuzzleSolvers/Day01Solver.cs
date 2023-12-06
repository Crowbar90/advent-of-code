using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day01Solver() : FilePuzzleSolverBase<int>(Day)
{
    public const int Day = 1;

    public override int SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .GetCalibrationValuesStep1()
            .Sum();

    public override int SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .GetCalibrationValuesStep2()
            .Sum();
}