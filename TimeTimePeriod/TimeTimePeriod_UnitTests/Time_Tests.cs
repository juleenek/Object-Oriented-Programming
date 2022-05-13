using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTimePeriod_Lib;

namespace TimeTimePeriod_UnitTests
{
    [TestClass]
    public class UnitTestsTimeConstructors
    {
        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)1, (byte)1, (byte)1, (byte)1, (byte)1, (byte)1)]
        [DataRow((byte)13, (byte)15, (byte)12, (byte)13, (byte)15, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)59, (byte)59)]
        [DataRow((byte)0, (byte)59, (byte)0, (byte)0, (byte)59, (byte)0)]
        public void Time_Constructor_3params(byte h, byte m, byte s, 
                                                byte expectedH, byte expectedM, byte expectedS)
        {
            Time time = new Time(h, m, s);
            Assert.AreEqual(time.Hours, expectedH);
            Assert.AreEqual(time.Minutes, expectedM);
            Assert.AreEqual(time.Seconds, expectedS);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)1, (byte)1, (byte)1, (byte)1)]
        [DataRow((byte)13, (byte)15, (byte)13, (byte)15)]
        [DataRow((byte)23, (byte)59, (byte)23, (byte)59)]
        [DataRow((byte)0, (byte)59, (byte)0, (byte)59)]
        public void Time_Constructor_2params(byte h, byte m,
                                               byte expectedH, byte expectedM)
        {
            Time time = new Time(h, m);
            Assert.AreEqual(time.Hours, expectedH);
            Assert.AreEqual(time.Minutes, expectedM);
            Assert.AreEqual(time.Seconds, 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)1, (byte)1)]
        [DataRow((byte)13, (byte)13)]
        [DataRow((byte)23, (byte)23)]
        [DataRow((byte)0, (byte)0)]
        public void Time_Constructor_1param(byte h, byte expectedH)
        {
            Time time = new Time(h);
            Assert.AreEqual(time.Hours, expectedH);
            Assert.AreEqual(time.Minutes, 0);
            Assert.AreEqual(time.Seconds, 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        public void Time_Constructor_0paramd()
        {
            Time time = new Time();
            Assert.AreEqual(time.Hours, 0);
            Assert.AreEqual(time.Minutes, 0);
            Assert.AreEqual(time.Seconds, 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow("1:1:1", 1, 1, 1)]
        [DataRow("23:59:59", 23, 59, 59)]
        [DataRow("2:59:59", 2, 59, 59)]
        [DataRow("12:25:", 12, 25, 0)]
        [DataRow("0::", 0, 0, 0)]
        [DataRow("::", 0, 0, 0)]
        public void Time_Constructor_1param_string(string timeS,
                                                        long expectedH, long expectedM, long expectedS)
        {
            Time time = new Time(timeS);
            Assert.AreEqual(time.Hours, expectedH);
            Assert.AreEqual(time.Minutes, expectedM);
            Assert.AreEqual(time.Seconds, expectedS);
        }
    }

    [TestClass]
    public class UnitTestsTimeToString
    {

        [DataTestMethod, TestCategory("ToString")]
        [DataRow("1:1:1", "01:01:01")]
        [DataRow("23:59:59", "23:59:59")]
        [DataRow("2:59:59", "02:59:59")]
        [DataRow("12:25:", "12:25:00")]
        [DataRow("::", "00:00:00")]
        public void Time_StringParams_ToString(string timeS, string expectedToString)
        {
            Time time = new Time(timeS);
            Assert.AreEqual(time.ToString(), expectedToString);
        }

        [DataTestMethod, TestCategory("ToString")]
        [DataRow((byte)1, (byte)1, (byte)1, "01:01:01")]
        [DataRow((byte)13, (byte)15, (byte)12, "13:15:12")]
        [DataRow((byte)23, (byte)59, (byte)59, "23:59:59")]
        [DataRow((byte)0, (byte)59, (byte)0, "00:59:00")]
        public void Time_params_ToString(byte h, byte m, byte s, string expectedToString)
        {
            Time time = new Time(h, m, s);
            Assert.AreEqual(time.ToString(), expectedToString);

            Time time2 = new Time();
            Assert.AreEqual(time2.ToString(), "00:00:00");
        }
    }

    [TestClass]
    public class UnitTestsTimeEquals
    {

        [DataTestMethod, TestCategory("Equals")]
        [DataRow("1:1:1", (byte)1, (byte)1, (byte)1)]
        [DataRow("23:59:59", (byte)23, (byte)59, (byte)59)]
        [DataRow("2:59:59", (byte)2, (byte)59, (byte)59)]
        [DataRow("::", (byte)0, (byte)0, (byte)0)]
        public void Time_Equals_And_Overloaded_Operator(string timeS, byte h, byte m, byte s)
        {
            Time time1 = new Time(timeS);
            Time time2 = new Time(h, m, s);
            Time time3 = new Time(9, 9, 9);

            Assert.AreEqual(time1.Equals(time2), true);
            Assert.AreEqual(Equals(time1, time2), true);
            Assert.AreEqual((time1 == time2), true);

            Assert.AreEqual(time1.Equals(time3), false);
            Assert.AreEqual(Equals(time1, time3), false);
            Assert.AreEqual((time1 == time3), false);

            Assert.AreEqual(time2.Equals(time3), false);
            Assert.AreEqual(Equals(time2, time3), false);
            Assert.AreEqual((time2 == time3), false);
        }
    }

    [TestClass]
    public class UnitTestsTimeCompare
    {

        [DataTestMethod, TestCategory("Equals")]
        [DataRow("1:1:1", "2:2:2")]
        [DataRow("23:59:58", "23:59:59")]
        [DataRow("2:59:59", "3::")]
        [DataRow("2:58:59", "2:59:58")]
        [DataRow("::", "::1")]
        public void Time_CompareTo_And_Overloaded_Operator(string timeS1, string timeS2)
        {
            Time time1 = new Time(timeS1);
            Time time2 = new Time(timeS2);

            Time time3 = new Time("::");
            Time time4 = new Time();

            Assert.AreEqual(time1.CompareTo(time2), -1);
            Assert.AreEqual(time2.CompareTo(time1), 1);

            Assert.AreEqual(time3.CompareTo(time4), 0);

            Assert.AreEqual(time1 < time2, true);
            Assert.AreEqual(time1 <= time2, true);

            Assert.AreEqual(time1 > time2, false);
            Assert.AreEqual(time1 >= time2, false);

            Assert.AreEqual(time3 >= time4, true);
            Assert.AreEqual(time3 <= time4, true);
            Assert.AreEqual(time3 == time4, true);

            Assert.AreEqual(time3 > time4, false);
            Assert.AreEqual(time3 < time4, false);
        }
    }
    [TestClass]
    public class UnitTestsTimeOperations
    {
        [DataTestMethod, TestCategory("Operations")]
        [DataRow("1:1:1", "2:2:2", "03:03:03")]
        [DataRow("23:59:58", "00:00:01", "23:59:59")]
        [DataRow("::", "::1", "00:00:01")]
        public void TimePeriod_Plus(string timeS1, string timeS2, string timeS3)
        {
            Time time1 = new Time(timeS1);
            TimePeriod timePeriod = new TimePeriod(timeS2);
            Time time2 = new Time(timeS3);

            Assert.AreEqual(time1.Plus(timePeriod), time2);
            Assert.AreEqual(Time.Plus(time1, timePeriod), time2);
            Assert.AreEqual(time1 + timePeriod, time2);
        }

        [DataTestMethod, TestCategory("Operations")]
        [DataRow("2:2:2", "1:1:1", "01:01:01")]
        [DataRow("23:59:59", "00:00:01", "23:59:58")]
        [DataRow("::1", "::1", "00:00:00")]
        public void TimePeriod_Minus(string timeS1, string timeS2, string timeS3)
        {
            Time time1 = new Time(timeS1);
            TimePeriod timePeriod = new TimePeriod(timeS2);
            Time time2 = new Time(timeS3);

            Assert.AreEqual(time1.Minus(timePeriod), time2);
            Assert.AreEqual(Time.Minus(time1, timePeriod), time2);
            Assert.AreEqual(time1 - timePeriod, time2);
        }
    }
}
