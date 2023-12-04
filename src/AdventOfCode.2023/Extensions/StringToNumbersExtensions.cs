namespace AdventOfCode._2023.Extensions;

public static class StringToNumbersExtensions
{
    public static IEnumerable<int> GetForwardNumbers(
        this IEnumerable<char> chars,
        bool includeTextMatches = false)
        => chars
            .GetNumbers(
                includeTextMatches,
                (acc, c) => $"{acc}{c}",
                (source, pattern) => source.EndsWith(pattern));

    public static IEnumerable<int> GetReverseNumbers(
        this IEnumerable<char> chars,
        bool includeTextMatches = false)
        => chars
            .Reverse()
            .GetNumbers(
                includeTextMatches,
                (acc, c) => $"{c}{acc}",
                (source, pattern) => source.StartsWith(pattern));

    private static IEnumerable<int> GetNumbers(
        this IEnumerable<char> chars,
        bool includeTextMatches,
        Func<string, char, string> accumulatorFn,
        Func<string, string, bool> matchingFn)
    {
        var acc = string.Empty;
        foreach (var c in chars)
        {
            acc = accumulatorFn(acc, c);
            switch (c)
            {
                case '0':
                    acc = string.Empty;
                    yield return 0;
                    break;
                case '1':
                case var _ when includeTextMatches && matchingFn(acc, "one"):
                    acc = string.Empty;
                    yield return 1;
                    break;
                case '2':
                case var _ when includeTextMatches && matchingFn(acc, "two"):
                    acc = string.Empty;
                    yield return 2;
                    break;
                case '3':
                case var _ when includeTextMatches && matchingFn(acc, "three"):
                    acc = string.Empty;
                    yield return 3;
                    break;
                case '4':
                case var _ when includeTextMatches && matchingFn(acc, "four"):
                    acc = string.Empty;
                    yield return 4;
                    break;
                case '5':
                case var _ when includeTextMatches && matchingFn(acc, "five"):
                    acc = string.Empty;
                    yield return 5;
                    break;
                case '6':
                case var _ when includeTextMatches && matchingFn(acc, "six"):
                    acc = string.Empty;
                    yield return 6;
                    break;
                case '7':
                case var _ when includeTextMatches && matchingFn(acc, "seven"):
                    acc = string.Empty;
                    yield return 7;
                    break;
                case '8':
                case var _ when includeTextMatches && matchingFn(acc, "eight"):
                    acc = string.Empty;
                    yield return 8;
                    break;
                case '9':
                case var _ when includeTextMatches && matchingFn(acc, "nine"):
                    acc = string.Empty;
                    yield return 9;
                    break;
                default:
                    continue;
            }
        }
    }
    
    public static IEnumerable<int> ParseNumberList(
        this string line)
        => line
            .Split(' ')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(t => int.Parse(t.Trim()));
}