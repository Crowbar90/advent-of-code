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
        => boatRace.GetLastNewRecord() - boatRace.GetFirstNewRecord() + 1;

    private static long GetFirstNewRecord(
        this BoatRace boatRace)
    {
        for (var i = 0L; i <= boatRace.MaxTime; i++)
            if (boatRace.IsNewRecord(i))
                return i;

        throw new ApplicationException();
    }

    private static long GetLastNewRecord(
        this BoatRace boatRace)
    {
        for (var i = boatRace.MaxTime; i >= 0L; i--)
            if (boatRace.IsNewRecord(i))
                return i;

        throw new ApplicationException();
    }

    private static long CalculateDistance(
        this BoatRace boatRace,
        long buttonPressedTime)
        => buttonPressedTime * (boatRace.MaxTime - buttonPressedTime);

    private static bool IsNewRecord(
        this BoatRace boatRace,
        long buttonPressedTime)
        => boatRace.CalculateDistance(buttonPressedTime) > boatRace.RecordDistance;
}