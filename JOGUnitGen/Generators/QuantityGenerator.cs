using System.Text;
using JOGUnit;

namespace JOGUnitGen.Generators;

public class QuantityGenerator
{
    private const string INDENT_STRING = "    ";

    public string Generate(Measurement measurement)
    {
        var indent = 0;
        var className = measurement.Type.ToString();
        var unitName = $"{className}Unit";
        return $@"namespace JOGUnit;

public struct {className} : IQuantity<{unitName}>, IEquatable<{className}>
{{
{GenerateStaticFunctions(++indent, className, unitName, measurement.Units)}
    public double Value {{ get; set; }}
    public {unitName} Unit {{ get; set; }}
    
{GenerateProperties(indent, unitName, measurement.Units)}
    public {className}(double value, {unitName} unit)
    {{
        Value = value;
        Unit = unit;
    }}
    
    public double GetValue({unitName} unit) => Unit.Convert(Value, unit);
    
    #region Arithmetic operators
    
    public static {className} operator +({className} a, {className} b) => new(a.Value + b.GetValue(a.Unit), a.Unit);
    public static {className} operator -({className} a, {className} b) => new(a.Value - b.GetValue(a.Unit), a.Unit);
    public static {className} operator *({className} a, {className} b) => new(a.Value * b.GetValue(a.Unit), a.Unit);
    public static {className} operator /({className} a, {className} b) => new(a.Value / b.GetValue(a.Unit), a.Unit);
    public static {className} operator ++({className} a) => new(a.Value + 1, a.Unit);
    public static {className} operator --({className} a) => new(a.Value - 1, a.Unit);
    
    #endregion
    
    #region Equality operators
    
    public static bool operator ==({className} a, double b) => a.Value.Equals(b);
    public static bool operator !=({className} a, double b) => !a.Value.Equals(b);
    
    #endregion
    
    public bool Equals({className} other) => Value.Equals(other.GetValue(Unit));
    public override bool Equals(object obj) => obj is {className} other && Equals(other);
    
    public override string ToString()
    {{
        return $""{{Value}} {{(Math.Abs(Value - 1.0d) < double.Epsilon ? Unit.SingularName : Unit.PluralName)}}"";
    }}
    
    public override int GetHashCode()
    {{
        unchecked
        {{
            return (Value.GetHashCode() * 397) ^ (Unit != null ? Unit.GetHashCode() : 0);
        }}
    }}
}}";
    }

    private string GenerateStaticFunctions(int indent, string className, string unitName, IEnumerable<Unit> units)
    {
        var builder = new StringBuilder();
        foreach (var unit in units)
        {
            var pluralName = unit.PluralName.ToUpperFirstCharacter();
            builder.AppendLine($"{GetIndent(indent)}public static {className} From{pluralName}(double value) => new (value, {unitName}.{pluralName});");
        }
        return builder.ToString();
    }

    private string GenerateProperties(int indent, string unitName, IEnumerable<Unit> units)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{GetIndent(indent)}#region Properties");
        builder.AppendLine();
        foreach (var unit in units)
        {
            var pluralName = unit.PluralName.ToUpperFirstCharacter();
            builder.AppendLine($"{GetIndent(indent)}public double {pluralName} => GetValue({unitName}.{pluralName});");
        }
        builder.AppendLine();
        builder.AppendLine($"{GetIndent(indent)}#endregion");
        return builder.ToString();
    }
    
    private string GetIndent(int indent) => string.Join(string.Empty, Enumerable.Repeat(INDENT_STRING, indent));
}