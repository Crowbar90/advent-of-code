using AdventOfCode._2023.Extensions;

namespace AdventOfCode._2023.Models;

public class CamelCardsHand : IComparable
{
    public char[] Cards { get; init; }
    public int Bid { get; init; }

    public int CompareTo(object? obj)
    {
        if (obj is not CamelCardsHand hand2)
            throw new ArgumentException(null, nameof(obj));

        var compareType = this.CalculateType().CompareTo(hand2.CalculateType());
        if (compareType != 0)
            return compareType;

        foreach (var (f, s) in Cards.Zip(hand2.Cards))
        {
            var compareCard = f.GetCardRank().CompareTo(s.GetCardRank());
            if (compareCard != 0)
                return compareCard;
        }

        return 0;
    }
}