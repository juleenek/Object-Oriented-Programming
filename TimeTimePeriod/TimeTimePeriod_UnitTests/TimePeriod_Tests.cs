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
        [DataRow((byte)1, (byte)1, (byte)1, (byte)1, (byte)1, (byte)1)]
        [DataRow((byte)13, (byte)15, (byte)12, (byte)13, (byte)15, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)59, (byte)59)]
        [DataRow((byte)123, (byte)15, (byte)12, (byte)123, (byte)15, (byte)12)]
        [DataRow((byte)200, (byte)59, (byte)59, (byte)200, (byte)59, (byte)59)]
        [DataRow((byte)0, (byte)59, (byte)0, (byte)0, (byte)59, (byte)0)]
        public void TimePeriod_Constructor_3params(byte h, byte m, byte s,
                                                byte expectedH, byte expectedM, byte expectedS)
        {
            TimePeriod timePeriod = new TimePeriod(h, m, s);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, expectedS);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)1, (byte)1, (byte)1, (byte)1)]
        [DataRow((byte)13, (byte)15, (byte)13, (byte)15)]
        [DataRow((byte)23, (byte)59, (byte)23, (byte)59)]
        [DataRow((byte)123, (byte)59, (byte)123, (byte)59)]
        [DataRow((byte)200, (byte)59, (byte)200, (byte)59)]
        [DataRow((byte)0, (byte)59, (byte)0, (byte)59)]
        public void TimePeriod_Constructor_2params(byte h, byte m,
                                               byte expectedH, byte expectedM)
        {
            TimePeriod timePeriod = new TimePeriod(h, m);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, expectedM);
            Assert.AreEqual(timePeriod.Seconds, (byte)0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow((byte)1, (byte)1)]
        [DataRow((byte)13, (byte)13)]
        [DataRow((byte)23, (byte)23)]
        [DataRow((byte)123, (byte)123)]
        [DataRow((byte)200, (byte)200)]
        [DataRow((byte)0, (byte)0)]
        public void TimePeriod_Constructor_1param(byte h, byte expectedH)
        {
            TimePeriod timePeriod = new TimePeriod(hours: h);
            Assert.AreEqual(timePeriod.Hours, expectedH);
            Assert.AreEqual(timePeriod.Minutes, (byte)0);
            Assert.AreEqual(timePeriod.Seconds, (byte)0);
        }

        [DataTestMethod, TestCategory("Constructors")]
        public void TimePeriod_Constructor_0paramd()
        {
            TimePeriod timePeriod = new TimePeriod();
            Assert.AreEqual(timePeriod.Hours, (byte)0);
            Assert.AreEqual(timePeriod.Minutes, (byte)0);
            Assert.AreEqual(timePeriod.Seconds, (byte)0);
        }
    }
}
