using AdventOfCode._2023.Models;

namespace AdventOfCode._2023.Extensions;

public static class BoatRaceExtensions
{
    public static IEnumerable<BoatRace> ToBoatRaces(
        this string[] lines)
        => lines[0]
            .Split(' ')
            .Skip(1)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(int.Parse)
            .Zip(
                lines[1]
                    .Split(' ')
                    .Skip(1)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(int.Parse),
                (t, d) => new BoatRace
                {
                    MaxTime = t,
                    RecordDistance = d
                });

    public static BoatRace ToBoatRace(
        this string[] lines)
        => new()
        {
            MaxTime = long.Parse(lines[0].Split(':')[1].Replace(" ", string.Empty)),
            RecordDistance = long.Parse(lines[1].Split(':')[1].Replace(" ", string.Empty))
        };

    public static long CountNewRecords(
        this BoatRace boatRace)
    {
        var roundedRoots = boatRace
            .ToQuadraticEquation()
            .RoundedRootsForStrictlyPositive(0, boatRace.MaxTime)
            .ToArray();
        return roundedRoots[1] - roundedRoots[0] + 1;
    }

    private static QuadraticEquation ToQuadraticEquation(
        this BoatRace boatRace)
        => new()
        {
            A = -1,
            B = boatRace.MaxTime,
            C = -boatRace.RecordDistance
        };

}