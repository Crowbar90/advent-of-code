using System.Numerics;
using AdventOfCode._2023.Helpers;

namespace AdventOfCode._2023.Extensions;

public static class MathExtensions
{
    public static T LeastCommonMultiple<T>(this IEnumerable<T> values) where T : INumber<T>
        => values.Aggregate(MathHelpers.LeastCommonMultiple);
}