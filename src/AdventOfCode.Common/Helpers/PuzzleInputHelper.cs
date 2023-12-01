namespace AdventOfCode.Common.Helpers;

public static class PuzzleInputHelper
{
    public static string[] GetFromFile(
        string fileName,
        CancellationToken cancellationToken)
        => File
            .ReadLinesAsync(fileName, cancellationToken)
            .ToBlockingEnumerable(cancellationToken)
            .ToArray();
}