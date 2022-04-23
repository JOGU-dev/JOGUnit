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
        
        measurement.MeasurementType = (string)obj["type"];
        measurement.Units = new List<Unit>();

        if (obj.TryGetValue("units", out var unitsToken) && unitsToken is JArray unitsArray)
        {
            foreach (var unitToken in unitsArray)
            {
                measurement.Units.Add(new Unit(
                    default,
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