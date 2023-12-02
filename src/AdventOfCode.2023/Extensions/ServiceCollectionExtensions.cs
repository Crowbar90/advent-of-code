using AdventOfCode._2023.PuzzleSolvers;
using AdventOfCode.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode._2023.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPuzzleSolvers(
        this IServiceCollection services)
        => services
            .AddPuzzleSolver<Day01Solver>(Day01Solver.Day)
            .AddPuzzleSolver<Day02Solver>(Day02Solver.Day)
            .AddDefaultPuzzleSolvers()
            .AddResolver();
}