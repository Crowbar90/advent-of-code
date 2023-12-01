using AdventOfCode._2015.PuzzleSolvers;
using FluentAssertions;

namespace AdventOfCode._2015.Tests;

public class Day01SolverTests
{
    private readonly Day01Solver _sut = new();

    [Fact]
    public void Test_Sample_Puzzle1_1()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-1.txt").Should().Be(0);

    [Fact]
    public void Test_Sample_Puzzle1_2()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-2.txt").Should().Be(0);

    [Fact]
    public void Test_Sample_Puzzle1_3()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-3.txt").Should().Be(3);

    [Fact]
    public void Test_Sample_Puzzle1_4()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-4.txt").Should().Be(3);

    [Fact]
    public void Test_Sample_Puzzle1_5()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-5.txt").Should().Be(3);

    [Fact]
    public void Test_Sample_Puzzle1_6()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-6.txt").Should().Be(-1);

    [Fact]
    public void Test_Sample_Puzzle1_7()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-7.txt").Should().Be(-1);

    [Fact]
    public void Test_Sample_Puzzle1_8()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-8.txt").Should().Be(-3);

    [Fact]
    public void Test_Sample_Puzzle1_9()
        => _sut.SolvePuzzle1("Inputs/day01-sample-1-9.txt").Should().Be(-3);
    
    [Fact]
    public void Test_Input_Puzzle1()
        => _sut.SolvePuzzle1("Inputs/day01-input.txt").Should().Be(138);

    [Fact]
    public void Test_Sample_Puzzle2_1()
        => _sut.SolvePuzzle2("Inputs/day01-sample-2-1.txt").Should().Be(1);

    [Fact]
    public void Test_Sample_Puzzle2_2()
        => _sut.SolvePuzzle2("Inputs/day01-sample-2-2.txt").Should().Be(5);
    
    [Fact]
    public void Test_Input_Puzzle2()
        => _sut.SolvePuzzle1("Inputs/day01-input.txt").Should().Be(138);
}