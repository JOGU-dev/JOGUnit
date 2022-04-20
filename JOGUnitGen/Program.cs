using JOGUnit;
using Newtonsoft.Json;

try
{
    var file = Path.Combine(Directory.GetCurrentDirectory(), "data", "measurements.json");
    var json = File.ReadAllText(file);
    var measurements = JsonConvert.DeserializeObject<List<Measurement>>(json) ?? new List<Measurement>();
    foreach (var measurement in measurements )
    {
        Console.WriteLine(measurement.Type);
        foreach (var unit in measurement.Units)
        {
            Console.WriteLine($"\t {unit.SingularName}");
            Console.WriteLine($"\t {unit.PluralName}");
            Console.WriteLine($"\t {unit.Abbreviation}");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

