namespace AdventOfCode._2023.Models;

public class AlmanacEntry
{
    public long DestinationRangeStart { get; init; }
    public long SourceRangeStart { get; init; }
    public int RangeLength { get; init; }
    public long SourceRangeEnd => SourceRangeStart + RangeLength - 1;
}