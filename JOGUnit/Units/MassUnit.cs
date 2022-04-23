namespace JOGUnit;

public class MassUnit : Unit
{
    public static readonly MassUnit Picograms = new("picogram", "picograms", "pg", 1000000000000000);
    public static readonly MassUnit Nanograms = new("nanogram", "nanograms", "ng", 1000000000000);
    public static readonly MassUnit Micrograms = new("microgram", "micrograms", "µg", 1000000000);
    public static readonly MassUnit Milligrams = new("milligram", "milligrams", "mg", 1000000);
    public static readonly MassUnit Grams = new("gram", "grams", "g", 0.001);
    public static readonly MassUnit Kilograms = new("kilogram", "kilograms", "kg", 1);
    public static readonly MassUnit Tonnes = new("tonne", "tonnes", "t", 1000);
    public static readonly MassUnit Megatonnes = new("megatonne", "megatonnes", "t", 1E-09);
    public static readonly MassUnit Pounds = new("pound", "pounds", "lb", 0.453592);
    public static readonly MassUnit Ounces = new("ounce", "ounces", "oz", 0.028349);
    public static readonly MassUnit Stones = new("stone", "stones", "st", 0.157473);

    private MassUnit(string singularName, string pluralName, string abbreviation, double conversion) : base(MeasurementType.Mass, singularName, pluralName, abbreviation, conversion)
    {

    }
}