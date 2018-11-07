using System;

namespace Salazar.Measurements
{
    public class FactorFromDefaultAttribute : Attribute
    {
        public FactorFromDefaultAttribute(double factor)
        {
            Factor = (decimal)factor;
        }

        public decimal Factor { get; set; }
    }

    public static class Extensions
    {
        public static decimal GetFactor(this Measurements measurement)
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
        public Measure(decimal measure, Measurements measurement = Measurements.Default)
        {
            Set(measure, measurement);
        }

        /// <summary>
        /// 1/1000 of the Default value.
        /// </summary>
        public decimal Milli
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

        /// <summary>
        /// 1/100 of the Default value.
        /// </summary>
        public decimal Centi
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

        /// <summary>
        /// 1/10 of the Default value.
        /// </summary>
        public decimal Deci
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

        /// <summary>
        /// The Default value. In the real world, would be equivalent to Meter or Gram.
        /// </summary>
        public decimal Default { get; set; }

        /// <summary>
        /// 10 times of the Default value.
        /// </summary>
        public decimal Deca
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

        /// <summary>
        /// 100 times of the Default value.
        /// </summary>
        public decimal Hecto
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

        /// <summary>
        /// 1000 times of the Default value.
        /// </summary>
        public decimal Kilo
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

        private decimal Get(Measurements measurement)
        {
            var factor = measurement.GetFactor();

            return Default * factor;
        }

        private void Set(decimal value, Measurements measurement)
        {
            var factor = measurement.GetFactor();

            Default = value / factor;
        }

        /// <summary>
        /// Check if this Measure object is greater then a given Measure object.
        /// </summary>
        /// <param name="measure">The Measure to be compared with.</param>
        /// <returns></returns>
        public bool GreaterThan(Measure measure)
        {
            return Default > measure.Default;
        }

        /// <summary>
        /// Check if this Measure object is lower then a given Measure object.
        /// </summary>
        /// <param name="measure">The Measure to be compared with.</param>
        /// <returns></returns>
        public bool LowerThan(Measure measure)
        {
            return Default < measure.Default;
        }

        /// <summary>
        /// Sum this Measure with another Measure.
        /// </summary>
        /// <param name="measure">The measure to sum</param>
        /// <param name="newInstance">True: return new Measure with the given values. False: add the measure to this object.</param>
        /// <returns></returns>
        public Measure SumWith(Measure measure, bool newInstance = true)
        {
            if(newInstance)
            {
                return new Measure(Default + measure.Default, Measurements.Default);
            }
            else
            {
                Default += measure.Default;

                return this;
            }
        }

        /// <summary>
        /// Subtract this Measure with another Measure.
        /// </summary>
        /// <param name="measure">The measure to subtract</param>
        /// <param name="newInstance">True: return new Measure with the given values. False: add the measure to this object.</param>
        /// <returns></returns>
        public Measure SubtractWith(Measure measure, bool newInstance = true)
        {
            if (newInstance)
            {
                return new Measure(Default - measure.Default, Measurements.Default);
            }
            else
            {
                Default -= measure.Default;

                return this;
            }
        }
    }
}