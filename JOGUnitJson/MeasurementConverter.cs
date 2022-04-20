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
        return measurement;
    }
}