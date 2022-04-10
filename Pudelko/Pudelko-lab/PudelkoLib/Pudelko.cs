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
    public sealed class Pudelko : IFormatable, IEquatable<Pudelko>
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        public double A { get => Math.Round(a, 3); }
        public double B { get => Math.Round(b, 3); }
        public double C { get => Math.Round(c, 3); }
        public UnitOfMeasure Unit { get; }
        public double Objetosc { get => Math.Round((a * b * c), 9); }
        public double Pole { get => Math.Round((2.0 * (a * b + a * c + b * c)), 6); }
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

        //////////////////////////////////////////////////// TOSTRING ////////////////////////////////////////////////////

        public override string ToString()
        {
            return $"{string.Format("{0:0.000}", A)} m × " +
                   $"{string.Format("{0:0.000}", B)} m × " +
                   $"{string.Format("{0:0.000}", C)} m";
        }
        public string ToString(string format, IFormatProvider provider = null)
        {
            double _A, _B, _C;

            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) _ = CultureInfo.CurrentCulture;
            // 2.500 m × 9.321 m × 0.100 m
            switch (format)
            {
                case "G":
                case "m":
                    return ToString();
                case "cm":
                    // 250.0 cm × 932.1 cm × 10.0 cm
                    _A = Math.Round(A * 100.0, 1);
                    _B = Math.Round(B * 100.0, 1);
                    _C = Math.Round(C * 100.0, 1);
                    return $"{string.Format("{0:0.0}", _A)} cm × " +
                           $"{string.Format("{0:0.0}", _B)} cm × " +
                           $"{string.Format("{0:0.0}", _C)} cm";
                case "mm":
                    // 2500 mm × 9321 mm × 100 mm
                    _A = Math.Round(A * 1000.0, 0);
                    _B = Math.Round(B * 1000.0, 0);
                    _C = Math.Round(C * 1000.0, 0);
                    return $"{string.Format("{0:0}", _A)} mm × " +
                           $"{string.Format("{0:0}", _B)} mm × " +
                           $"{string.Format("{0:0}", _C)} mm";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        //////////////////////////////////////////////////// EQUALS ////////////////////////////////////////////////////

        public override bool Equals(object value)
        {
            if (ReferenceEquals(null, value)) return false; // Is null?
            if (ReferenceEquals(this, value)) return true; // Is the same object?
            if (value.GetType() != GetType()) return false; // Is the same type?

            Pudelko pudelko = (Pudelko)value;
            return pudelko.Pole == Pole && pudelko.Objetosc == Objetosc;
        }
        public bool Equals(Pudelko pudelko)
        {
            return Equals((object)pudelko);
        }
        public override int GetHashCode()
        {
            return (A, B, C).GetHashCode();
        }
        //////////////////////////////////////////////////// OPERATORY ////////////////////////////////////////////////////
        public static bool operator ==(Pudelko lewePudelko, Pudelko prawePudelko)
        {
            if (lewePudelko is null && prawePudelko is null) return true;
            return lewePudelko.Equals(prawePudelko);
        }
        public static bool operator !=(Pudelko lewePudelko, Pudelko prawePudelko)
        {
            return !(lewePudelko == prawePudelko);
        }
        public static Pudelko operator +(Pudelko lewePudelko, Pudelko prawePudelko)
        {
            if(lewePudelko == null || prawePudelko == null) throw new Exception();
            double[] p1 = new double[3] { lewePudelko.A, lewePudelko.B, lewePudelko.C };
            double[] p2 = new double[3] { prawePudelko.A, prawePudelko.B, prawePudelko.C };
 
            Array.Sort(p1);
            Array.Sort(p2);

            double newA = p1[0] + p2[0];
            double newB = p1[1] + p2[1];
            double newC = p1[2] + p2[2];

            return new Pudelko(newA, newB, newC);
        }

        //////////////////////////////////////////////////// KONWERSJE ////////////////////////////////////////////////////

        public static explicit operator double[](Pudelko pudelko)
        {
            double[] edges = new double[3] { pudelko.A, pudelko.B, pudelko.C };
            return edges;
        }

        public static implicit operator Pudelko(ValueTuple<int, int, int> valueTuple)
        {
            //if (resultUnit == UnitOfMeasure.meter) return (dimension / 1000.0);
            Pudelko pudelko = new Pudelko(a: valueTuple.Item1, b: valueTuple.Item2, c: valueTuple.Item3, unit: UnitOfMeasure.millimeter);
            return pudelko;
        }
    }
}
