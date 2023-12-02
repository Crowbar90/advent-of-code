using AdventOfCode._2023.Extensions;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2023.PuzzleSolvers;

public class Day02Solver() : FilePuzzleSolverBase(Day)
{
    public const int Day = 2;

    private readonly Dictionary<string, int> _puzzle1Cubes = new()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };

    public override int SolvePuzzle1(string inputFileName)
        => GetInputLines(inputFileName)
            .ToCubesGames()
            .Where(cg => cg.IsPossible(_puzzle1Cubes))
            .Sum(cg => cg.Id);

    public override int SolvePuzzle2(string inputFileName)
        => GetInputLines(inputFileName)
            .ToCubesGames()
            .Select(cg => cg.GetMinimumCubes())
            .Select(c => c.CalculatePower())
            .Sum();
}