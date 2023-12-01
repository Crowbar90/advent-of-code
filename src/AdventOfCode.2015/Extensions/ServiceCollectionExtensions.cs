using AdventOfCode._2015.PuzzleSolvers;
using AdventOfCode.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode._2015.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPuzzleSolvers(
        this IServiceCollection services)
        => services
            .AddPuzzleSolver<Day01Solver>(Day01Solver.Day)
            .AddDefaultPuzzleSolvers()
            .AddResolver();
}