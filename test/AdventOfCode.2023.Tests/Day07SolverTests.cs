using AdventOfCode._2023.PuzzleSolvers;
using FluentAssertions;

namespace AdventOfCode._2023.Tests;

public class Day07SolverTests
{
    private readonly Day07Solver _sut = new();

    [Fact]
    public void Test_Sample_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day07-sample.txt").Should().Be(6440);

    [Fact]
    public void Test_Sample_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day07-sample.txt").Should().Be(5905);

    [Fact]
    public void Test_Input_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day07-puzzle.txt").Should().Be(250232501);

    [Fact]
    public void Test_Input_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day07-puzzle.txt").Should().Be(249138943);
}