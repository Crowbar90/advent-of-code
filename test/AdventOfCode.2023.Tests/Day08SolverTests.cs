using AdventOfCode._2023.PuzzleSolvers;
using FluentAssertions;

namespace AdventOfCode._2023.Tests;

public class Day08SolverTests
{
    private readonly Day08Solver _sut = new();

    [Fact]
    public void Test_Sample1_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day08-sample-1.txt").Should().Be(2);

    [Fact]
    public void Test_Sample2_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day08-sample-2.txt").Should().Be(6);

    [Fact]
    public void Test_Sample_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day08-sample-3.txt").Should().Be(6);

    [Fact]
    public void Test_Input_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day08-puzzle.txt").Should().Be(22199);

    [Fact]
    public void Test_Input_Puzzle2()
        => _sut.SolvePuzzle2("Inputs/day08-puzzle.txt").Should().Be(13334102464297);
}