using AdventOfCode._2023.Helpers;
using AdventOfCode._2023.Models;

namespace AdventOfCode._2023.Extensions;

public static class NetworkMapExtensions
{
    public static long CountStepsMultiple(
        this NetworkMap networkMap)
        => networkMap
            .Nodes
            .Keys
            .Where(k => k.EndsWith('A'))
            .ToArray()
            .Select(networkMap.GetEndStep)
            .LeastCommonMultiple();

    private static long GetEndStep(
        this NetworkMap networkMap,
        string startingNode)
    {
        var currentNode = startingNode;
        var step = 0L;

        while (!currentNode.EndsWith('Z'))
            currentNode = networkMap
                .NavigateStep(currentNode, step++);

        return step;
    }

    public static long CountSteps(
        this NetworkMap networkMap)
    {
        var step = 0L;
        var currentNode = "AAA";

        while (currentNode != "ZZZ")
            currentNode = networkMap
                .NavigateStep(currentNode, step++);

        return step;
    }

    private static string NavigateStep(
        this NetworkMap networkMap,
        string currentNode,
        long step)
        => networkMap
            .Nodes[currentNode]
            .Next[networkMap.GetNextStep(step)];

    private static char GetNextStep(
        this NetworkMap networkMap,
        long step)
        => networkMap.Directions[Convert.ToInt32(step % networkMap.Directions.Length)];

    public static NetworkMap ToNetworkMap(
        this string[] lines)
        => new()
        {
            Directions = lines.First(),
            Nodes = lines
                .Skip(2)
                .Select(ToNetworkNode)
                .ToDictionary(n => n.Node)
        };

    private static NetworkMapNode ToNetworkNode(
        this string line)
    {
        var splitLine = line
            .Split(
                new[] { ' ', '(', ')', ',' },
                StringSplitOptions.RemoveEmptyEntries);

        return new NetworkMapNode
        {
            Node = splitLine[0],
            Next = new Dictionary<char, string>
            {
                { 'L', splitLine[2] },
                { 'R', splitLine[3] }
            }
        };
    }
}