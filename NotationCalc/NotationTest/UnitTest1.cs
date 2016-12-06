using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotationCalc;
using NotationCalc.Notations;

namespace NotationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBin()
        {
            Bin t = new Bin();
            Assert.AreEqual("1", t.Add("0", "1"), "1 != 0 + 1");
            Assert.AreEqual("10", t.Add("1", "1"), "10 != 1 + 1");
            Assert.AreEqual("10100", t.Add("10011", "1"), "10100 != 10011 + 1");
            Assert.AreEqual("10011", t.Add("10100", "-1"), "10011 != 10100 + -1");
            Assert.AreEqual("-11", t.Add("-1", "-10"), "-11 != -1 + -1");
            Assert.AreEqual("-10", t.Add("1", "-11"), "-10 != 1 + -11");
            Assert.AreEqual("0", t.Sub("1", "1"), "0 != 1 - 1");
            Assert.AreEqual("-10", t.Sub("-1", "1"), "-10 != -1 - 1");
            Assert.AreEqual("10", t.Sub("1", "-1"), "10 != 1 - -1");
            Assert.AreEqual("-11", t.Sub("-100", "-1"), "-11 != -100 - -1");
        }

        [TestMethod]
        public void TestDec()
        {
            Dec t = new Dec();
            Assert.AreEqual("1", t.Add("0", "1"), "1 != 0 + 1");
            Assert.AreEqual("10", t.Add("9", "1"), "10 != 9 + 1");
            Assert.AreEqual("77900", t.Add("77899", "1"), "77900 != 77899 + 1");
            Assert.AreEqual("77899", t.Add("77900", "-1"), "77899 != 77900 + -1");
            Assert.AreEqual("-11", t.Add("-1", "-10"), "-11 != -1 + -10");
            Assert.AreEqual("-2", t.Add("3", "-5"), "-2 != 3 + -5");
            Assert.AreEqual("0", t.Sub("1", "1"), "0 != 1 - 1");
            Assert.AreEqual("-10", t.Sub("-1", "9"), "-10 != -1 - 9");
            Assert.AreEqual("10", t.Sub("1", "-9"), "10 != 1 - -9");
            Assert.AreEqual("-99", t.Sub("-100", "-1"), "-99 != -100 - -1");
        }

        [TestMethod]
        public void TestHex()
        {
            Hex t = new Hex();
            Assert.AreEqual("1", t.Add("0", "1"), "1 != 0 + 1");
            Assert.AreEqual("10", t.Add("1", "F"), "10 != 1 + F");
            Assert.AreEqual("1B100", t.Add("1B0FF", "1"), "1B100 != 1B0FF + 1");
            Assert.AreEqual("1B0FF", t.Add("1B100", "-1"), "1B0FF != 1B100 + -1");
            Assert.AreEqual("-1A", t.Add("-A", "-10"), "-1A != -A + -10");
            Assert.AreEqual("-F", t.Add("2", "-11"), "-F != 2 + -11");
            Assert.AreEqual("0", t.Sub("1", "1"), "0 != 1 - 1");
            Assert.AreEqual("-10", t.Sub("-1", "F"), "-10 != -1 - F");
            Assert.AreEqual("10", t.Sub("1", "-F"), "10 != 1 - -F");
            Assert.AreEqual("-FF", t.Sub("-100", "-1"), "-FF != -100 - -1");
        }

        [TestMethod]
        public void TestTer()
        {
            Ter t = new Ter();
            Assert.AreEqual("1", t.Add("0", "1"), "1 != 0 + 1");
            Assert.AreEqual("10", t.Add("1", "2"), "10 != 1 + 2");
            Assert.AreEqual("10100", t.Add("10022", "1"), "10100 != 10022 + 1");
            Assert.AreEqual("10022", t.Add("10100", "-1"), "10022 != 10100 + -1");
            Assert.AreEqual("-11", t.Add("-1", "-10"), "-11 != -1 + -10");
            Assert.AreEqual("-10", t.Add("1", "-11"), "-10 != 1 + -11");
            Assert.AreEqual("0", t.Sub("1", "1"), "0 != 1 - 1");
            Assert.AreEqual("-10", t.Sub("-1", "2"), "-10 != -1 - 2");
            Assert.AreEqual("10", t.Sub("1", "-2"), "10 != 1 - -2");
            Assert.AreEqual("-22", t.Sub("-100", "-1"), "-22 != -100 - -1");
        }

        [TestMethod]
        public void TestQuater()
        {
            Quater t = new Quater();
            Assert.AreEqual("1", t.Add("0", "1"), "1 != 0 + 1");
            Assert.AreEqual("10", t.Add("1", "3"), "10 != 1 + 3");
            Assert.AreEqual("10100", t.Add("10033", "1"), "10100 != 10033 + 1");
            Assert.AreEqual("10033", t.Add("10100", "-1"), "10033 != 10100 + -1");
            Assert.AreEqual("-11", t.Add("-1", "-10"), "-11 != -1 + -10");
            Assert.AreEqual("-10", t.Add("1", "-11"), "-10 != 1 + -11");
            Assert.AreEqual("0", t.Sub("1", "1"), "0 != 1 - 1");
            Assert.AreEqual("-10", t.Sub("-1", "3"), "-10 != -1 - 3");
            Assert.AreEqual("10", t.Sub("1", "-3"), "10 != 1 - -3");
            Assert.AreEqual("-33", t.Sub("-100", "-1"), "-33 != -100 - -1");
        }
    }
}
