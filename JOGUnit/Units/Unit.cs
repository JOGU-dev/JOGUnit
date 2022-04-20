namespace JOGUnit;

public abstract class Unit
{
    public MeasurementType Measurement { get; set; }
    public string SingularName { get; set; }
    public string PluralName { get; set; }
    public string Abbreviation { get; set; }
    public double Conversion { get; set; }

    protected Unit(MeasurementType measurement, string singularName, string pluralName, string abbreviation, double conversion)
    {
        Measurement = measurement;
        SingularName = singularName;
        PluralName = pluralName;
        Abbreviation = abbreviation;
        Conversion = conversion;
    }

    public double Convert(double doubleValue, Unit unit)
    {
        if (!CanConvert(unit))
            throw new ArgumentException($"Cannot convert unit of [{Measurement}] to [{unit.Measurement}].");

        return ConvertValue(doubleValue, unit);
    }
    
    private double ConvertValue(double doubleValue, Unit unit) => doubleValue * Conversion / unit.Conversion;
    
    private bool CanConvert(Unit unit) => Measurement == unit.Measurement;
}