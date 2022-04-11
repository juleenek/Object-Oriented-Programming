using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PudelkoLib
{
    public enum UnitOfMeasure
    {
        meter,
        centimeter,
        millimeter
    }
    public sealed class Pudelko : IFormatable, IEquatable<Pudelko>, IEnumerable
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        private readonly double[] edges;
        public double A { get => Math.Round(a, 3); }
        public double B { get => Math.Round(b, 3); }
        public double C { get => Math.Round(c, 3); }
        public double[] Edges { get; }
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
                edges = new double[3] { (double)a, (double)b, (double)c };
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
            return $"{string.Format("{0:0.000}", A).Replace(",", ".")} m × " +
                   $"{string.Format("{0:0.000}", B).Replace(",", ".")} m × " +
                   $"{string.Format("{0:0.000}", C).Replace(",", ".")} m";
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
                    return $"{string.Format("{0:0.0}", _A).Replace(",", ".")} cm × " +
                           $"{string.Format("{0:0.0}", _B).Replace(",", ".")} cm × " +
                           $"{string.Format("{0:0.0}", _C).Replace(",", ".")} cm";
                case "mm":
                    // 2500 mm × 9321 mm × 100 mm
                    _A = Math.Round(A * 1000.0, 0);
                    _B = Math.Round(B * 1000.0, 0);
                    _C = Math.Round(C * 1000.0, 0);
                    return $"{string.Format("{0:0}", _A).Replace(",", ".")} mm × " +
                           $"{string.Format("{0:0}", _B).Replace(",", ".")} mm × " +
                           $"{string.Format("{0:0}", _C).Replace(",", ".")} mm";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
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
            if (lewePudelko == null || prawePudelko == null) throw new Exception();
            double[] p1 = new double[3] { lewePudelko.A, lewePudelko.B, lewePudelko.C };
            double[] p2 = new double[3] { prawePudelko.A, prawePudelko.B, prawePudelko.C };

            Array.Sort(p1);
            Array.Sort(p2);

            double newA = p1[0] + p2[0];
            double newB = p1[1] + p2[1];
            double newC = p1[2] + p2[2];

            return new Pudelko(newA, newB, newC);
        }
        public static explicit operator double[](Pudelko pudelko)
        {
            double[] edges = new double[3] { pudelko.A, pudelko.B, pudelko.C };
            return edges;
        }
        public static implicit operator Pudelko(ValueTuple<int, int, int> valueTuple)
        {
            Pudelko pudelko = new Pudelko(a: valueTuple.Item1, b: valueTuple.Item2, c: valueTuple.Item3, unit: UnitOfMeasure.millimeter);
            return pudelko;
        }
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return edges[0];
                    case 1:
                        return edges[1];
                    case 2:
                        return edges[2];
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var e in edges)
            {
                yield return e;
            }
        }
        // Do sprawdzenia, co jeśli są różne jednostki miary? 
        public static Pudelko Parse(string inputText)
        {
            string[] inputArr = inputText.Replace(" ", "").Split("×");
            if (inputArr.Length != 3) throw new Exception("Incorrect input");

            UnitOfMeasure unit = UnitOfMeasure.meter;
            double edgeA, edgeB, edgeC;
            for (int i = 0; i < inputArr.Length; i++)
            {
                inputArr[i].ToLower();

                if ((inputArr[i].Contains("m") || inputArr[i].Contains("mm") || inputArr[i].Contains("cm")))
                {
                    if (inputArr[i].Contains("m") && !inputArr[i].Contains("mm") && !inputArr[i].Contains("cm"))
                    {
                        unit = UnitOfMeasure.meter;
                        inputArr[i] = inputArr[i].Replace("m", "").Replace(".", ",");   
                    }
                    if (inputArr[i].Contains("mm") && !inputArr[i].Contains("cm"))
                    {
                        unit = UnitOfMeasure.millimeter;
                        inputArr[i] = inputArr[i].Replace("mm", "").Replace(".", ",");
                    }
                    if (!inputArr[i].Contains("mm") && inputArr[i].Contains("cm"))
                    {
                        unit = UnitOfMeasure.centimeter;
                        inputArr[i] = inputArr[i].Replace("cm", "").Replace(".", ",");
                    }
                }
                else
                {
                    throw new Exception("Incorrect unit");
                }
            }
            edgeA = Convert.ToDouble(inputArr[0]);
            edgeB = Convert.ToDouble(inputArr[1]);
            edgeC = Convert.ToDouble(inputArr[2]);
            return new Pudelko(edgeA, edgeB, edgeC, unit);
        }
    }
}
