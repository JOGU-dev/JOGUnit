namespace JOGUnit;

public class Measurement
{
    public MeasurementType Type { get; set; }
    public Unit BaseUnit { get; set; }
    public List<Unit> Units { get; set; }
}