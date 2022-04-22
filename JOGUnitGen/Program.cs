using JOGUnitGen;
using JOGUnitGen.Generators;
using JOGUnitJson;
using Newtonsoft.Json;

try
{
    var file = Path.Combine(Directory.GetCurrentDirectory(), "data", "measurements.json");
    var json = File.ReadAllText(file);
    var data = JsonConvert.DeserializeObject<Data>(json, new JsonSerializerSettings
    {
        Converters = new List<JsonConverter> { new MeasurementConverter() }
    });
    if (data != null)
    {
        var unitGenerator = new UnitGenerator();
        var quantityGenerator = new QuantityGenerator();
        foreach (var measurement in data.Measurements)
        {
            Console.Write(unitGenerator.Generate(measurement));
            Console.WriteLine();
            Console.Write(quantityGenerator.Generate(measurement));
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

