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
        var measurement = new Measurement();

        if (!obj.TryGetValue("type", out var typeToken) || !Enum.TryParse(typeToken.Value<string>(), true, out MeasurementType type))
            throw new JsonException("Could not find valid measurement type");

        measurement.Type = type;
        measurement.Units = new List<Unit>();

        if (obj.TryGetValue("units", out var unitsToken) && unitsToken is JArray unitsArray)
        {
            foreach (var unitToken in unitsArray)
            {
                measurement.Units.Add(new Unit(
                    measurement.Type, 
                    (string)unitToken["singularName"],
                    (string)unitToken["pluralName"],
                    (string)unitToken["abbreviation"],
                    (double)unitToken["conversion"]
                    ));
            }
        }

        measurement.BaseUnit = measurement.Units.FirstOrDefault(u => u.SingularName.Equals((string)obj["baseUnit"]));

        return measurement;
    }
}