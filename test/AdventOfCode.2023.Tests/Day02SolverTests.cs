using AdventOfCode._2023.PuzzleSolvers;
using FluentAssertions;

namespace AdventOfCode._2023.Tests;

public class Day02SolverTests
{
    private readonly Day02Solver _sut = new();

    [Fact]
    public void Test_Sample_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day02-sample.txt").Should().Be(8);

    [Fact]
    public void Test_Sample_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day02-sample.txt").Should().Be(2286);

    [Fact]
    public void Test_Input_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day02-puzzle.txt").Should().Be(2545);

    [Fact]
    public void Test_Input_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day02-puzzle.txt").Should().Be(78111);
}