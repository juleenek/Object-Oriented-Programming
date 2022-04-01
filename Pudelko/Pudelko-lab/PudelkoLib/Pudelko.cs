using System;

namespace PudelkoLib
{
    public enum UnitOfMeasure
    {
        meter,
        centimeter,
        millimeter
    }
    public sealed class Pudelko
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        public double A { get => a; }
        public double B { get => b; }
        public double C { get => c; }
        public UnitOfMeasure Unit { get; }
        public Pudelko(double? a = 10.0, double? b = 10.0, double? c = 10.0, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if (ConvertNum((double)a, unit, UnitOfMeasure.meter) > 10.0 ||
                    ConvertNum((double)b, unit, UnitOfMeasure.meter) > 10.0 ||
                    ConvertNum((double)c, unit, UnitOfMeasure.meter) > 10.0)
                {
                    throw new ArgumentOutOfRangeException("Dimensions must be less than 10 meters!");
                }
                this.a = (double)a;
                this.b = (double)b;
                this.c = (double)c;
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
    }
}
