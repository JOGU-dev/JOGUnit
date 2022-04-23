namespace JOGUnit;

public struct Mass : IQuantity<MassUnit>, IEquatable<Mass>
{
    public static Mass FromPicograms(double value) => new (value, MassUnit.Picograms);
    public static Mass FromNanograms(double value) => new (value, MassUnit.Nanograms);
    public static Mass FromMicrograms(double value) => new (value, MassUnit.Micrograms);
    public static Mass FromMilligrams(double value) => new (value, MassUnit.Milligrams);
    public static Mass FromGrams(double value) => new (value, MassUnit.Grams);
    public static Mass FromKilograms(double value) => new (value, MassUnit.Kilograms);
    public static Mass FromTonnes(double value) => new (value, MassUnit.Tonnes);
    public static Mass FromMegatonnes(double value) => new (value, MassUnit.Megatonnes);
    public static Mass FromPounds(double value) => new (value, MassUnit.Pounds);
    public static Mass FromOunces(double value) => new (value, MassUnit.Ounces);
    public static Mass FromStones(double value) => new (value, MassUnit.Stones);

    public double Value { get; set; }
    public MassUnit Unit { get; set; }
    
    #region Properties

    public double Picograms => GetValue(MassUnit.Picograms);
    public double Nanograms => GetValue(MassUnit.Nanograms);
    public double Micrograms => GetValue(MassUnit.Micrograms);
    public double Milligrams => GetValue(MassUnit.Milligrams);
    public double Grams => GetValue(MassUnit.Grams);
    public double Kilograms => GetValue(MassUnit.Kilograms);
    public double Tonnes => GetValue(MassUnit.Tonnes);
    public double Megatonnes => GetValue(MassUnit.Megatonnes);
    public double Pounds => GetValue(MassUnit.Pounds);
    public double Ounces => GetValue(MassUnit.Ounces);
    public double Stones => GetValue(MassUnit.Stones);

    #endregion

    public Mass(double value, MassUnit unit)
    {
        Value = value;
        Unit = unit;
    }
    
    public double GetValue(MassUnit unit) => Unit.Convert(Value, unit);
    
    #region Arithmetic operators
    
    public static Mass operator +(Mass a, Mass b) => new(a.Value + b.GetValue(a.Unit), a.Unit);
    public static Mass operator -(Mass a, Mass b) => new(a.Value - b.GetValue(a.Unit), a.Unit);
    public static Mass operator *(Mass a, Mass b) => new(a.Value * b.GetValue(a.Unit), a.Unit);
    public static Mass operator /(Mass a, Mass b) => new(a.Value / b.GetValue(a.Unit), a.Unit);
    public static Mass operator ++(Mass a) => new(a.Value + 1, a.Unit);
    public static Mass operator --(Mass a) => new(a.Value - 1, a.Unit);
    
    #endregion
    
    #region Equality operators
    
    public static bool operator ==(Mass a, double b) => a.Value.Equals(b);
    public static bool operator !=(Mass a, double b) => !a.Value.Equals(b);
    
    #endregion
    
    public bool Equals(Mass other) => Value.Equals(other.GetValue(Unit));
    public override bool Equals(object? obj) => obj is Mass other && Equals(other);
    
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