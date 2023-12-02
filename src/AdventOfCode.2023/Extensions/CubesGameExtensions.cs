using AdventOfCode._2023.Models;

namespace AdventOfCode._2023.Extensions;

public static class CubesGameExtensions
{
    public static bool IsPossible(
        this CubesGame game,
        Dictionary<string, int> cubes)
        => game
            .Draws
            .All(d => cubes
                .All(c =>
                    !d.TryGetValue(c.Key, out var drawn)
                    || drawn <= c.Value));

    public static Dictionary<string, int> GetMinimumCubes(
        this CubesGame game)
        => game
            .Draws
            .SelectMany(kv => kv)
            .GroupBy(kv => kv.Key)
            .Select(kvg => kvg.MaxBy(kv => kv.Value))
            .ToDictionary(kvg => kvg.Key, kvg => kvg.Value);

    public static int CalculatePower(
        this Dictionary<string, int> cubes)
        => cubes
            .Aggregate(1, (a, kv) => a * kv.Value);

    public static IEnumerable<CubesGame> ToCubesGames(
        this IEnumerable<string> inputLines)
        => inputLines
            .Select(ToCubesGame);

    private static CubesGame ToCubesGame(
        this string line)
    {
        var splitGameId = line.Split(':');
        var id = int.Parse(splitGameId[0].Split(' ')[1]);
        var drawsStrings = splitGameId[1].Split(';');
        var draws = drawsStrings.Select(ToDraw);
        return new CubesGame
        {
            Id = id,
            Draws = draws
        };
    }

    private static Dictionary<string, int> ToDraw(
        this string drawString)
        => drawString
            .Split(',')
            .Select(s => s.Trim())
            .Select(s => s.Split(' '))
            .ToDictionary(s => s[1], s => int.Parse(s[0]));
}