namespace AdventOfCode._2023.Extensions;

public static class NumberComparisonExtensions
{
    public static bool IsBetween(
        this int number,
        int lower,
        int higher)
        => number >= lower
           && number <= higher;
}