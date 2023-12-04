using AdventOfCode._2023.PuzzleSolvers;
using FluentAssertions;

namespace AdventOfCode._2023.Tests;

public class Day04SolverTests
{
    private readonly Day04Solver _sut = new();

    [Fact]
    public void Test_Sample_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day04-sample.txt").Should().Be(13);

    [Fact]
    public void Test_Sample_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day04-sample.txt").Should().Be(30);

    [Fact]
    public void Test_Input_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day04-puzzle.txt").Should().Be(20855);

    [Fact]
    public void Test_Input_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day04-puzzle.txt").Should().Be(5489600);
}