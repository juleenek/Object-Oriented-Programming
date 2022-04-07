using System;
using System.Globalization;

namespace PudelkoLib
{
    public enum UnitOfMeasure
    {
        meter,
        centimeter,
        millimeter
    }
    public sealed class Pudelko : IFormatable
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        public double A { get => Math.Round(a, 3); }
        public double B { get => Math.Round(b, 3); }
        public double C { get => Math.Round(c, 3); }
        public UnitOfMeasure Unit { get; }
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {    
            if (a == null) a = ConvertNum(10.0, UnitOfMeasure.centimeter, unit);
            if (b == null) b = ConvertNum(10.0, UnitOfMeasure.centimeter, unit);
            if (c == null) c = ConvertNum(10.0, UnitOfMeasure.centimeter, unit);

            if (a > 0 && b > 0 && c > 0)
            {
                if (ConvertNum((double)a, unit, UnitOfMeasure.meter) > 10.0 ||
                    ConvertNum((double)b, unit, UnitOfMeasure.meter) > 10.0 ||
                    ConvertNum((double)c, unit, UnitOfMeasure.meter) > 10.0)
                {
                    throw new ArgumentOutOfRangeException("Dimensions must be less than 10 meters!");
                }
                this.a = ConvertNum((double)a, unit, UnitOfMeasure.meter);
                this.b = ConvertNum((double)b, unit, UnitOfMeasure.meter);
                this.c = ConvertNum((double)c, unit, UnitOfMeasure.meter);
            } else
            {
                throw new ArgumentOutOfRangeException("Dimensions must be positive!");
            }
         
            Unit = unit;
        }
        private double ConvertNum(double dimension, UnitOfMeasure unit, UnitOfMeasure resultUnit)
        {
            switch (unit)
            {
                case UnitOfMeasure.meter:
                    if (resultUnit == UnitOfMeasure.centimeter) return (dimension * 100.0);
                    if (resultUnit == UnitOfMeasure.millimeter) return (dimension * 1000.0);
                    return dimension;
                case UnitOfMeasure.centimeter:
                    if (resultUnit == UnitOfMeasure.millimeter) return (dimension * 10.0);
                    if (resultUnit == UnitOfMeasure.meter) return (dimension / 100.0);
                    return dimension;
                case UnitOfMeasure.millimeter:
                    if (resultUnit == UnitOfMeasure.centimeter) return (dimension / 10.0);
                    if (resultUnit == UnitOfMeasure.meter) return (dimension / 1000.0);
                    return dimension;
                default: return dimension;
            }
        }
        public override string ToString()
        {
            return $"{string.Format("{0:0.000}", A)} m × " +
                   $"{string.Format("{0:0.000}", B)} m × " +
                   $"{string.Format("{0:0.000}", C)} m";
        }

    }
}
