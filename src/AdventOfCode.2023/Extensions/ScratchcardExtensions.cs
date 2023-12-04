using AdventOfCode._2023.Models;

namespace AdventOfCode._2023.Extensions;

public static class ScratchcardExtensions
{
    public static IReadOnlyDictionary<int, Scratchcard> CashAll(
        this IReadOnlyDictionary<int, Scratchcard> scratchcards)
    {
        foreach (var scratchcard in scratchcards.Values)
            scratchcard.Cash(scratchcards);

        return scratchcards;
    }

    private static void Cash(
        this Scratchcard scratchcard,
        IReadOnlyDictionary<int, Scratchcard> scratchcards)
    {
        var matchingNumbersCount = scratchcard.GetMatchingNumbers().Count();

        if (matchingNumbersCount == 0)
            return;

        for (var i = scratchcard.Number + 1; i <= scratchcard.Number + matchingNumbersCount; i++)
            if (scratchcards.ContainsKey(i))
                scratchcards[i].Count += scratchcards[scratchcard.Number].Count;
    }

    public static int GetPoints(
        this Scratchcard scratchcard) =>
        scratchcard.GetMatchingNumbers().Count() switch
        {
            0 => 0,
            1 => 1,
            var c and > 0 => Enumerable.Range(1, c - 1).Aggregate(1, (a, _) => a * 2),
            _ => throw new ArgumentOutOfRangeException()
        };

    private static IEnumerable<int> GetMatchingNumbers(
        this Scratchcard scratchcard)
        => scratchcard
            .CardNumbers
            .Where(cn => scratchcard.WinningNumbers.Contains(cn));

    public static Dictionary<int, Scratchcard> ToScratchcards(
        this IEnumerable<string> lines)
        => lines
            .Select(l => l.ToScratchcard())
            .ToDictionary(c => c.Number);

    private static Scratchcard ToScratchcard(
        this string line)
    {
        var splitCardParts = line.Split(':', '|');
        var cardNumber = int.Parse(splitCardParts[0].Split(' ').Last());
        var winningNumbers = splitCardParts[1].ParseNumberList();
        var cardNumbers = splitCardParts[2].ParseNumberList();
        return new Scratchcard
        {
            Number = cardNumber,
            WinningNumbers = winningNumbers,
            CardNumbers = cardNumbers,
            Count = 1
        };
    }
}