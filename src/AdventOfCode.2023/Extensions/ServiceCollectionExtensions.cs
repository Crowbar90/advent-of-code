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
            .AddPuzzleSolver<Day03Solver>(Day03Solver.Day)
            .AddPuzzleSolver<Day04Solver>(Day04Solver.Day)
            .AddPuzzleSolver<Day05Solver>(Day05Solver.Day)
            .AddPuzzleSolver<Day06Solver>(Day06Solver.Day)
            .AddPuzzleSolver<Day07Solver>(Day07Solver.Day)
            .AddDefaultPuzzleSolvers()
            .AddResolver();
}