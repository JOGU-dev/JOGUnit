namespace JOGUnitGen;

public static class StringExtensions
{
    public static string ToUpperFirstCharacter(this string str)
    {
        var a = str.ToLower().ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }
}