namespace JOGUnitGen;

public static class StringExtensions
{
    public static string ToUpperFirstCharacter(this string str)
    {
        var a = str.ToLower().ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

    public static string ToPascalCase(this string str)
    {
        return string.Join(string.Empty, str.Split(" ").Select(s => s.ToUpperFirstCharacter()));
    }
}