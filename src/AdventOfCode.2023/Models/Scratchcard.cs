namespace AdventOfCode._2023.Models;

public class Scratchcard
{
    public int Number { get; init; }
    public IEnumerable<int> WinningNumbers { get; init; }
    public IEnumerable<int> CardNumbers { get; init; }
    public int Count { get; set; }
}