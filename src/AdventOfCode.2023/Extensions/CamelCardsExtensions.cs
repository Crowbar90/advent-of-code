using AdventOfCode._2023.Models;

namespace AdventOfCode._2023.Extensions;

public static class CamelCardsExtensions
{
    private static readonly Dictionary<char, int> CardRanks = new()
    {
        {'A', 0},
        {'K', 1},
        {'Q', 2},
        {'J', 3},
        {'T', 4},
        {'9', 5},
        {'8', 6},
        {'7', 7},
        {'6', 8},
        {'5', 9},
        {'4', 10},
        {'3', 11},
        {'2', 12},
        {'j', 13}
    };

    public static int GetCardRank(
        this char card)
        => CardRanks[card];

    public static int CalculateWinning(
        this CamelCardsHand hand,
        int rank)
        => hand.Bid * rank;

    public static CamelCardsHandType CalculateType(
        this CamelCardsHand hand)
    {
        var counts = hand
            .Cards
            .GroupBy(ch => ch)
            .ToDictionary(
                g => g.Key,
                g => g.Count());

        var jokersCount = counts
            .TryGetValue('j', out var c)
            ? c
            : 0;

        return counts
                .Where(kv => kv.Key != 'j')
                .Select(kv => kv.Value)
                .OrderByDescending(count => count)
                .ToArray() switch
            {
                [] => CamelCardsHandType.FiveOfAKind,
                var arr when arr[0] + jokersCount == 5 => CamelCardsHandType.FiveOfAKind,
                var arr when arr[0] + jokersCount == 4 => CamelCardsHandType.FourOfAKind,
                var arr when arr[0] + jokersCount == 3 && arr[1] == 2 => CamelCardsHandType.FullHouse,
                var arr when arr[0] + jokersCount == 3 => CamelCardsHandType.ThreeOfAKind,
                var arr when arr[0] + jokersCount == 2 && arr[1] == 2 => CamelCardsHandType.TwoPair,
                var arr when arr[0] + jokersCount == 2 => CamelCardsHandType.OnePair,
                _ => CamelCardsHandType.HighCard
            };
    }

    public static IEnumerable<CamelCardsHand> ToCamelCardsHands(
        this IEnumerable<string> lines,
        bool withJoker)
        => lines
            .Select(l => withJoker ? l.Replace('J', 'j') : l)
            .Select(ToCamelCardsHand);

    private static CamelCardsHand ToCamelCardsHand(
        this string line)
    {
        var splitLine = line
            .Split(' ')
            .ToArray();

        return new CamelCardsHand
        {
            Cards = splitLine[0].ToCharArray(),
            Bid = int.Parse(splitLine[1])
        };
    }
}