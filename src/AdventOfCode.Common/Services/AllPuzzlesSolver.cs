using AdventOfCode.Common.Models;

namespace AdventOfCode.Common.Services;

public interface IAllPuzzlesSolver
{
    IEnumerable<PuzzleSolution> SolveAll();
}

public class AllPuzzlesSolver(IPuzzleSolverResolver resolver) : IAllPuzzlesSolver
{
    public IEnumerable<PuzzleSolution> SolveAll()
        => Enumerable
            .Range(1, 25)
            .Select(day => (FileName: $"Inputs/day{day:00}.txt", Solver: resolver.GetSolverForDay(day)))
            .Select(x => x.Solver.Solve(x.FileName))
            .Where(ps => ps is not null)
            .Select(ps => ps!);
}