using AdventOfCode.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPuzzleSolver<TSolver>(
        this IServiceCollection services,
        int day)
        where TSolver : class, IPuzzleSolver
        => services.AddKeyedSingleton<IPuzzleSolver, TSolver>(day);

    public static IServiceCollection AddDefaultPuzzleSolvers(
        this IServiceCollection services)
        => services
            .AddSingleton<DummyPuzzleSolver>()
            .AddSingleton<IAllPuzzlesSolver, AllPuzzlesSolver>();

    public static IServiceCollection AddResolver(
        this IServiceCollection services)
        => services.AddSingleton<IPuzzleSolverResolver, PuzzleSolverResolver>();
}