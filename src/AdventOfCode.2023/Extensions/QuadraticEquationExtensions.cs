using AdventOfCode._2023.Models;

namespace AdventOfCode._2023.Extensions;

public static class QuadraticEquationExtensions
{
    public static IEnumerable<long> RoundedRootsForStrictlyPositive(
        this QuadraticEquation equation,
        long? lowerBound = null,
        long? upperBound = null)
    {
        var roots = equation.Roots.ToArray();
        switch (equation.A)
        {
            case < 0:
                yield return Convert.ToInt64(double.Floor(roots[0]) + 1).ApplyLowerBound(lowerBound);
                yield return Convert.ToInt64(double.Ceiling(roots[1]) - 1).ApplyUpperBound(upperBound);
                break;
            case > 0:
                yield return Convert.ToInt64(double.Ceiling(roots[0]) - 1).ApplyLowerBound(lowerBound);
                yield return Convert.ToInt64(double.Floor(roots[1]) + 1).ApplyUpperBound(upperBound);
                break;
        }
    }

    private static long ApplyLowerBound(
        this long value,
        long? lowerBound)
        => lowerBound.HasValue
            ? Math.Max(value, lowerBound.Value)
            : value;

    private static long ApplyUpperBound(
        this long value,
        long? upperBound)
        => upperBound.HasValue
            ? Math.Min(value, upperBound.Value)
            : value;
}