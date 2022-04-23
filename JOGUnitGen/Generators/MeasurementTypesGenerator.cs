using System.Text;

namespace JOGUnitGen.Generators;

public class MeasurementTypesGenerator
{
    public string Generate(string[] measurements)
    {
        var builder = new StringBuilder();
        builder.AppendLine("namespace JOGUnit;");
        builder.AppendLine();
        builder.AppendLine("public enum MeasurementType");
        builder.AppendLine("{");
        foreach (var measurement in measurements)
            builder.AppendLine($"    {measurement.ToPascalCase()},");
        builder.AppendLine("}");
        return builder.ToString();
    }
    
}