using AdventOfCode.Common.Helpers;
using AdventOfCode.Common.Models;

namespace AdventOfCode.Common.Services;

public abstract class FilePuzzleSolverBase(int day) : IPuzzleSolver
{
    protected static IEnumerable<string> GetInputLines(string fileName)
        => PuzzleInputHelper.GetFromFile(fileName, CancellationToken.None);

    public abstract int SolvePuzzle1(string inputFileName);
    public abstract int SolvePuzzle2(string inputFileName);

    public PuzzleSolution? Solve(string inputFileName)
        => new()
        {
            Day = day,
            Puzzle1 = SolvePuzzle1(inputFileName),
            Puzzle2 = SolvePuzzle2(inputFileName)
        };
}