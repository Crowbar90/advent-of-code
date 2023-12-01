using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Common.Services;

public interface IPuzzleSolverResolver
{
    public IPuzzleSolver GetSolverForDay(int day);
}

public class PuzzleSolverResolver(IServiceProvider serviceProvider)
    : IPuzzleSolverResolver
{
    public IPuzzleSolver GetSolverForDay(int day)
        => serviceProvider.GetKeyedService<IPuzzleSolver>(day)
           ?? serviceProvider.GetRequiredService<DummyPuzzleSolver>();
}