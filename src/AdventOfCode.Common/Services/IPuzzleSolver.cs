using AdventOfCode.Common.Models;

namespace AdventOfCode.Common.Services;

public interface IPuzzleSolver
{
    int SolvePuzzle1(string inputFileName);
    int SolvePuzzle2(string inputFileName);
    PuzzleSolution? Solve(string inputFileName);
}