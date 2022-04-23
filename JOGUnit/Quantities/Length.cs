namespace JOGUnit;

public struct Length : IQuantity<LengthUnit>, IEquatable<Length>
{
    public static Length FromNanometers(double value) => new (value, LengthUnit.Nanometers);
    public static Length FromMicrometers(double value) => new (value, LengthUnit.Micrometers);
    public static Length FromMillimeters(double value) => new (value, LengthUnit.Millimeters);
    public static Length FromCentimeters(double value) => new (value, LengthUnit.Centimeters);
    public static Length FromMeters(double value) => new (value, LengthUnit.Meters);
    public static Length FromKilometers(double value) => new (value, LengthUnit.Kilometers);
    public static Length FromInches(double value) => new (value, LengthUnit.Inches);
    public static Length FromFeet(double value) => new (value, LengthUnit.Feet);
    public static Length FromYards(double value) => new (value, LengthUnit.Yards);
    public static Length FromMiles(double value) => new (value, LengthUnit.Miles);
    public static Length FromNauticalMiles(double value) => new (value, LengthUnit.NauticalMiles);

    public double Value { get; set; }
    public LengthUnit Unit { get; set; }
    
    #region Properties

    public double Nanometers => GetValue(LengthUnit.Nanometers);
    public double Micrometers => GetValue(LengthUnit.Micrometers);
    public double Millimeters => GetValue(LengthUnit.Millimeters);
    public double Centimeters => GetValue(LengthUnit.Centimeters);
    public double Meters => GetValue(LengthUnit.Meters);
    public double Kilometers => GetValue(LengthUnit.Kilometers);
    public double Inches => GetValue(LengthUnit.Inches);
    public double Feet => GetValue(LengthUnit.Feet);
    public double Yards => GetValue(LengthUnit.Yards);
    public double Miles => GetValue(LengthUnit.Miles);
    public double NauticalMiles => GetValue(LengthUnit.NauticalMiles);

    #endregion

    public Length(double value, LengthUnit unit)
    {
        Value = value;
        Unit = unit;
    }
    
    public double GetValue(LengthUnit unit) => Unit.Convert(Value, unit);
    
    #region Arithmetic operators
    
    public static Length operator +(Length a, Length b) => new(a.Value + b.GetValue(a.Unit), a.Unit);
    public static Length operator -(Length a, Length b) => new(a.Value - b.GetValue(a.Unit), a.Unit);
    public static Length operator *(Length a, Length b) => new(a.Value * b.GetValue(a.Unit), a.Unit);
    public static Length operator /(Length a, Length b) => new(a.Value / b.GetValue(a.Unit), a.Unit);
    public static Length operator ++(Length a) => new(a.Value + 1, a.Unit);
    public static Length operator --(Length a) => new(a.Value - 1, a.Unit);
    
    #endregion
    
    #region Equality operators
    
    public static bool operator ==(Length a, double b) => a.Value.Equals(b);
    public static bool operator !=(Length a, double b) => !a.Value.Equals(b);
    
    #endregion
    
    public bool Equals(Length other) => Value.Equals(other.GetValue(Unit));
    public override bool Equals(object? obj) => obj is Length other && Equals(other);
    
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