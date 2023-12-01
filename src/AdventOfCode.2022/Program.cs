using AdventOfCode._2022.Extensions;
using AdventOfCode.Common.Extensions;
using Microsoft.Extensions.Hosting;
using AdventOfCode.Common.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);
builder
    .Services
    .AddPuzzleSolvers();

using var host = builder.Build();

host
    .Services
    .GetRequiredService<IAllPuzzlesSolver>()
    .SolveAll()
    .ToConsoleTable()
    .Write();