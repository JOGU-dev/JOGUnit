using JOGUnit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JOGUnitJson;

public class MeasurementConverter : JsonConverter<Measurement>
{
    public override void WriteJson(JsonWriter writer, Measurement? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override Measurement? ReadJson(JsonReader reader, Type objectType, Measurement? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var obj = JObject.Load(reader);

        var measurement = new Measurement
        {
            MeasurementType = obj["type"]?.Value<string>() ?? string.Empty,
            Units = new List<Unit>()
        };

        if (obj.TryGetValue("units", out var unitsToken) && unitsToken is JArray unitsArray)
        {
            foreach (var unitToken in unitsArray)
            {
                measurement.Units.Add(new Unit(
                    default,
                    unitToken["singularName"]?.Value<string>() ?? string.Empty,
                    unitToken["pluralName"]?.Value<string>() ?? string.Empty,
                    unitToken["abbreviation"]?.Value<string>() ?? string.Empty,
                    unitToken["conversion"]?.Value<double>() ?? 1
                    ));
            }
        }

        measurement.BaseUnit = measurement.Units.FirstOrDefault(u => u.SingularName.Equals(obj["baseUnit"]?.Value<string>() ?? string.Empty));

        return measurement;
    }
}