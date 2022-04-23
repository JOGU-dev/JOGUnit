using NUnit.Framework;
using JOGUnit;

namespace JOGUnitTests;

[TestFixture]
public class TimeTests
{
    [Test]
    public void ConversionTest()
    {
        var duration = new Time(60, TimeUnit.Seconds);

        var seconds = duration.GetValue(TimeUnit.Seconds);
        Assert.AreEqual(60, seconds);

        var minutes = duration.GetValue(TimeUnit.Minutes);
        Assert.AreEqual(1d, minutes);

        var hours = duration.GetValue(TimeUnit.Hours);
        Assert.AreEqual(1d / 60, hours);
    }

    [Test]
    public void PlusOperatorTest()
    {
        var a = Time.FromSeconds(10);
        var b = Time.FromSeconds(40);
        var c = a + b;
        Assert.AreEqual(50, c.Seconds);
    }

    [Test]
    public void MinusOperatorTest()
    {
        var a = Time.FromMinutes(1);
        var b = Time.FromSeconds(30);
        var c = a - b;
        Assert.AreEqual(30, c.Seconds);
        Assert.AreEqual(0.5, c.Minutes);
    }

    [Test]
    public void ToStringTest()
    {
        var oneMinute = Time.FromMinutes(1);
        Assert.AreEqual("1 minute", oneMinute.ToString());
        Assert.AreEqual("2 minutes", Time.FromMinutes(2).ToString());
    }
}