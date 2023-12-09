namespace AdventOfCode._2023.Models;

public class NetworkMap
{
    public string Directions { get; set; }
    public Dictionary<string, NetworkMapNode> Nodes { get; set; }
}