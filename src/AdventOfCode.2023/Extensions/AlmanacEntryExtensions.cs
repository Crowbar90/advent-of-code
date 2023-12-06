using AdventOfCode._2023.Models;

namespace AdventOfCode._2023.Extensions;

public static class AlmanacEntryExtensions
{
    public static IEnumerable<AlmanacRange> TransformRanges(
        this Almanac almanac)
        => almanac
            .Seeds
            .SplitRanges(almanac.SeedToSoil)
            .SplitRanges(almanac.SoilToFertilizer)
            .SplitRanges(almanac.FertilizerToWater)
            .SplitRanges(almanac.WaterToLight)
            .SplitRanges(almanac.LightToTemperature)
            .SplitRanges(almanac.TemperatureToHumidity)
            .SplitRanges(almanac.HumidityToLocation);

    private static IEnumerable<AlmanacRange> SplitRanges(
        this IEnumerable<AlmanacRange> ranges,
        List<AlmanacEntry> map)
        => ranges
            .SelectMany(range => range.SplitRange(map));

    private static IEnumerable<AlmanacRange> SplitRange(
        this AlmanacRange range,
        List<AlmanacEntry> map)
    {
        foreach (var entry in map)
            switch (range)
            {
                case var _ when range.End < entry.SourceRangeStart:
                    yield return range;
                    yield break;
                case var _ when range.Start.IsBetween(entry.SourceRangeStart, entry.SourceRangeEnd) && range.End.IsBetween(entry.SourceRangeStart, entry.SourceRangeEnd):
                    yield return new AlmanacRange(range.Start - entry.SourceRangeStart + entry.DestinationRangeStart, range.Length);
                    yield break;
                case var _ when range.Start < entry.SourceRangeStart && range.End.IsBetween(entry.SourceRangeStart, entry.SourceRangeEnd):
                    yield return new AlmanacRange(range.Start, entry.SourceRangeStart - range.Start);
                    yield return new AlmanacRange(entry.DestinationRangeStart, range.End - entry.SourceRangeStart + 1);
                    yield break;
                case var _ when range.Start.IsBetween(entry.SourceRangeStart, entry.SourceRangeEnd) && range.End > entry.SourceRangeEnd:
                    yield return new AlmanacRange(range.Start - entry.SourceRangeStart + entry.DestinationRangeStart, entry.SourceRangeEnd - range.Start + 1);
                    foreach (var newRange in new AlmanacRange(entry.SourceRangeEnd + 1, range.End - entry.SourceRangeEnd).SplitRange(map))
                        yield return newRange;
                    yield break;
                case var _ when range.Start < entry.SourceRangeStart && range.End > entry.SourceRangeEnd:
                    yield return new AlmanacRange(range.Start, entry.SourceRangeStart - range.Start);
                    yield return new AlmanacRange(entry.DestinationRangeStart, entry.RangeLength);
                    foreach (var newRange in new AlmanacRange(entry.SourceRangeEnd + 1, range.End - entry.SourceRangeEnd).SplitRange(map))
                        yield return newRange;
                    yield break;
            }

        yield return range;
    }

    public static Almanac ToAlmanac(
        this IEnumerable<string> lines,
        bool seedsAsRanges)
    {
        var almanac = new Almanac();
        ICollection<AlmanacEntry> targetMap = null!;
        foreach (var line in lines)
        {
            switch (line)
            {
                case var _ when line.StartsWith("seeds:") && !seedsAsRanges:
                    almanac.Seeds = line
                        .Split(' ')
                        .Skip(1)
                        .Select(long.Parse)
                        .Select(n => new AlmanacRange(n, 1));
                    break;
                case var _ when line.StartsWith("seeds:") && seedsAsRanges:
                    almanac.Seeds = line
                        .Split(' ')
                        .Skip(1)
                        .Select(long.Parse)
                        .Chunk(2)
                        .Select(chunk => new AlmanacRange(chunk[0], chunk[1]));
                    break;
                case "":
                    continue;
                case "seed-to-soil map:":
                    targetMap = almanac.SeedToSoil;
                    break;
                case "soil-to-fertilizer map:":
                    targetMap = almanac.SoilToFertilizer;
                    break;
                case "fertilizer-to-water map:":
                    targetMap = almanac.FertilizerToWater;
                    break;
                case "water-to-light map:":
                    targetMap = almanac.WaterToLight;
                    break;
                case "light-to-temperature map:":
                    targetMap = almanac.LightToTemperature;
                    break;
                case "temperature-to-humidity map:":
                    targetMap = almanac.TemperatureToHumidity;
                    break;
                case "humidity-to-location map:":
                    targetMap = almanac.HumidityToLocation;
                    break;
                default:
                    var components = line
                        .Split(' ')
                        .ToArray();
                    targetMap.Add(new AlmanacEntry
                    {
                        DestinationRangeStart = long.Parse(components[0]),
                        SourceRangeStart = long.Parse(components[1]),
                        RangeLength = int.Parse(components[2])
                    });
                    break;
            }
        }

        almanac.SeedToSoil = almanac.SeedToSoil.OrderBy(e => e.SourceRangeStart).ToList();
        almanac.SoilToFertilizer = almanac.SoilToFertilizer.OrderBy(e => e.SourceRangeStart).ToList();
        almanac.FertilizerToWater = almanac.FertilizerToWater.OrderBy(e => e.SourceRangeStart).ToList();
        almanac.WaterToLight = almanac.WaterToLight.OrderBy(e => e.SourceRangeStart).ToList();
        almanac.LightToTemperature = almanac.LightToTemperature.OrderBy(e => e.SourceRangeStart).ToList();
        almanac.TemperatureToHumidity = almanac.TemperatureToHumidity.OrderBy(e => e.SourceRangeStart).ToList();
        almanac.HumidityToLocation = almanac.HumidityToLocation.OrderBy(e => e.SourceRangeStart).ToList();

        return almanac;
    }
}