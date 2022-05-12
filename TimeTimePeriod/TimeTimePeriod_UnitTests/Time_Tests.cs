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
            Assert.AreEqual(time.Seconds, (byte)0);
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
            Assert.AreEqual(time.Minutes, (byte)0);
            Assert.AreEqual(time.Seconds, (byte)0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        public void Time_Constructor_0paramd()
        {
            Time time = new Time();
            Assert.AreEqual(time.Hours, (byte)0);
            Assert.AreEqual(time.Minutes, (byte)0);
            Assert.AreEqual(time.Seconds, (byte)0);
        }
    }
}
