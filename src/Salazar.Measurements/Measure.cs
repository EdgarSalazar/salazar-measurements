using System;

namespace Salazar.Measurements
{
    public class FactorFromDefaultAttribute : Attribute
    {
        public FactorFromDefaultAttribute(double factor)
        {
            Factor = factor;
        }

        public double Factor { get; set; }
    }

    public static class Extensions
    {
        public static double GetFactor(this Measurements measurement)
        {
            var type = typeof(Measurements);
            var memInfo = type.GetMember(measurement.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(FactorFromDefaultAttribute), false);
            var factor = ((FactorFromDefaultAttribute)attributes[0]).Factor;

            return factor;
        }
    }

    public enum Measurements
    {
        [FactorFromDefault(1000)]
        Milli,
        [FactorFromDefault(100)]
        Centi,
        [FactorFromDefault(10)]
        Deci,
        [FactorFromDefault(1)]
        Default,
        [FactorFromDefault(0.1)]
        Deca,
        [FactorFromDefault(0.01)]
        Hecto,
        [FactorFromDefault(0.001)]
        Kilo
    }

    public class Measure
    {
        public Measure(double measure, Measurements measurement = Measurements.Default)
        {
            Set(measure, measurement);
        }

        public double Milli
        {
            get
            {
                return Get(Measurements.Milli);
            }
            set
            {
                Set(value, Measurements.Milli);
            }
        }

        public double Centi
        {
            get
            {
                return Get(Measurements.Centi);
            }
            set
            {
                Set(value, Measurements.Centi);
            }
        }

        public double Deci
        {
            get
            {
                return Get(Measurements.Deci);
            }
            set
            {
                Set(value, Measurements.Deci);
            }
        }

        public double Default { get; set; }

        public double Deca
        {
            get
            {
                return Get(Measurements.Deca);
            }
            set
            {
                Set(value, Measurements.Deca);
            }
        }

        public double Hecto
        {
            get
            {
                return Get(Measurements.Hecto);
            }
            set
            {
                Set(value, Measurements.Hecto);
            }
        }

        public double Kilo
        {
            get
            {
                return Get(Measurements.Kilo);
            }
            set
            {
                Set(value, Measurements.Kilo);
            }
        }

        private double Get(Measurements measurement)
        {
            var factor = measurement.GetFactor();

            return Default * factor;
        }

        private void Set(double value, Measurements measurement)
        {
            var factor = measurement.GetFactor();

            Default = value / factor;
        }
    }
}