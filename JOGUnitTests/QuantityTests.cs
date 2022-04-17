using NUnit.Framework;
using JOGUnit;

namespace JOGUnitTests
{
    [TestFixture]
    public class QuantityTests
    {
        [Test]
        public void TimeConversionTest()
        {
            var duration = new Quantity(60, Time.Seconds);
            
            var seconds = duration.GetValue(Time.Seconds);
            Assert.AreEqual(60, seconds);
            
            var minutes = duration.GetValue(Time.Minutes);
            Assert.AreEqual(1d, minutes);

            var hours = duration.GetValue(Time.Hours);
            Assert.AreEqual(1d / 60, hours);
        }
    }
}