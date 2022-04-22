using System.Text;

namespace JOGUnitGen;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendLine(this StringBuilder builder, int indent, string value)
    {
        var indentString = string.Join(string.Empty, Enumerable.Repeat("     ", indent));
        return builder.AppendLine($"{indentString}{value}");
    }
}