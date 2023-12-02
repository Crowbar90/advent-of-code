namespace AdventOfCode._2023.Models;

public class CubesGame
{
    public int Id { get; init; }
    public IEnumerable<Dictionary<string, int>> Draws { get; init; }
}