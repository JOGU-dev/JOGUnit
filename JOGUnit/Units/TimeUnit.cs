namespace JOGUnit;

public class TimeUnit : Unit
{
    public static readonly TimeUnit Milliseconds = new("millisecond", "milliseconds", "ms", 0.001);
    public static readonly TimeUnit Seconds = new("second", "seconds", "s", 1);
    public static readonly TimeUnit Minutes = new("minute", "minutes", "m", 60);
    public static readonly TimeUnit Hours = new("hour", "hours", "h", 3600);

    private TimeUnit(string singularName, string pluralName, string abbreviation, double conversion) : base(MeasurementType.Time, singularName, pluralName, abbreviation, conversion)
    {
    }
}