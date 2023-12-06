using AdventOfCode.Common.Helpers;
using AdventOfCode.Common.Models;

namespace AdventOfCode.Common.Services;

public abstract class FilePuzzleSolverBase<TResult>(int day)
    : IPuzzleSolver<TResult>
{
    protected static IEnumerable<string> GetInputLines(string fileName)
        => PuzzleInputHelper.GetFromFile(fileName, CancellationToken.None);

    public abstract TResult SolvePuzzle1(string inputFileName);
    public abstract TResult SolvePuzzle2(string inputFileName);

    public IPuzzleSolution? Solve(string inputFileName)
        => new PuzzleSolution<TResult>
        {
            Day = day,
            Puzzle1 = SolvePuzzle1(inputFileName),
            Puzzle2 = SolvePuzzle2(inputFileName)
        };
}