namespace JOGUnit;

public class Time : Unit
{
    public static readonly Unit Seconds = new Time(TimeType.Seconds, "seconds");
    public static readonly Unit Minutes = new Time(TimeType.Minutes, "minutes");
    public static readonly Unit Hours = new Time(TimeType.Hours, "hours");

    private TimeType TimeType { get; }
        
    public Time(TimeType timeType, string representation) : base(UnitType.Time, representation)
    {
        TimeType = timeType;
    }
        
    protected override double ConvertValue(double doubleValue, Unit unit)
    {
        return TimeType switch
        {
            TimeType.Seconds => SecondsTo(doubleValue, (Time) unit),
            TimeType.Minutes => MinutesTo(doubleValue, (Time) unit),
            TimeType.Hours => HoursTo(doubleValue, (Time) unit),
            _ => doubleValue
        };
    }

    private double SecondsTo(double doubleValue, Time unit)
    {
        return unit.TimeType switch
        {
            TimeType.Seconds => doubleValue,
            TimeType.Minutes => doubleValue / 60,
            TimeType.Hours => doubleValue / 3600,
            _ => doubleValue
        };
    }
        
    private double MinutesTo(double doubleValue, Time unit)
    {
        return unit.TimeType switch
        {
            TimeType.Seconds => doubleValue * 60,
            TimeType.Minutes => doubleValue,
            TimeType.Hours => doubleValue / 60,
            _ => doubleValue
        };
    }

    private double HoursTo(double doubleValue, Time unit)
    {
        return unit.TimeType switch
        {
            TimeType.Seconds => doubleValue * 3600,
            TimeType.Minutes => doubleValue * 60,
            TimeType.Hours => doubleValue,
            _ => doubleValue
        };
    }
}