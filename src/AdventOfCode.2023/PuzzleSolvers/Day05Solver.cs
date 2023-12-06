using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day05Solver() : FilePuzzleSolverBase<long>(Day)
{
    public const int Day = 5;

    public override long SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .ToAlmanac(false)
            .TransformRanges()
            .Min(r => r.Start);

    public override long SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .ToAlmanac(true)
            .TransformRanges()
            .Min(r => r.Start);
}