using System;
using JOGUnit;
using NUnit.Framework;

namespace JOGUnitTests;

[TestFixture]
public class LengthTests
{
    [Test]
    public void ConversionTest()
    {
        var meter = Length.FromCentimeters(100);
        Assert.AreEqual(1, meter.Meters);

        var nauticalMile = Length.FromNauticalMiles(1);
        Assert.AreEqual(1852, nauticalMile.Meters);

        var micrometers = Length.FromMicrometers(Length.FromMeters(1).Micrometers);
        Console.WriteLine(micrometers);
    }

    [Test]
    public void PlusOperatorTest()
    {
        
    }

    [Test]
    public void MinusOperatorTest()
    {
        
    }

    [Test]
    public void ToStringTest()
    {
        
    }
}