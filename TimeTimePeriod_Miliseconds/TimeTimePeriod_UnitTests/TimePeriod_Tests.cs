using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTimePeriod_Lib;

namespace TimeTimePeriod_UnitTests
{
    [TestClass]
    public class UnitTestsTimePeriodConstructors
    {
        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 1, 1, 1, 1, 1, 1, 1)]
        [DataRow(13, 15, 12, 24, 13, 15, 12, 24)]
        [DataRow(23, 59, 59, 999, 23, 59, 59, 999)]
        [DataRow(123, 15, 12, 243, 123, 15, 12, 243)]
        [DataRow(200, 59, 59, 999, 200, 59, 59, 999)]
        [DataRow(0, 59, 0, 0, 0, 59, 0, 0)]
        public void TimePeriod_Constructor_4params(long h, long m, long s, long milli,
                                           long expectedH, long expectedM, long expectedS, long expectedMilli)
        {
            TimePeriod timePeriod = new TimePeriod(h, m, s, milli);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, expectedS);
            Assert.AreEqual(timePeriod.Milliseconds, expectedMilli);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataRow(13, 15, 12, 13, 15, 12)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(123, 15, 12, 123, 15, 12)]
        [DataRow(200, 59, 59, 200, 59, 59)]
        [DataRow(0, 59, 0, 0, 59, 0)]
        public void TimePeriod_Constructor_3params(long h, long m, long s,
                                                long expectedH, long expectedM, long expectedS)
        {
            TimePeriod timePeriod = new TimePeriod(h, m, s);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, expectedS);
            Assert.AreEqual(timePeriod.Milliseconds, 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 1, 1, 1)]
        [DataRow(13, 15, 13, 15)]
        [DataRow(23, 59, 23, 59)]
        [DataRow(123, 59, 123, 59)]
        [DataRow(200, 59, 200, 59)]
        [DataRow(0, 59, 0, 59)]
        public void TimePeriod_Constructor_2params(long h, long m,
                                               long expectedH, long expectedM)
        {
            TimePeriod timePeriod = new TimePeriod(h, m);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, 0);
            Assert.AreEqual(timePeriod.Milliseconds, 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 1)]
        [DataRow(13, 13)]
        [DataRow(23, 23)]
        [DataRow(123, 123)]
        [DataRow(200, 200)]
        [DataRow(0, 0)]
        public void TimePeriod_Constructor_1param(long h, long expectedH)
        {
            TimePeriod timePeriod = new TimePeriod(hours: h);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, 0);
            Assert.AreEqual(timePeriod.Seconds, 0);
            Assert.AreEqual(timePeriod.Milliseconds, 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        public void TimePeriod_Constructor_0paramd()
        {
            TimePeriod timePeriod = new TimePeriod();
            Assert.AreEqual(timePeriod.Hours, 0);
            Assert.AreEqual(timePeriod.Minutes, 0);
            Assert.AreEqual(timePeriod.Seconds, 0);
            Assert.AreEqual(timePeriod.Milliseconds, 0);
        }

        /// <summary>
        /// Tests a constructor that takes a time period as a parameter
        /// </summary>
        /// <param name="periodSec"> Time period in seconds as a parameter of constructor </param>
        /// <param name="expectedH"> Expected hours </param>
        /// <param name="expectedM"> Expected minutes </param>
        /// <param name="expectedS"> Expected seconds </param>
        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1000, 0, 0, 1, 0)]
        [DataRow(9020, 0, 0, 9, 20)]
        [DataRow(52320, 0, 0, 52, 320)]
        [DataRow(12233456, 3, 23, 53, 456)]
        [DataRow(0, 0, 0, 0, 0)]
        public void TimePeriod_Constructor_1param_periodMilliseconds(long periodMilli,
                                                                long expectedH, long expectedM, long expectedS, long expectedMilli)
        {
            TimePeriod timePeriod = new TimePeriod(periodMilliseconds: periodMilli);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, expectedS);
            Assert.AreEqual(timePeriod.Milliseconds, expectedMilli);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow("1:1:1:1" , 1, 1, 1, 1)]
        [DataRow("23:59:59:999", 23, 59, 59, 999)]
        [DataRow("20000:59:59:999", 20000, 59, 59, 999)]
        [DataRow("12:45::", 12, 45, 0, 0)]
        [DataRow("900:::221", 900, 0, 0, 221)]
        [DataRow(":::", 0, 0, 0, 0)]
        public void TimePeriod_Constructor_1param_string(string timeP,
                                                        long expectedH, long expectedM, long expectedS, long expectedMilli)
        {
            TimePeriod timePeriod = new TimePeriod(timeP);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, expectedS);
            Assert.AreEqual(timePeriod.Milliseconds, expectedMilli);
        }
    }
    [TestClass]
    public class UnitTestsTimePeriodToString
    {

        [DataTestMethod, TestCategory("ToString")]
        [DataRow("1:1:1:1", "01:01:01:001")]
        [DataRow("23:59:59:999", "23:59:59:999")]
        [DataRow("2:59:59:1", "02:59:59:001")]
        [DataRow("12:25::", "12:25:00:000")]
        [DataRow(":::", "00:00:00:000")]
        [DataRow("2500:59:59:213", "2500:59:59:213")]
        [DataRow("1242:25:59:999", "1242:25:59:999")]
        [DataRow("1111:::1", "1111:00:00:001")]
        public void TimePeriod_StringParams_ToString(string timePeriodS, string expectedToString)
        {
            TimePeriod timePeriod = new TimePeriod(timePeriodS);
            Assert.AreEqual(timePeriod.ToString(), expectedToString);
        }

        [DataTestMethod, TestCategory("ToString")]
        [DataRow(1, 1, 1, 1, "01:01:01:001")]
        [DataRow(13, 15, 12, 14, "13:15:12:014")]
        [DataRow(23, 59, 59, 999, "23:59:59:999")]
        [DataRow(0, 59, 0, 242, "00:59:00:242")]
        [DataRow(1000, 59, 0, 0, "1000:59:00:000")]
        [DataRow(99999, 59, 0, 5, "99999:59:00:005")]
        public void TimePeriod_params_ToString(long h, long m, long s, long milli, string expectedToString)
        {
            TimePeriod timePeriod = new TimePeriod(h, m, s, milli);
            Assert.AreEqual(timePeriod.ToString(), expectedToString);

            TimePeriod timePeriod2 = new TimePeriod();
            Assert.AreEqual(timePeriod2.ToString(), "00:00:00:000");
        }
    }

    [TestClass]
    public class UnitTestsTimePeriodEquals
    {

        [DataTestMethod, TestCategory("Equals")]
        [DataRow("1:1:1:1", 1, 1, 1, 1)]
        [DataRow("23:59:59:999", 23, 59, 59, 999)]
        [DataRow("2:59:59:993", 2, 59, 59, 993)]
        [DataRow(":::", 0, 0, 0, 0)]
        [DataRow("2000:59:59:1", 2000, 59, 59, 1)]
        [DataRow("123456:::", 123456, 0, 0, 0)]
        public void TimePeriod_Equals_And_Overloaded_Operator(string timeS, long h, long m, long s, long milli)
        {
            TimePeriod time1 = new TimePeriod(timeS);
            TimePeriod time2 = new TimePeriod(h, m, s, milli);
            TimePeriod time3 = new TimePeriod(9, 9, 9, 9);

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
    public class UnitTestsTimePeriodCompare
    {

        [DataTestMethod, TestCategory("Compare")]
        [DataRow("1:1:1:1", "2:2:2:2")]
        [DataRow("23:59:59:998", "23:59:59:999")]
        [DataRow("2:59:59:999", "3:::")]
        [DataRow("2:58:59:999", "2:59:58:998")]
        [DataRow(":::", ":::1")]
        [DataRow("123456:59:58:999", "123456:59:59:999")]
        [DataRow("11112:58:59:111", "11112:59:58:111")]
        public void TimePeriod_CompareTo_And_Overloaded_Operator(string timeS1, string timeS2)
        {
            TimePeriod time1 = new TimePeriod(timeS1);
            TimePeriod time2 = new TimePeriod(timeS2);

            TimePeriod time3 = new TimePeriod(":::");
            TimePeriod time4 = new TimePeriod();

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
    public class UnitTestsTimePeriodOperations
    {
        [DataTestMethod, TestCategory("Operations")]
        [DataRow("1:1:1:1", "2:2:2:2", "03:03:03:003")]
        [DataRow("23:59:58:001", "23:59:59:0019", "47:59:57:020")]
        [DataRow(":::", ":::1", "00:00:00:001")]
        [DataRow("12345:59:59:", "12345:59:59:", "24691:59:58:000")]
        [DataRow("900:1:1:999", ":::1", "900:1:2:000")]
        public void TimePeriod_Plus(string timeS1, string timeS2, string timeS3)
        {
            TimePeriod time1 = new TimePeriod(timeS1);
            TimePeriod time2 = new TimePeriod(timeS2);
            TimePeriod time3 = new TimePeriod(timeS3);

            Assert.AreEqual(time1.Plus(time2), time3);
            Assert.AreEqual(TimePeriod.Plus(time1, time2), time3);
            Assert.AreEqual(time1 + time2, time3);
        }

        [DataTestMethod, TestCategory("Operations")]
        [DataRow("2:2:2:2", "1:1:1:1", "01:01:01:001")]
        [DataRow("23:59:59:999", "00:59:59:999", "23:00:00:000")]
        public void TimePeriod_Minus(string timeS1, string timeS2, string timeS3)
        {
            TimePeriod time1 = new TimePeriod(timeS1);
            TimePeriod time2 = new TimePeriod(timeS2);
            TimePeriod time3 = new TimePeriod(timeS3);

            Assert.AreEqual(time1.Minus(time2), time3);
            Assert.AreEqual(TimePeriod.Minus(time1, time2), time3);
            Assert.AreEqual(time1 - time2, time3);
        }
    }

}
