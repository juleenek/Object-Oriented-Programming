using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using PudelkoLib;

namespace PudelkoUnitTests
{

    [TestClass]
    public static class InitializeCulture
    {
        [AssemblyInitialize]
        public static void SetEnglishCultureOnAllUnitTest(TestContext context)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }
    }

    // ========================================

    [TestClass]
    public class UnitTestsPudelkoConstructors
    {
        private static double defaultSize = 0.1; // w metrach
        private static double accuracy = 0.001; //dok³adnoœæ 3 miejsca po przecinku

        private void AssertPudelko(Pudelko p, double expectedA, double expectedB, double expectedC)
        {
            Assert.AreEqual(expectedA, p.A, delta: accuracy);
            Assert.AreEqual(expectedB, p.B, delta: accuracy);
            Assert.AreEqual(expectedC, p.C, delta: accuracy);
        }

        #region Constructor tests ================================

        [TestMethod, TestCategory("Constructors")]
        public void Constructor_Default()
        {
            Pudelko p = new Pudelko();

            Assert.AreEqual(defaultSize, p.A, delta: accuracy);
            Assert.AreEqual(defaultSize, p.B, delta: accuracy);
            Assert.AreEqual(defaultSize, p.C, delta: accuracy);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1.0, 2.543, 3.1,
                 1.0, 2.543, 3.1)]
        [DataRow(1.0001, 2.54387, 3.1005,
                 1.0, 2.543, 3.1)] // dla metrów licz¹ siê 3 miejsca po przecinku
        public void Constructor_3params_DefaultMeters(double a, double b, double c,
                                                      double expectedA, double expectedB, double expectedC)
        {
            Pudelko p = new Pudelko(a, b, c);

            AssertPudelko(p, expectedA, expectedB, expectedC);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1.0, 2.543, 3.1,
                 1.0, 2.543, 3.1)]
        [DataRow(1.0001, 2.54387, 3.1005,
                 1.0, 2.543, 3.1)] // dla metrów licz¹ siê 3 miejsca po przecinku
        public void Constructor_3params_InMeters(double a, double b, double c,
                                                      double expectedA, double expectedB, double expectedC)
        {
            Pudelko p = new Pudelko(a, b, c, unit: UnitOfMeasure.meter);

            AssertPudelko(p, expectedA, expectedB, expectedC);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(100.0, 25.5, 3.1,
                 1.0, 0.255, 0.031)]
        [DataRow(100.0, 25.58, 3.13,
                 1.0, 0.255, 0.031)] // dla centymertów liczy siê tylko 1 miejsce po przecinku
        public void Constructor_3params_InCentimeters(double a, double b, double c,
                                                      double expectedA, double expectedB, double expectedC)
        {
            Pudelko p = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.centimeter);

            AssertPudelko(p, expectedA, expectedB, expectedC);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(100, 255, 3,
                 0.1, 0.255, 0.003)]
        [DataRow(100.0, 25.58, 3.13,
                 0.1, 0.025, 0.003)] // dla milimetrów nie licz¹ siê miejsca po przecinku
        public void Constructor_3params_InMilimeters(double a, double b, double c,
                                                     double expectedA, double expectedB, double expectedC)
        {
            Pudelko p = new Pudelko(unit: UnitOfMeasure.milimeter, a: a, b: b, c: c);

            AssertPudelko(p, expectedA, expectedB, expectedC);
        }


        // ----

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1.0, 2.5, 1.0, 2.5)]
        [DataRow(1.001, 2.599, 1.001, 2.599)]
        [DataRow(1.0019, 2.5999, 1.001, 2.599)]
        public void Constructor_2params_DefaultMeters(double a, double b, double expectedA, double expectedB)
        {
            Pudelko p = new Pudelko(a, b);

            AssertPudelko(p, expectedA, expectedB, expectedC: 0.1);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1.0, 2.5, 1.0, 2.5)]
        [DataRow(1.001, 2.599, 1.001, 2.599)]
        [DataRow(1.0019, 2.5999, 1.001, 2.599)]
        public void Constructor_2params_InMeters(double a, double b, double expectedA, double expectedB)
        {
            Pudelko p = new Pudelko(a: a, b: b, unit: UnitOfMeasure.meter);

            AssertPudelko(p, expectedA, expectedB, expectedC: 0.1);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(11.0, 2.5, 0.11, 0.025)]
        [DataRow(100.1, 2.599, 1.001, 0.025)]
        [DataRow(2.0019, 0.25999, 0.02, 0.002)]
        public void Constructor_2params_InCentimeters(double a, double b, double expectedA, double expectedB)
        {
            Pudelko p = new Pudelko(unit: UnitOfMeasure.centimeter, a: a, b: b);

            AssertPudelko(p, expectedA, expectedB, expectedC: 0.1);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(11, 2.0, 0.011, 0.002)]
        [DataRow(100.1, 2599, 0.1, 2.599)]
        [DataRow(200.19, 2.5999, 0.2, 0.002)]
        public void Constructor_2params_InMilimeters(double a, double b, double expectedA, double expectedB)
        {
            Pudelko p = new Pudelko(unit: UnitOfMeasure.milimeter, a: a, b: b);

            AssertPudelko(p, expectedA, expectedB, expectedC: 0.1);
        }

        // -------

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(2.5)]
        public void Constructor_1param_DefaultMeters(double a)
        {
            Pudelko p = new Pudelko(a);

            Assert.AreEqual(a, p.A);
            Assert.AreEqual(0.1, p.B);
            Assert.AreEqual(0.1, p.C);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(2.5)]
        public void Constructor_1param_InMeters(double a)
        {
            Pudelko p = new Pudelko(a);

            Assert.AreEqual(a, p.A);
            Assert.AreEqual(0.1, p.B);
            Assert.AreEqual(0.1, p.C);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(11.0, 0.11)]
        [DataRow(100.1, 1.001)]
        [DataRow(2.0019, 0.02)]
        public void Constructor_1param_InCentimeters(double a, double expectedA)
        {
            Pudelko p = new Pudelko(unit: UnitOfMeasure.centimeter, a: a);

            AssertPudelko(p, expectedA, expectedB: 0.1, expectedC: 0.1);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(11, 0.011)]
        [DataRow(100.1, 0.1)]
        [DataRow(200.19, 0.2)]
        public void Constructor_1param_InMilimeters(double a, double expectedA)
        {
            Pudelko p = new Pudelko(unit: UnitOfMeasure.milimeter, a: a);

            AssertPudelko(p, expectedA, expectedB: 0.1, expectedC: 0.1);
        }

        // ---

        public static IEnumerable<object[]> DataSet1Meters_ArgumentOutOfRangeEx => new List<object[]>
        {
            new object[] {-1.0, 2.5, 3.1},
            new object[] {1.0, -2.5, 3.1},
            new object[] {1.0, 2.5, -3.1},
            new object[] {-1.0, -2.5, 3.1},
            new object[] {-1.0, 2.5, -3.1},
            new object[] {1.0, -2.5, -3.1},
            new object[] {-1.0, -2.5, -3.1},
            new object[] {0, 2.5, 3.1},
            new object[] {1.0, 0, 3.1},
            new object[] {1.0, 2.5, 0},
            new object[] {1.0, 0, 0},
            new object[] {0, 2.5, 0},
            new object[] {0, 0, 3.1},
            new object[] {0, 0, 0},
            new object[] {10.1, 2.5, 3.1},
            new object[] {10, 10.1, 3.1},
            new object[] {10, 10, 10.1},
            new object[] {10.1, 10.1, 3.1},
            new object[] {10.1, 10, 10.1},
            new object[] {10, 10.1, 10.1},
            new object[] {10.1, 10.1, 10.1}
        };

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSet1Meters_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3params_DefaultMeters_ArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p = new Pudelko(a, b, c);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSet1Meters_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3params_InMeters_ArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p = new Pudelko(a, b, c, unit: UnitOfMeasure.meter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(1, 1, -1)]
        [DataRow(-1, -1, 1)]
        [DataRow(-1, 1, -1)]
        [DataRow(1, -1, -1)]
        [DataRow(-1, -1, -1)]
        [DataRow(0, 1, 1)]
        [DataRow(1, 0, 1)]
        [DataRow(1, 1, 0)]
        [DataRow(0, 0, 1)]
        [DataRow(0, 1, 0)]
        [DataRow(1, 0, 0)]
        [DataRow(0, 0, 0)]
        [DataRow(0.01, 0.1, 1)]
        [DataRow(0.1, 0.01, 1)]
        [DataRow(0.1, 0.1, 0.01)]
        [DataRow(1001, 1, 1)]
        [DataRow(1, 1001, 1)]
        [DataRow(1, 1, 1001)]
        [DataRow(1001, 1, 1001)]
        [DataRow(1, 1001, 1001)]
        [DataRow(1001, 1001, 1)]
        [DataRow(1001, 1001, 1001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3params_InCentimeters_ArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p = new Pudelko(a, b, c, unit: UnitOfMeasure.centimeter);
        }


        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(1, 1, -1)]
        [DataRow(-1, -1, 1)]
        [DataRow(-1, 1, -1)]
        [DataRow(1, -1, -1)]
        [DataRow(-1, -1, -1)]
        [DataRow(0, 1, 1)]
        [DataRow(1, 0, 1)]
        [DataRow(1, 1, 0)]
        [DataRow(0, 0, 1)]
        [DataRow(0, 1, 0)]
        [DataRow(1, 0, 0)]
        [DataRow(0, 0, 0)]
        [DataRow(0.1, 1, 1)]
        [DataRow(1, 0.1, 1)]
        [DataRow(1, 1, 0.1)]
        [DataRow(10001, 1, 1)]
        [DataRow(1, 10001, 1)]
        [DataRow(1, 1, 10001)]
        [DataRow(10001, 10001, 1)]
        [DataRow(10001, 1, 10001)]
        [DataRow(1, 10001, 10001)]
        [DataRow(10001, 10001, 10001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3params_InMiliimeters_ArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p = new Pudelko(a, b, c, unit: UnitOfMeasure.milimeter);
        }


        public static IEnumerable<object[]> DataSet2Meters_ArgumentOutOfRangeEx => new List<object[]>
        {
            new object[] {-1.0, 2.5},
            new object[] {1.0, -2.5},
            new object[] {-1.0, -2.5},
            new object[] {0, 2.5},
            new object[] {1.0, 0},
            new object[] {0, 0},
            new object[] {10.1, 10},
            new object[] {10, 10.1},
            new object[] {10.1, 10.1}
        };

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSet2Meters_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2params_DefaultMeters_ArgumentOutOfRangeException(double a, double b)
        {
            Pudelko p = new Pudelko(a, b);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSet2Meters_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2params_InMeters_ArgumentOutOfRangeException(double a, double b)
        {
            Pudelko p = new Pudelko(a, b, unit: UnitOfMeasure.meter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1, 1)]
        [DataRow(1, -1)]
        [DataRow(-1, -1)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(0, 0)]
        [DataRow(0.01, 1)]
        [DataRow(1, 0.01)]
        [DataRow(0.01, 0.01)]
        [DataRow(1001, 1)]
        [DataRow(1, 1001)]
        [DataRow(1001, 1001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2params_InCentimeters_ArgumentOutOfRangeException(double a, double b)
        {
            Pudelko p = new Pudelko(a, b, unit: UnitOfMeasure.centimeter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1, 1)]
        [DataRow(1, -1)]
        [DataRow(-1, -1)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(0, 0)]
        [DataRow(0.1, 1)]
        [DataRow(1, 0.1)]
        [DataRow(0.1, 0.1)]
        [DataRow(10001, 1)]
        [DataRow(1, 10001)]
        [DataRow(10001, 10001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2params_InMilimeters_ArgumentOutOfRangeException(double a, double b)
        {
            Pudelko p = new Pudelko(a, b, unit: UnitOfMeasure.milimeter);
        }




        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1.0)]
        [DataRow(0)]
        [DataRow(10.1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_DefaultMeters_ArgumentOutOfRangeException(double a)
        {
            Pudelko p = new Pudelko(a);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1.0)]
        [DataRow(0)]
        [DataRow(10.1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_InMeters_ArgumentOutOfRangeException(double a)
        {
            Pudelko p = new Pudelko(a, unit: UnitOfMeasure.meter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1.0)]
        [DataRow(0)]
        [DataRow(0.01)]
        [DataRow(1001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_InCentimeters_ArgumentOutOfRangeException(double a)
        {
            Pudelko p = new Pudelko(a, unit: UnitOfMeasure.centimeter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(0.1)]
        [DataRow(10001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_InMilimeters_ArgumentOutOfRangeException(double a)
        {
            Pudelko p = new Pudelko(a, unit: UnitOfMeasure.milimeter);
        }

        #endregion


        #region ToString tests ===================================

        [TestMethod, TestCategory("String representation")]
        public void ToString_Default_Culture_EN()
        {
            var p = new Pudelko(2.5, 9.321);
            string expectedStringEN = "2.500 m × 9.321 m × 0.100 m";

            Assert.AreEqual(expectedStringEN, p.ToString());
        }

        [DataTestMethod, TestCategory("String representation")]
        [DataRow(null, 2.5, 9.321, 0.1, "2.500 m × 9.321 m × 0.100 m")]
        [DataRow("m", 2.5, 9.321, 0.1, "2.500 m × 9.321 m × 0.100 m")]
        [DataRow("cm", 2.5, 9.321, 0.1, "250.0 cm × 932.1 cm × 10.0 cm")]
        [DataRow("mm", 2.5, 9.321, 0.1, "2500 mm × 9321 mm × 100 mm")]
        public void ToString_Formattable_Culture_EN(string format, double a, double b, double c, string expectedStringRepresentation)
        {
            var p = new Pudelko(a, b, c, unit: UnitOfMeasure.meter);
            Assert.AreEqual(expectedStringRepresentation, p.ToString(format));
        }

        [TestMethod, TestCategory("String representation")]
        [ExpectedException(typeof(FormatException))]
        public void ToString_Formattable_WrongFormat_FormatException()
        {
            var p = new Pudelko(1);
            var stringformatedrepreentation = p.ToString("wrong code");
        }

        #endregion


        #region Pole, Objêtoœæ ===================================

        [DataTestMethod, TestCategory("Area")]
        [DataRow(5.0, 2.5, 3.1, 71.5)]
        [DataRow(0.2, 10.0, 1.11, 26.644)] 
        public void Area_3params_InMeter(double a, double b, double c,
                                                  double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, c: c);
            Assert.AreEqual(p.Pole, expectedArea);
        }

        [DataTestMethod, TestCategory("Area")]
        [DataRow(5.0, 2.5, 26.500)]
        [DataRow(0.2, 10.0, 6.040)]
        public void Area_2params_InMeter(double a, double b,
                                                double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b);
            Assert.AreEqual(p.Pole, expectedArea);
        }

        [DataTestMethod, TestCategory("Area")]
        [DataRow(5.0, 2.020)]
        [DataRow(0.2, 0.100)]
        public void Area_1param_InMeter(double a,
                                                double expectedArea)
        {
            Pudelko p = new Pudelko(a: a);
            Assert.AreEqual(p.Pole, expectedArea);
        }
        [DataTestMethod, TestCategory("Area")]
        [DataRow(0.060)]
        public void Area_0params(double expectedArea)
        {
            Pudelko p = new Pudelko();
            Assert.AreEqual(p.Pole, expectedArea);
        }
        [DataTestMethod, TestCategory("Area")]
        [DataRow(515.0, 21.5, 31.1, 5.55153)]
        [DataRow(10.2, 110.0, 11.11, 0.491484)]
        public void Area_3params_InCentimeter(double a, double b, double c,
                                               double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.centimeter);
            Assert.AreEqual(p.Pole, expectedArea);
        }

        [DataTestMethod, TestCategory("Area")]
        [DataRow(100.0, 950.0, 21.1)]
        [DataRow(100.0, 800.0, 17.8)]
        public void Area_2params_InCentimeter(double a, double b,
                                                double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, unit: UnitOfMeasure.centimeter);
            Assert.AreEqual(p.Pole, expectedArea);
        }
       
        [DataTestMethod, TestCategory("Volume")]
        [DataRow(5.23425, 2.52532, 3.1235252, 41.287244019)]
        public void Volume_3params_InMeter(double a, double b, double c,
                                                  double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, c: c);
            Assert.AreEqual(p.Objetosc, expectedArea);
        }
        [DataTestMethod, TestCategory("Volume")]
        [DataRow(5.23425, 2.52532, 1.321815621)]
        public void Volume_2params_InMeter(double a, double b, 
                                          double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b);
            Assert.AreEqual(p.Objetosc, expectedArea);
        }
        [DataTestMethod, TestCategory("Volume")]
        [DataRow(0.001)]
        public void Volume_0params(double expectedArea)
        {
            Pudelko p = new Pudelko();
            Assert.AreEqual(p.Objetosc, expectedArea);
        }
        [DataTestMethod, TestCategory("Volume")]
        [DataRow(5555.555, 1234.123, 1122.334, 7.694989248)]
        public void Volume_3params_InMilimeter(double a, double b, double c,
                                          double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.milimeter);
            Assert.AreEqual(p.Objetosc, expectedArea);
        }
        [DataTestMethod, TestCategory("Volume")]
        [DataRow(9000.22, 1233.21, 1.109916131)]
        public void Volume_2params_InMilimeter(double a, double b,
                                        double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, unit: UnitOfMeasure.milimeter);
            Assert.AreEqual(p.Objetosc, expectedArea);
        }
        [DataTestMethod, TestCategory("Volume")]
        [DataRow(2000, 0.02)]
        public void Volume_1param_InMilimeter(double a,
                                      double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, unit: UnitOfMeasure.milimeter);
            Assert.AreEqual(p.Objetosc, expectedArea);
        }

        [DataTestMethod, TestCategory("Area")]
        [DataRow(54.0, 2.5, 3.1, 71.5)]
        [DataRow(0.2, 10.1, 1.11, 26.644)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Area_3params_InMeter_ArgumentOutOfRangeException(double a, double b, double c,
                                           double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, c: c);
            Assert.AreEqual(p.Pole, expectedArea);
        }

        [DataTestMethod, TestCategory("Area")]
        [DataRow(1100.0, 950.0, 21.1)]
        [DataRow(1000.011, 800.0, 17.8)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Area_2params_InCentimeter_ArgumentOutOfRangeException(double a, double b,
                                          double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, unit: UnitOfMeasure.centimeter);
            Assert.AreEqual(p.Pole, expectedArea);
        }

        [DataTestMethod, TestCategory("Volume")]
        [DataRow(5.23425, 2.52532, 10.1235252, 41.287244019)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Volume_3params_InMeter_ArgumentOutOfRangeException(double a, double b, double c,
                                                  double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b, c: c);
            Assert.AreEqual(p.Objetosc, expectedArea);
        }
        [DataTestMethod, TestCategory("Volume")]
        [DataRow(5.23425, 22.52532, 1.321815621)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Volume_2params_InMeter_ArgumentOutOfRangeException(double a, double b,
                                          double expectedArea)
        {
            Pudelko p = new Pudelko(a: a, b: b);
            Assert.AreEqual(p.Objetosc, expectedArea);
        }

        #endregion

        #region Equals ===========================================
        [DataTestMethod, TestCategory("Equals")]
        [DataRow(5.0, 2.5, 3.1)]
        [DataRow(0.2, 10.0, 1.11)]
        public void EqualsMeters(double a, double b, double c)
        {
            Pudelko p1 = new Pudelko(a: a, b: b, c: c);
            Pudelko p2 = new Pudelko(a: a, b: b, c: c);

            Pudelko p3 = new Pudelko(a: a, b: b);
            Pudelko p4 = new Pudelko(a: a, b: b);

            Pudelko p5 = new Pudelko(a: a);
            Pudelko p6 = new Pudelko(a: a);

            Pudelko p7 = new Pudelko();
            Pudelko p8 = new Pudelko();

            Assert.AreEqual(p1.Equals(p2), true);
            Assert.AreEqual(p2.Equals(p1), true);
            Assert.AreEqual(p3.Equals(p4), true);
            Assert.AreEqual(p4.Equals(p3), true);
            Assert.AreEqual(p5.Equals(p6), true);
            Assert.AreEqual(p6.Equals(p5), true);
            Assert.AreEqual(p7.Equals(p8), true);
            Assert.AreEqual(p8.Equals(p7), true);

            Assert.AreEqual(p1.Equals(p1), true);
            Assert.AreEqual(p2.Equals(p2), true);
            Assert.AreEqual(p3.Equals(p3), true);
            Assert.AreEqual(p4.Equals(p4), true);
            Assert.AreEqual(p5.Equals(p5), true);
            Assert.AreEqual(p6.Equals(p6), true);
            Assert.AreEqual(p7.Equals(p7), true);
            Assert.AreEqual(p8.Equals(p8), true);
   

            Assert.AreEqual(p1.Equals(p4), false);
            Assert.AreEqual(p2.Equals(p3), false);
            Assert.AreEqual(p3.Equals(p2), false);
            Assert.AreEqual(p4.Equals(p1), false);
            Assert.AreEqual(p5.Equals(p8), false);
            Assert.AreEqual(p6.Equals(p7), false);
            Assert.AreEqual(p7.Equals(p6), false);
            Assert.AreEqual(p8.Equals(p5), false);
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(100.1, 222.5, 332.1)]
        [DataRow(123.22, 120.0, 121.11)]
        public void EqualsCentimeters(double a, double b, double c)
        {
            Pudelko p1 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.centimeter);
            Pudelko p2 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.centimeter);

            Pudelko p3 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.centimeter);
            Pudelko p4 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.centimeter);

            Pudelko p5 = new Pudelko(a: a, unit: UnitOfMeasure.centimeter);
            Pudelko p6 = new Pudelko(a: a, unit: UnitOfMeasure.centimeter);

            Assert.AreEqual(p1.Equals(p2), true);
            Assert.AreEqual(p2.Equals(p1), true);
            Assert.AreEqual(p3.Equals(p4), true);
            Assert.AreEqual(p4.Equals(p3), true);
            Assert.AreEqual(p5.Equals(p6), true);
            Assert.AreEqual(p6.Equals(p5), true);

            Assert.AreEqual(p1.Equals(p1), true);
            Assert.AreEqual(p2.Equals(p2), true);
            Assert.AreEqual(p3.Equals(p3), true);
            Assert.AreEqual(p4.Equals(p4), true);
            Assert.AreEqual(p5.Equals(p5), true);
            Assert.AreEqual(p6.Equals(p6), true);

            Assert.AreEqual(p1.Equals(p4), false);
            Assert.AreEqual(p2.Equals(p3), false);
            Assert.AreEqual(p3.Equals(p2), false);
            Assert.AreEqual(p4.Equals(p1), false);
            Assert.AreEqual(p5.Equals(p1), false);
            Assert.AreEqual(p6.Equals(p2), false);
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(1040.1, 3222.5, 4332.1)]
        [DataRow(3123.22, 5120.40, 4121.11)]
        public void EqualsMilimeters(double a, double b, double c)
        {
            Pudelko p1 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.milimeter);
            Pudelko p2 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.milimeter);

            Pudelko p3 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.milimeter);
            Pudelko p4 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.milimeter);

            Pudelko p5 = new Pudelko(a: a, unit: UnitOfMeasure.milimeter);
            Pudelko p6 = new Pudelko(a: a, unit: UnitOfMeasure.milimeter);

            Assert.AreEqual(p1.Equals(p2), true);
            Assert.AreEqual(p2.Equals(p1), true);
            Assert.AreEqual(p3.Equals(p4), true);
            Assert.AreEqual(p4.Equals(p3), true);
            Assert.AreEqual(p5.Equals(p6), true);
            Assert.AreEqual(p6.Equals(p5), true);

            Assert.AreEqual(p1.Equals(p1), true);
            Assert.AreEqual(p2.Equals(p2), true);
            Assert.AreEqual(p3.Equals(p3), true);
            Assert.AreEqual(p4.Equals(p4), true);
            Assert.AreEqual(p5.Equals(p5), true);
            Assert.AreEqual(p6.Equals(p6), true);

            Assert.AreEqual(p1.Equals(p4), false);
            Assert.AreEqual(p2.Equals(p3), false);
            Assert.AreEqual(p3.Equals(p2), false);
            Assert.AreEqual(p4.Equals(p1), false);
            Assert.AreEqual(p5.Equals(p1), false);
            Assert.AreEqual(p6.Equals(p2), false);
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(1443040.1, 433222.5, 334332.1)]
        [DataRow(3433123.22, 5533120.40, 444121.11)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EqualsMilimetersArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p1 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.milimeter);
            Pudelko p2 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.milimeter);

            Pudelko p3 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.milimeter);
            Pudelko p4 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.milimeter);

            Pudelko p5 = new Pudelko(a: a, unit: UnitOfMeasure.milimeter);
            Pudelko p6 = new Pudelko(a: a, unit: UnitOfMeasure.milimeter);

            Assert.AreEqual(p1.Equals(p2), true);
            Assert.AreEqual(p2.Equals(p1), true);
            Assert.AreEqual(p3.Equals(p4), true);
            Assert.AreEqual(p4.Equals(p3), true);
            Assert.AreEqual(p5.Equals(p6), true);
            Assert.AreEqual(p6.Equals(p5), true);

            Assert.AreEqual(p1.Equals(p1), true);
            Assert.AreEqual(p2.Equals(p2), true);
            Assert.AreEqual(p3.Equals(p3), true);
            Assert.AreEqual(p4.Equals(p4), true);
            Assert.AreEqual(p5.Equals(p5), true);
            Assert.AreEqual(p6.Equals(p6), true);

            Assert.AreEqual(p1.Equals(p4), false);
            Assert.AreEqual(p2.Equals(p3), false);
            Assert.AreEqual(p3.Equals(p2), false);
            Assert.AreEqual(p4.Equals(p1), false);
            Assert.AreEqual(p5.Equals(p1), false);
            Assert.AreEqual(p6.Equals(p2), false);
        }
        [DataTestMethod, TestCategory("Equals")]
        [DataRow(15.0, 2.5, 3.1)]
        [DataRow(0.2, 10.1, 1.11)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EqualsMetersArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p1 = new Pudelko(a: a, b: b, c: c);
            Pudelko p2 = new Pudelko(a: a, b: b, c: c);

            Pudelko p3 = new Pudelko(a: a, b: b);
            Pudelko p4 = new Pudelko(a: a, b: b);

            Pudelko p5 = new Pudelko(a: a);
            Pudelko p6 = new Pudelko(a: a);

            Pudelko p7 = new Pudelko();
            Pudelko p8 = new Pudelko();

            Assert.AreEqual(p1.Equals(p2), true);
            Assert.AreEqual(p2.Equals(p1), true);
            Assert.AreEqual(p3.Equals(p4), true);
            Assert.AreEqual(p4.Equals(p3), true);
            Assert.AreEqual(p5.Equals(p6), true);
            Assert.AreEqual(p6.Equals(p5), true);
            Assert.AreEqual(p7.Equals(p8), true);
            Assert.AreEqual(p8.Equals(p7), true);

            Assert.AreEqual(p1.Equals(p1), true);
            Assert.AreEqual(p2.Equals(p2), true);
            Assert.AreEqual(p3.Equals(p3), true);
            Assert.AreEqual(p4.Equals(p4), true);
            Assert.AreEqual(p5.Equals(p5), true);
            Assert.AreEqual(p6.Equals(p6), true);
            Assert.AreEqual(p7.Equals(p7), true);
            Assert.AreEqual(p8.Equals(p8), true);


            Assert.AreEqual(p1.Equals(p4), false);
            Assert.AreEqual(p2.Equals(p3), false);
            Assert.AreEqual(p3.Equals(p2), false);
            Assert.AreEqual(p4.Equals(p1), false);
            Assert.AreEqual(p5.Equals(p8), false);
            Assert.AreEqual(p6.Equals(p7), false);
            Assert.AreEqual(p7.Equals(p6), false);
            Assert.AreEqual(p8.Equals(p5), false);
        }

        [DataTestMethod, TestCategory("Equals")]
        [DataRow(1001.1, 222.5, 332.1)]
        [DataRow(123.22, 120.0, 1000.1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EqualsCentimetersArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p1 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.centimeter);
            Pudelko p2 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.centimeter);

            Pudelko p3 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.centimeter);
            Pudelko p4 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.centimeter);

            Pudelko p5 = new Pudelko(a: a, unit: UnitOfMeasure.centimeter);
            Pudelko p6 = new Pudelko(a: a, unit: UnitOfMeasure.centimeter);

            Assert.AreEqual(p1.Equals(p2), true);
            Assert.AreEqual(p2.Equals(p1), true);
            Assert.AreEqual(p3.Equals(p4), true);
            Assert.AreEqual(p4.Equals(p3), true);
            Assert.AreEqual(p5.Equals(p6), true);
            Assert.AreEqual(p6.Equals(p5), true);

            Assert.AreEqual(p1.Equals(p1), true);
            Assert.AreEqual(p2.Equals(p2), true);
            Assert.AreEqual(p3.Equals(p3), true);
            Assert.AreEqual(p4.Equals(p4), true);
            Assert.AreEqual(p5.Equals(p5), true);
            Assert.AreEqual(p6.Equals(p6), true);

            Assert.AreEqual(p1.Equals(p4), false);
            Assert.AreEqual(p2.Equals(p3), false);
            Assert.AreEqual(p3.Equals(p2), false);
            Assert.AreEqual(p4.Equals(p1), false);
            Assert.AreEqual(p5.Equals(p1), false);
            Assert.AreEqual(p6.Equals(p2), false);
        }
        #endregion

        #region Operators overloading ===========================

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(1.1, 2.5, 3.1)]
        [DataRow(1.22, 10.0, 5.1)]
        public void EqualityOperatorsMeters(double a, double b, double c)
        {
            Pudelko p1 = new Pudelko(a: a, b: b, c: c);
            Pudelko p2 = new Pudelko(a: a, b: b, c: c);

            Pudelko p3 = new Pudelko(a: a, b: b);
            Pudelko p4 = new Pudelko(a: a, b: b);

            Pudelko p5 = new Pudelko(a: a);
            Pudelko p6 = new Pudelko(a: a);

            Assert.AreEqual(p1 == p2, true);
            Assert.AreEqual(p3 == p4, true);
            Assert.AreEqual(p5 == p6, true);

            Assert.AreEqual(p1 != p3, true);
            Assert.AreEqual(p1 != p4, true);
            Assert.AreEqual(p1 != p5, true);
            Assert.AreEqual(p1 != p6, true);

            Assert.AreEqual(p2 != p3, true);
            Assert.AreEqual(p2 != p4, true);
            Assert.AreEqual(p2 != p5, true);
            Assert.AreEqual(p2 != p6, true);

            Assert.AreEqual(p1 != p2, false);
            Assert.AreEqual(p3 != p4, false);
            Assert.AreEqual(p5 != p6, false);

            Assert.AreEqual(p1 == p3, false);
            Assert.AreEqual(p1 == p4, false);
            Assert.AreEqual(p1 == p5, false);
            Assert.AreEqual(p1 == p6, false);

            Assert.AreEqual(p2 == p3, false);
            Assert.AreEqual(p2 == p4, false);
            Assert.AreEqual(p2 == p5, false);
            Assert.AreEqual(p2 == p6, false);
        }
        [DataTestMethod, TestCategory("Operators")]
        [DataRow(100.1, 222.5, 332.1)]
        [DataRow(123.22, 120.0, 500.1)]
        public void EqualityOperatorsCentimeters(double a, double b, double c)
        {
            Pudelko p1 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.centimeter);
            Pudelko p2 = new Pudelko(a: a, b: b, c: c, unit: UnitOfMeasure.centimeter);

            Pudelko p3 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.centimeter);
            Pudelko p4 = new Pudelko(a: a, b: b, unit: UnitOfMeasure.centimeter);

            Pudelko p5 = new Pudelko(a: a, unit: UnitOfMeasure.centimeter);
            Pudelko p6 = new Pudelko(a: a, unit: UnitOfMeasure.centimeter);

            Assert.AreEqual(p1 == p2, true);
            Assert.AreEqual(p3 == p4, true);
            Assert.AreEqual(p5 == p6, true);

            Assert.AreEqual(p1 != p3, true);
            Assert.AreEqual(p1 != p4, true);
            Assert.AreEqual(p1 != p5, true);
            Assert.AreEqual(p1 != p6, true);

            Assert.AreEqual(p2 != p3, true);
            Assert.AreEqual(p2 != p4, true);
            Assert.AreEqual(p2 != p5, true);
            Assert.AreEqual(p2 != p6, true);

            Assert.AreEqual(p1 != p2, false);
            Assert.AreEqual(p3 != p4, false);
            Assert.AreEqual(p5 != p6, false);

            Assert.AreEqual(p1 == p3, false);
            Assert.AreEqual(p1 == p4, false);
            Assert.AreEqual(p1 == p5, false);
            Assert.AreEqual(p1 == p6, false);

            Assert.AreEqual(p2 == p3, false);
            Assert.AreEqual(p2 == p4, false);
            Assert.AreEqual(p2 == p5, false);
            Assert.AreEqual(p2 == p6, false);
        }

        [DataTestMethod, TestCategory("Operators")]
        public void PlusOperatorMeters()
        {
            Pudelko p1 = new Pudelko(1, 2, 3);
            Pudelko p2 = new Pudelko(4, 5, 6);

            Pudelko p3 = new Pudelko(2.2, 3, 1);
            Pudelko p4 = new Pudelko(3.1, 1, 1.1);

            Pudelko p5 = new Pudelko(2000, 3000, 1000, UnitOfMeasure.milimeter);
            Pudelko p6 = new Pudelko(3000, 1000, 1000, UnitOfMeasure.milimeter);

            Assert.AreEqual(p1 + p2, new Pudelko(5, 7, 9));
            Assert.AreEqual(p3 + p4, new Pudelko(2, 3.3, 6.1));
            Assert.AreEqual(p5 + p6, new Pudelko(2, 3, 6));
        }
        [DataTestMethod, TestCategory("Operators")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlusOperatorMetersArgumentOutOfRangeException()
        {
            Pudelko p1 = new Pudelko(1, 7, 3);
            Pudelko p2 = new Pudelko(4, 5, 6);

            Pudelko p3 = new Pudelko(2.2, 3, 1);
            Pudelko p4 = new Pudelko(3.1, 5, 8.1);

            Pudelko p5 = new Pudelko(2000, 6000, 1000, UnitOfMeasure.milimeter);
            Pudelko p6 = new Pudelko(5000, 1000, 1000, UnitOfMeasure.milimeter);

            Assert.AreEqual(p1 + p2, new Pudelko(5, 7, 9));
            Assert.AreEqual(p3 + p4, new Pudelko(2, 3.3, 6.1));
            Assert.AreEqual(p5 + p6, new Pudelko(2, 3, 6));
        }
        #endregion

        #region Conversions =====================================
        [TestMethod]
        public void ExplicitConversion_ToDoubleArray_AsMeters()
        {
            var p = new Pudelko(1, 2.1, 3.231);
            double[] tab = (double[])p;
            Assert.AreEqual(3, tab.Length);
            Assert.AreEqual(p.A, tab[0]);
            Assert.AreEqual(p.B, tab[1]);
            Assert.AreEqual(p.C, tab[2]);
        }

        [TestMethod]
        public void ImplicitConversion_FromAalueTuple_As_Pudelko_InMilimeters()
        {
            var (a, b, c) = (2500, 9321, 100); // in milimeters, ValueTuple
            Pudelko p = (a, b, c);
            Assert.AreEqual((int)(p.A * 1000), a);
            Assert.AreEqual((int)(p.B * 1000), b);
            Assert.AreEqual((int)(p.C * 1000), c);
        }

        #endregion

        #region Indexer, enumeration ============================
        [TestMethod]
        public void Indexer_ReadFrom()
        {
            var p = new Pudelko(1, 2.1, 3.231);
            Assert.AreEqual(p.A, p[0]);
            Assert.AreEqual(p.B, p[1]);
            Assert.AreEqual(p.C, p[2]);
        }

        [TestMethod]
        public void ForEach_Test()
        {
            var p = new Pudelko(1, 2.1, 3.231);
            var tab = new[] { p.A, p.B, p.C };
            int i = 0;
            foreach (double x in p)
            {
                Assert.AreEqual(x, tab[i]);
                i++;
            }
        }

        #endregion

        #region Parsing =========================================

        #endregion

    }
}