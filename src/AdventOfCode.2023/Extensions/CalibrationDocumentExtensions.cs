namespace AdventOfCode._2023.Extensions;

public static class CalibrationDocumentExtensions
{
    public static IEnumerable<int> GetCalibrationValuesStep1(
        this IEnumerable<string> lines)
        => lines
            .Select(l => l.GetCalibrationValue(false));

    public static IEnumerable<int> GetCalibrationValuesStep2(
        this IEnumerable<string> lines)
        => lines
            .Select(l => l.GetCalibrationValue(true));

    private static int GetCalibrationValue(this string line, bool includeTextMatches)
        => ConcatExtremes(
            line.GetForwardNumbers(includeTextMatches).First(),
            line.GetReverseNumbers(includeTextMatches).First());

    private static int ConcatExtremes(int first, int last)
        => first * 10 + last;
}