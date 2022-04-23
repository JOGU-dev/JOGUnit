using System.Globalization;
using System.Text;
using JOGUnit;

namespace JOGUnitGen.Generators;

public class UnitGenerator
{
    private const string INDENT_STRING = "    ";
    
    public string Generate(Measurement measurement)
    {
        var measurementString = measurement.MeasurementType.ToPascalCase();
        var unitName = $"{measurementString}Unit";
        return $@"namespace JOGUnit;

public class {unitName} : Unit
{{
{GenerateStaticProperties(1, unitName, measurement.Units)}
    private {unitName}(string singularName, string pluralName, string abbreviation, double conversion) : base(MeasurementType.{measurementString}, singularName, pluralName, abbreviation, conversion)
    {{

    }}
}}";
    }
    
    private string GenerateStaticProperties(int indent, string unitName, IEnumerable<Unit> units)
    {
        var builder = new StringBuilder();
        foreach (var unit in units)
        {
            var pluralName = unit.PluralName.ToPascalCase();
            builder.AppendLine($"{GetIndent(indent)}public static readonly {unitName} {pluralName} = new(\"{unit.SingularName}\", \"{unit.PluralName}\", \"{unit.Abbreviation}\", {unit.Conversion.ToString(CultureInfo.InvariantCulture)});");
        }
        return builder.ToString();
    }
    
    private string GetIndent(int indent) => string.Join(string.Empty, Enumerable.Repeat(INDENT_STRING, indent));
}