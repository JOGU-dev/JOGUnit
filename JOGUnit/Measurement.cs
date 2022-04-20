using System.Collections.Generic;

namespace JOGUnit;

public class Measurement
{
    public static Measurement Time => new Measurement()
    {
        Type = MeasurementType.Time,
        BaseUnit = TimeUnit.Seconds,
        Units = new HashSet<Unit>()
        {
            TimeUnit.Milliseconds,
            TimeUnit.Seconds,
            TimeUnit.Minutes,
            TimeUnit.Hours
        }
    };
    
    public MeasurementType Type { get; set; }
    public Unit BaseUnit { get; set; }
    public HashSet<Unit> Units { get; set; }
}