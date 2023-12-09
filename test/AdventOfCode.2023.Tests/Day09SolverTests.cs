using AdventOfCode._2023.PuzzleSolvers;
using FluentAssertions;

namespace AdventOfCode._2023.Tests;

public class Day09SolverTests
{
    private readonly Day09Solver _sut = new();

    [Fact]
    public void Test_Sample_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day09-sample.txt").Should().Be(114);

    [Fact]
    public void Test_Sample_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day09-sample.txt").Should().Be(2);

    [Fact]
    public void Test_Input_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day09-puzzle.txt").Should().Be(1969958987);

    [Fact]
    public void Test_Input_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day09-puzzle.txt").Should().Be(1068);
}