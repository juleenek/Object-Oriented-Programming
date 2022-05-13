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
}
