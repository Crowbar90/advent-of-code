using AdventOfCode.Common.Services;

namespace AdventOfCode._2022.PuzzleSolvers;

public class Day01Solver() : FilePuzzleSolverBase<int>(Day)
{
    public const int Day = 1;

    public override int SolvePuzzle1(string inputFileName)
        => GetCaloriesTotals(GetInputLines(inputFileName))
            .Max();

    public override int SolvePuzzle2(string inputFileName)
        => GetCaloriesTotals(GetInputLines(inputFileName))
            .OrderByDescending(c => c)
            .Take(3)
            .Sum();

    private static IEnumerable<int> GetCaloriesTotals(
        IEnumerable<string> inputLines)
    {
        var acc = 0;
        foreach (var line in inputLines)
            switch (line)
            {
                case "":
                    yield return acc;
                    acc = 0;
                    break;
                default:
                    acc += int.Parse(line);
                    break;
            }

        yield return acc;
    }
}