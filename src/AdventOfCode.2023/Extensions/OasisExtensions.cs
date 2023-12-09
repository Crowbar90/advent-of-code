namespace AdventOfCode._2023.Extensions;

public static class OasisExtensions
{
    public static IEnumerable<long[]> ToReadings(
        this IEnumerable<string> lines)
        => lines
            .Select(ToHistory);

    private static long[] ToHistory(
        this string line)
        => line
            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

    private static IEnumerable<long> GetDifferences(
        this IReadOnlyList<long> historyLine)
    {
        for (var i = 0; i < historyLine.Count - 1; i++)
        {
            yield return historyLine[i + 1] - historyLine[i];
        }
    }

    public static IEnumerable<IEnumerable<long>> GetAllDifferences(
        this long[] historyLine)
    {
        while (true)
        {
            yield return historyLine;

            if (historyLine.All(x => x == 0))
                yield break;

            historyLine = historyLine
                .GetDifferences()
                .ToArray();
        }
    }

    public static long ExtrapolateNextElement(
        this IEnumerable<IEnumerable<long>> history)
        => history
            .Sum(h => h.Last());

    public static long ExtrapolatePreviousElement(
        this IEnumerable<IEnumerable<long>> history)
        => history
            .Select((h, i) => (i % 2 == 0 ? 1L : -1L) * h.First())
            .Sum();
}