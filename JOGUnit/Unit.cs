using System;

namespace JOGUnit;

public abstract class Unit
{
    public UnitType Type { get; }
    public string Representation { get; }

    protected Unit(UnitType type, string representation)
    {
        Type = type;
        Representation = representation;
    }

    public double Convert(double doubleValue, Unit unit)
    {
        if (!CanConvert(unit))
            throw new ArgumentException($"Cannot convert unit of [{Type}] to [{unit.Type}].");

        return ConvertValue(doubleValue, unit);
    }

    protected abstract double ConvertValue(double doubleValue, Unit unit);

    private bool CanConvert(Unit unit) => Type == unit.Type;
        
    public override string ToString() => Representation;
}