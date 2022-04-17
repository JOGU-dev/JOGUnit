namespace JOGUnit; 

public struct Quantity
{
    public double Value { get; }
    public Unit Unit { get; }

    public Quantity(double value, Unit unit)
    {
        Value = value;
        Unit = unit;
    }

    public double GetValue(Unit unit) => Unit.Convert(Value, unit);

    public override string ToString() => $"{Value} {Unit}";
}