using AdventOfCode.Common.Models;

namespace AdventOfCode.Common.Services;

public interface IPuzzleSolver
{
    IPuzzleSolution? Solve(string inputFileName);
}

public interface IPuzzleSolver<TResult> : IPuzzleSolver
{
    TResult SolvePuzzle1(string inputFileName);
    TResult SolvePuzzle2(string inputFileName);
}