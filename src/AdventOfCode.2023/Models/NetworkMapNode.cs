namespace AdventOfCode._2023.Models;

public class NetworkMapNode
{
    public string Node { get; init; }
    public Dictionary<char, string> Next { get; init; }
}