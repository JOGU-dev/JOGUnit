using JOGUnitGen;
using JOGUnitGen.Generators;
using JOGUnitJson;
using Newtonsoft.Json;

try
{
    var unitsDirectory = Path.Combine(GetRootDirectory(), "JOGUnit", "Units");
    var quantitiesDirectory = Path.Combine(GetRootDirectory(), "JOGUnit", "Quantities");

    if (!Directory.Exists(unitsDirectory))
        Directory.CreateDirectory(unitsDirectory);
    
    if (!Directory.Exists(quantitiesDirectory))
        Directory.CreateDirectory(quantitiesDirectory);

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
            var unitFileName = $"{measurement.Type}Unit.cs";
            File.WriteAllText(Path.Combine(unitsDirectory, unitFileName), unitGenerator.Generate(measurement));
            
            var quantityFileName = $"{measurement.Type}.cs";
            File.WriteAllText(Path.Combine(quantitiesDirectory, quantityFileName), quantityGenerator.Generate(measurement));
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

string GetRootDirectory()
{
    const string rootDirectoryName = "JOGUnit";
    var current = new DirectoryInfo(Directory.GetCurrentDirectory());
    while (!current.Name.Equals(rootDirectoryName))
    {
        if (current.Parent == null)
            break;
        
        current = current.Parent;
    }
    
    return current.FullName;
}

