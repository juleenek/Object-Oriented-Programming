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
        }

        [DataTestMethod, TestCategory("Constructors")]
        public void TimePeriod_Constructor_0paramd()
        {
            TimePeriod timePeriod = new TimePeriod();
            Assert.AreEqual(timePeriod.Hours, 0);
            Assert.AreEqual(timePeriod.Minutes, 0);
            Assert.AreEqual(timePeriod.Seconds, 0);
        }

        /// <summary>
        /// Tests a constructor that takes a time period as a parameter
        /// </summary>
        /// <param name="periodSec"> Time period in seconds as a parameter of constructor </param>
        /// <param name="expectedH"> Expected hours </param>
        /// <param name="expectedM"> Expected minutes </param>
        /// <param name="expectedS"> Expected seconds </param>
        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 0, 0, 1)]
        [DataRow(100, 0, 1, 40)]
        [DataRow(5000, 1, 23, 20)]
        [DataRow(50000, 13, 53, 20)]
        [DataRow(123456, 34, 17, 36)]
        [DataRow(0, 0, 0, 0)]
        public void TimePeriod_Constructor_1param_periodSeconds(long periodSec,
                                                                long expectedH, long expectedM, long expectedS)
        {
            TimePeriod timePeriod = new TimePeriod(periodSeconds: periodSec);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, expectedS);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow("1:1:1" , 1, 1, 1)]
        [DataRow("23:59:59", 23, 59, 59)]
        [DataRow("20000:59:59", 20000, 59, 59)]
        [DataRow("12:45:", 12, 45, 0)]
        [DataRow("900::", 900, 0, 0)]
        [DataRow("::", 0, 0, 0)]
        public void TimePeriod_Constructor_1param_string(string timeP,
                                                        long expectedH, long expectedM, long expectedS)
        {
            TimePeriod timePeriod = new TimePeriod(timeP);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, expectedS);
        }
    }
    [TestClass]
    public class UnitTestsTimePeriodToString
    {

        [DataTestMethod, TestCategory("ToString")]
        [DataRow("1:1:1", "01:01:01")]
        [DataRow("23:59:59", "23:59:59")]
        [DataRow("2:59:59", "02:59:59")]
        [DataRow("12:25:", "12:25:00")]
        [DataRow("::", "00:00:00")]
        [DataRow("2500:59:59", "2500:59:59")]
        [DataRow("1242:25:59", "1242:25:59")]
        [DataRow("1111::", "1111:00:00")]
        public void TimePeriod_StringParams_ToString(string timePeriodS, string expectedToString)
        {
            TimePeriod timePeriod = new TimePeriod(timePeriodS);
            Assert.AreEqual(timePeriod.ToString(), expectedToString);
        }

        [DataTestMethod, TestCategory("ToString")]
        [DataRow(1, 1, 1, "01:01:01")]
        [DataRow(13, 15, 12, "13:15:12")]
        [DataRow(23, 59, 59, "23:59:59")]
        [DataRow(0, 59, 0, "00:59:00")]
        [DataRow(1000, 59, 0, "1000:59:00")]
        [DataRow(99999, 59, 0, "99999:59:00")]
        public void TimePeriod_params_ToString(long h, long m, long s, string expectedToString)
        {
            TimePeriod timePeriod = new TimePeriod(h, m, s);
            Assert.AreEqual(timePeriod.ToString(), expectedToString);

            TimePeriod timePeriod2 = new TimePeriod();
            Assert.AreEqual(timePeriod2.ToString(), "00:00:00");
        }
    }

    [TestClass]
    public class UnitTestsTimePeriodEquals
    {

        [DataTestMethod, TestCategory("Equals")]
        [DataRow("1:1:1", 1, 1, 1)]
        [DataRow("23:59:59", 23, 59, 59)]
        [DataRow("2:59:59", 2, 59, 59)]
        [DataRow("::", 0, 0, 0)]
        [DataRow("2000:59:59", 2000, 59, 59)]
        [DataRow("123456::", 123456, 0, 0)]
        public void TimePeriod_Equals_And_Overloaded_Operator(string timeS, long h, long m, long s)
        {
            TimePeriod time1 = new TimePeriod(timeS);
            TimePeriod time2 = new TimePeriod(h, m, s);
            TimePeriod time3 = new TimePeriod(9, 9, 9);

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
        [DataRow("1:1:1", "2:2:2")]
        [DataRow("23:59:58", "23:59:59")]
        [DataRow("2:59:59", "3::")]
        [DataRow("2:58:59", "2:59:58")]
        [DataRow("::", "::1")]
        [DataRow("123456:59:59", "123456:59:58")]
        [DataRow("11112:58:59", "11112:59:58")]
        public void TimePeriod_CompareTo_And_Overloaded_Operator(string timeS1, string timeS2)
        {
            TimePeriod time1 = new TimePeriod(timeS1);
            TimePeriod time2 = new TimePeriod(timeS2);

            TimePeriod time3 = new TimePeriod("::");
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
        [DataRow("1:1:1", "2:2:2", "03:03:03")]
        [DataRow("23:59:58", "23:59:59", "47:59:57")]
        [DataRow("::", "::1", "00:00:01")]
        [DataRow("12345:59:59", "12345:59:59", "24691:59:58")]
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
        [DataRow("2:2:2", "1:1:1", "01:01:01")]
        [DataRow("23:59:59", "00:59:59", "23:00:00")]
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
