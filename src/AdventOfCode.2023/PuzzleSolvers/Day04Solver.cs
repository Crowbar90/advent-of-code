using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day04Solver() : FilePuzzleSolverBase(Day)
{
    public const int Day = 4;

    public override int SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .ToScratchcards()
            .Values
            .Sum(c => c.GetPoints());

    public override int SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .ToScratchcards()
            .CashAll()
            .Values
            .Sum(c => c.Count);
}