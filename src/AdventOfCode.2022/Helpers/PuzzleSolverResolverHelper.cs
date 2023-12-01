using AdventOfCode._2022.PuzzleSolvers;
using AdventOfCode.Common.Services;

namespace AdventOfCode._2022.Helpers;

public static class PuzzleSolverResolverHelper
{
    public static IPuzzleSolver GetSolverForDay(int day)
        => day switch
        {
            1 => new Day01Solver(),
            _ => throw new ArgumentException(null, nameof(day))
        };
}