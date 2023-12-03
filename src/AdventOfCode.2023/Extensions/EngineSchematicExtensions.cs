using AdventOfCode._2023.Models;

namespace AdventOfCode._2023.Extensions;

public static class EngineSchematicExtensions
{
    private const char NoSymbol = '.';

    public static int CalculateGearRatio(
        this (EngineSchematicSymbol Gear, EngineSchematicPart Part1, EngineSchematicPart Part2) gear)
        => gear.Part1.Value * gear.Part2.Value;

    public static IEnumerable<(EngineSchematicSymbol Gear, EngineSchematicPart Part1, EngineSchematicPart Part2)> GetGears(
        this IEnumerable<EngineSchematicSymbol> symbols,
        IEnumerable<EngineSchematicPart> parts)
        => symbols
            .Select(s => (Symbol: s, Parts: s.GetAdjacentParts(parts).ToArray()))
            .Where(x => x.Parts.Length == 2)
            .Select(x => (x.Symbol, x.Parts[0], x.Parts[1]));

    private static IEnumerable<EngineSchematicPart> GetAdjacentParts(
        this EngineSchematicSymbol symbol,
        IEnumerable<EngineSchematicPart> parts)
        => parts
            .Where(p => p.IsAdjacentTo(symbol));

    public static bool IsAdjacentTo(
        this EngineSchematicPart part,
        EngineSchematicSymbol symbol)
        => symbol.Row.IsBetween(part.Row - 1, part.Row + 1)
           && symbol.Column.IsBetween(part.StartColumn - 1, part.EndColumn + 1);
    
    public static (IEnumerable<EngineSchematicPart> Parts, IEnumerable<EngineSchematicSymbol> Symbols) ToEngineSchematics(
        this IEnumerable<string> lines)
    {
        var schematics = lines
            .Select((l, i) => l.ToEngineSchematics(i))
            .ToList();

        var parts = schematics
            .SelectMany(s => s.Parts);

        var symbols = schematics
            .SelectMany(s => s.Symbols);

        return (parts, symbols);
    }

    private static (IEnumerable<EngineSchematicPart> Parts, IEnumerable<EngineSchematicSymbol> Symbols) ToEngineSchematics(
        this string line,
        int row)
    {
        var parts = new List<EngineSchematicPart>();
        var symbols = new List<EngineSchematicSymbol>();

        ResetPartBuffer(out var partBuffer, out var partBufferStartColumn);
        
        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];

            if (char.IsDigit(c))
            {
                partBuffer = $"{partBuffer}{c}";
                if (partBufferStartColumn == -1)
                    partBufferStartColumn = i;
                if (i == line.Length -1)
                    parts.AddPart(partBuffer, row, partBufferStartColumn, i - 1);
            }
            else if (!string.IsNullOrEmpty(partBuffer))
            {
                parts.AddPart(partBuffer, row, partBufferStartColumn, i - 1);
                ResetPartBuffer(out partBuffer, out partBufferStartColumn);
            }

            if (!char.IsDigit(c) && c != NoSymbol)
                symbols.AddSymbol(c, row, i);
        }

        return (parts, symbols);
    }

    private static void AddPart(
        this ICollection<EngineSchematicPart> parts,
        string partBuffer,
        int row,
        int startColumn,
        int endColumn)
        => parts.Add(new EngineSchematicPart
        {
            Value = int.Parse(partBuffer),
            Row = row,
            StartColumn = startColumn,
            EndColumn = endColumn
        });

    private static void AddSymbol(
        this ICollection<EngineSchematicSymbol> symbols,
        char symbol,
        int row,
        int column)
        => symbols.Add(new EngineSchematicSymbol
        {
            Symbol = symbol,
            Row = row,
            Column = column
        });

    private static void ResetPartBuffer(
        out string partBuffer,
        out int partBufferStartColumn)
    {
        partBuffer = string.Empty;
        partBufferStartColumn = -1;
    }
}