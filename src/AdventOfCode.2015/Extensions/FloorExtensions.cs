namespace AdventOfCode._2015.Extensions;

public static class FloorExtensions
{
    private const char GoUp = '(';
    private const char GoDown = ')';

    public static int GetFloorNumber(
        this string line)
        => line.Count(c => c == GoUp)
           - line.Count(c => c == GoDown);

    public static int GetFirstBasementPosition(
        this string line)
    {
        var floor = 0;
        var i = 0;
        foreach (var c in line)
        {
            i++;
            switch (c)
            {
                case GoUp:
                    floor++;
                    break;
                case GoDown:
                    floor--;
                    break;
                default:
                    continue;
            }

            if (floor == -1)
                return i;
        }

        return -1;
    }
}