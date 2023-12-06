using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day06Solver() : FilePuzzleSolverBase<long>(Day)
{
    public const int Day = 6;

    public override long SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .ToArray()
            .ToBoatRaces()
            .Select(br => br.CountNewRecords())
            .Aggregate(1L, (a, i) => a * i);

    public override long SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .ToArray()
            .ToBoatRace()
            .CountNewRecords();
}