namespace AdventOfCode._2023.Models;

public class Almanac
{
    public IEnumerable<AlmanacRange> Seeds { get; set; } = null!;
    public List<AlmanacEntry> SeedToSoil { get; set; } = new();
    public List<AlmanacEntry> SoilToFertilizer { get; set; } = new();
    public List<AlmanacEntry> FertilizerToWater { get; set; } = new();
    public List<AlmanacEntry> WaterToLight { get; set; } = new();
    public List<AlmanacEntry> LightToTemperature { get; set; } = new();
    public List<AlmanacEntry> TemperatureToHumidity { get; set; } = new();
    public List<AlmanacEntry> HumidityToLocation { get; set; } = new();
}