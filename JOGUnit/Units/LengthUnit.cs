namespace JOGUnit;

public class LengthUnit : Unit
{
    public static readonly LengthUnit Nanometers = new("nanometer", "nanometers", "nm", 1000000000);
    public static readonly LengthUnit Micrometers = new("micrometer", "micrometers", "μm", 1000000);
    public static readonly LengthUnit Millimeters = new("millimeter", "millimeters", "mm", 0.001);
    public static readonly LengthUnit Centimeters = new("centimeter", "centimeters", "cm", 0.01);
    public static readonly LengthUnit Meters = new("meter", "meters", "m", 1);
    public static readonly LengthUnit Kilometers = new("kilometer", "kilometers", "km", 1000);
    public static readonly LengthUnit Inches = new("inch", "inches", "\'", 0.0254);
    public static readonly LengthUnit Feet = new("foot", "feet", "ft", 0.3048);
    public static readonly LengthUnit Yards = new("yard", "yards", "yd", 0.9144);
    public static readonly LengthUnit Miles = new("mile", "miles", "mi", 1609.344);
    public static readonly LengthUnit NauticalMiles = new("nautical mile", "nautical miles", "nmi", 1852);

    private LengthUnit(string singularName, string pluralName, string abbreviation, double conversion) : base(MeasurementType.Length, singularName, pluralName, abbreviation, conversion)
    {

    }
}