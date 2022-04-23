namespace JOGUnit;

public struct Time : IQuantity<TimeUnit>, IEquatable<Time>
{
    public static Time FromMilliseconds(double value) => new (value, TimeUnit.Milliseconds);
    public static Time FromSeconds(double value) => new (value, TimeUnit.Seconds);
    public static Time FromMinutes(double value) => new (value, TimeUnit.Minutes);
    public static Time FromHours(double value) => new (value, TimeUnit.Hours);

    public double Value { get; set; }
    public TimeUnit Unit { get; set; }
    
    #region Properties

    public double Milliseconds => GetValue(TimeUnit.Milliseconds);
    public double Seconds => GetValue(TimeUnit.Seconds);
    public double Minutes => GetValue(TimeUnit.Minutes);
    public double Hours => GetValue(TimeUnit.Hours);

    #endregion

    public Time(double value, TimeUnit unit)
    {
        Value = value;
        Unit = unit;
    }
    
    public double GetValue(TimeUnit unit) => Unit.Convert(Value, unit);
    
    #region Arithmetic operators
    
    public static Time operator +(Time a, Time b) => new(a.Value + b.GetValue(a.Unit), a.Unit);
    public static Time operator -(Time a, Time b) => new(a.Value - b.GetValue(a.Unit), a.Unit);
    public static Time operator *(Time a, Time b) => new(a.Value * b.GetValue(a.Unit), a.Unit);
    public static Time operator /(Time a, Time b) => new(a.Value / b.GetValue(a.Unit), a.Unit);
    public static Time operator ++(Time a) => new(a.Value + 1, a.Unit);
    public static Time operator --(Time a) => new(a.Value - 1, a.Unit);
    
    #endregion
    
    #region Equality operators
    
    public static bool operator ==(Time a, double b) => a.Value.Equals(b);
    public static bool operator !=(Time a, double b) => !a.Value.Equals(b);
    
    #endregion
    
    public bool Equals(Time other) => Value.Equals(other.GetValue(Unit));
    public override bool Equals(object? obj) => obj is Time other && Equals(other);
    
    public override string ToString()
    {
        return $"{Value} {(Math.Abs(Value - 1.0d) < double.Epsilon ? Unit.SingularName : Unit.PluralName)}";
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            return (Value.GetHashCode() * 397) ^ (Unit != null ? Unit.GetHashCode() : 0);
        }
    }
}