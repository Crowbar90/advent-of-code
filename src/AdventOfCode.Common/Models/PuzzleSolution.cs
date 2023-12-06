namespace AdventOfCode.Common.Models;

public interface IPuzzleSolution;

public class PuzzleSolution<TResult> : IPuzzleSolution
{
    public int Day { get; init; }
    public TResult Puzzle1 { get; init; }
    public TResult Puzzle2 { get; init; }
}