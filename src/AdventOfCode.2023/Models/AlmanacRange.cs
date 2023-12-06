namespace AdventOfCode._2023.Models;

public class AlmanacRange(long start, long length)
{
    public long Start { get; init; } = start;
    public long Length { get; init; } = length;
    public long End => Start + Length - 1;
}