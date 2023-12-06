using AdventOfCode._2023.PuzzleSolvers;
using FluentAssertions;

namespace AdventOfCode._2023.Tests;

public class Day06SolverTests
{
    private readonly Day06Solver _sut = new();

    [Fact]
    public void Test_Sample_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day06-sample.txt").Should().Be(288);

    [Fact]
    public void Test_Sample_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day06-sample.txt").Should().Be(71503);

    [Fact]
    public void Test_Input_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day06-puzzle.txt").Should().Be(74698);

    [Fact]
    public void Test_Input_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day06-puzzle.txt").Should().Be(27563421);
}