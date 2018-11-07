using Salazar.Measurements;
using Xunit;

namespace Tests
{
    public class OperationsTests
    {
        [Fact]
        public void GreaterThen()
        {
            var lowerMeasure = new Measure(1000, Measurements.Default);
            var greaterMeasure = new Measure(1001, Measurements.Default);

            Assert.True(greaterMeasure.GreaterThan(lowerMeasure));
        }

        [Fact]
        public void LowerThen()
        {
            var lowerMeasure = new Measure(1000, Measurements.Default);
            var greaterMeasure = new Measure(1001, Measurements.Default);

            Assert.True(lowerMeasure.LowerThan(greaterMeasure));
        }

        [Fact]
        public void SumWith()
        {
            var measureA = new Measure(10, Measurements.Default);
            var measureB = new Measure(15, Measurements.Default);

            Assert.Equal(25, measureA.SumWith(measureB).Default);
        }

        [Fact]
        public void SubtractWith()
        {
            var measureA = new Measure(15, Measurements.Default);
            var measureB = new Measure(10, Measurements.Default);

            Assert.Equal(5, measureA.SubtractWith(measureB).Default);
        }
    }
}