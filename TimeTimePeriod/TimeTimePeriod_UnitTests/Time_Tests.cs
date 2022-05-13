using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTimePeriod_Lib;

namespace TimeTimePeriod_UnitTests
{
    [TestClass]
    public class UnitTestsTimeConstructors
    {
        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataRow(13, 15, 12, 13, 15, 12)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(0, 59, 0, 0, 59, 0)]
        public void Time_Constructor_3params(byte h, byte m, byte s, 
                                                byte expectedH, byte expectedM, byte expectedS)
        {
            Time time = new Time(h, m, s);
            Assert.AreEqual(time.Hours, expectedH);
            Assert.AreEqual(time.Minutes, expectedM);
            Assert.AreEqual(time.Seconds, expectedS);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 1, 1, 1)]
        [DataRow(13, 15, 13, 15)]
        [DataRow(23, 59, 23, 59)]
        [DataRow(0, 59, 0, 59)]
        public void Time_Constructor_2params(byte h, byte m,
                                               byte expectedH, byte expectedM)
        {
            Time time = new Time(h, m);
            Assert.AreEqual(time.Hours, expectedH);
            Assert.AreEqual(time.Minutes, expectedM);
            Assert.AreEqual(time.Seconds, 0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 1)]
        [DataRow(13, 13)]
        [DataRow(23, 23)]
        [DataRow(0, 0)]
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
        public void Time_Constructor_1param_string(string timeP,
                                                        long expectedH, long expectedM, long expectedS)
        {
            TimePeriod timePeriod = new TimePeriod(timeP);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, expectedS);
        }
    }
}
