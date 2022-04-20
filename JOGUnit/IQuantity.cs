namespace JOGUnit;

public interface IQuantity<TUnit> where TUnit : Unit
{
    public double Value { get; }
    public TUnit Unit { get; }
    
    double GetValue(TUnit unit);
}