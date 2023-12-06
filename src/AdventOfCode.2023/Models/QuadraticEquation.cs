namespace AdventOfCode._2023.Models;

public class QuadraticEquation
{
    public double A { get; init; }
    public double B { get; init; }
    public double C { get; init; }

    public double Discriminant => SafeEvaluate(() => Math.Pow(B, 2) - 4 * A * C);

    public IOrderedEnumerable<double> Roots
        => Discriminant switch
        {
            > 0 => new[]
                {
                    (-B + Math.Sqrt(Discriminant)) / (2 * A),
                    (-B - Math.Sqrt(Discriminant)) / (2 * A)
                }
                .OrderBy(r => r),
            0 => new[]
                {
                    -B / (2 * A),
                    -B / (2 * A)
                }
                .OrderBy(r => r),
            _ => throw new ArithmeticException("quadratic-equation-negative-discriminant")
        };

    private T SafeEvaluate<T>(Func<T> evaluation)
        => A == 0
            ? throw new ArithmeticException("quadratic-equation-negative-a")
            : evaluation();
}