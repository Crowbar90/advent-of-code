using AdventOfCode._2022.PuzzleSolvers;
using FluentAssertions;

namespace AdventOfCode._2022.Tests;

public class Day01SolverTests
{
    private readonly Day01Solver _sut = new();

    [Fact]
    public void Test_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day01.txt").Should().Be(24000);

    [Fact]
    public void Test_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day01.txt").Should().Be(45000);
}