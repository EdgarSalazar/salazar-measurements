using Salazar.Measurements;
using Xunit;

namespace Tests
{
    public class ConvertTests
    {
        [Fact]
        public void ConvertFrom()
        {
            var oneThousand = new Measure(1000, Measurements.Default);

            Assert.Equal(1000000, oneThousand.Milli);
            Assert.Equal(100000, oneThousand.Centi);
            Assert.Equal(10000, oneThousand.Deci);
            Assert.Equal(1000, oneThousand.Default);
            Assert.Equal(100, oneThousand.Deca);
            Assert.Equal(10, oneThousand.Hecto);
            Assert.Equal(1, oneThousand.Kilo);
        }

        [Fact]
        public void ConvertFromLowKilo()
        {
            var oneKilo = new Measure(1, Measurements.Kilo);

            Assert.Equal(1000000, oneKilo.Milli);
            Assert.Equal(100000, oneKilo.Centi);
            Assert.Equal(10000, oneKilo.Deci);
            Assert.Equal(1000, oneKilo.Default);
            Assert.Equal(100, oneKilo.Deca);
            Assert.Equal(10, oneKilo.Hecto);
            Assert.Equal(1, oneKilo.Kilo);
        }

        [Fact]
        public void ConvertFromLowMili()
        {
            var oneMillionMili = new Measure(1000000, Measurements.Milli);

            Assert.Equal(1000000, oneMillionMili.Milli);
            Assert.Equal(100000, oneMillionMili.Centi);
            Assert.Equal(10000, oneMillionMili.Deci);
            Assert.Equal(1000, oneMillionMili.Default);
            Assert.Equal(100, oneMillionMili.Deca);
            Assert.Equal(10, oneMillionMili.Hecto);
            Assert.Equal(1, oneMillionMili.Kilo);
        }

        [Fact]
        public void ConvertFromHighKilo()
        {
            var oneKilo = new Measure(100, Measurements.Kilo);

            Assert.Equal(100000000, oneKilo.Milli);
            Assert.Equal(10000000, oneKilo.Centi);
            Assert.Equal(1000000, oneKilo.Deci);
            Assert.Equal(100000, oneKilo.Default);
            Assert.Equal(10000, oneKilo.Deca);
            Assert.Equal(1000, oneKilo.Hecto);
            Assert.Equal(100, oneKilo.Kilo);
        }

        [Fact]
        public void ConvertFromHighMili()
        {
            var oneMillionMili = new Measure(100000000, Measurements.Milli);

            Assert.Equal(100000000, oneMillionMili.Milli);
            Assert.Equal(10000000, oneMillionMili.Centi);
            Assert.Equal(1000000, oneMillionMili.Deci);
            Assert.Equal(100000, oneMillionMili.Default);
            Assert.Equal(10000, oneMillionMili.Deca);
            Assert.Equal(1000, oneMillionMili.Hecto);
            Assert.Equal(100, oneMillionMili.Kilo);
        }
    }
}