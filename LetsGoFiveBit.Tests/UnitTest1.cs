using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsGoFiveBit.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OctalToDecmial()
        {
            BasedNumber _from = new BasedNumber(8, "37");
            BasedNumber _to = _from.ConvertToBase(10);

            Assert.IsTrue(_to.NumberBase == 10);
            Assert.IsTrue(_to.Value == "31");
        }

        [TestMethod]
        public void HexToDemical()
        {
            BasedNumber _from = new BasedNumber(16, "37");
            BasedNumber _to = _from.ConvertToBase(10);

            Assert.IsTrue(_to.NumberBase == 10);
            Assert.IsTrue(_to.Value == "55");
        }

        [TestMethod]
        public void HexToDemical2()
        {
            BasedNumber _from = new BasedNumber(16, "FF");
            BasedNumber _to = _from.ConvertToBase(10);

            Assert.IsTrue(_to.NumberBase == 10);
            Assert.IsTrue(_to.Value == "255");
        }

        [TestMethod]
        public void HeximalToDemical()
        {
            BasedNumber _from = new BasedNumber(16, "3F3.4");
            BasedNumber _to = _from.ConvertToBase(10);

            Assert.IsTrue(_to.NumberBase == 10);
            Assert.IsTrue(_to.Value == "1011.25");
        }

        [TestMethod]
        public void DeimcalToDemical()
        {
            BasedNumber _from = new BasedNumber(10, "10.09");
            BasedNumber _to = _from.ConvertToBase(10);

            Assert.IsTrue(_to.NumberBase == 10);
            Assert.IsTrue(_to.Value == "10.09");
        }

        [TestMethod]
        public void BaseFiveToDecimal()
        {
            BasedNumber _from = new BasedNumber(5, "32");
            BasedNumber _to = _from.ConvertToBase(10);

            Assert.IsTrue(_to.NumberBase == 10);
            Assert.IsTrue(_to.Value == "17");
        }

        [TestMethod]
        public void BaseThreeToDecimal()
        {
            BasedNumber _from = new BasedNumber(3, "12");
            BasedNumber _to = _from.ConvertToBase(10);

            Assert.IsTrue(_to.NumberBase == 10);
            Assert.IsTrue(_to.Value == "5");
        }

        [TestMethod]
        public void BaseThirtySixToDecimal()
        {
            BasedNumber _from = new BasedNumber(36, "Z");
            BasedNumber _to = _from.ConvertToBase(10);

            Assert.IsTrue(_to.NumberBase == 10);
            Assert.IsTrue(_to.Value == "36");
        }


        [TestMethod]
        public void BaseTenToBaseThree()
        {
            BasedNumber _from = new BasedNumber(10, "38");
            BasedNumber _to = _from.ConvertToBase(3);

            Assert.IsTrue(_to.NumberBase == 3);
            Assert.IsTrue(_to.Value == "1102");
        }

        [TestMethod]
        public void BaseFiveToBaseThree()
        {
            BasedNumber _from = new BasedNumber(5, "32");
            BasedNumber _to = _from.ConvertToBase(3);

            Assert.IsTrue(_to.NumberBase == 3);
            Assert.IsTrue(_to.Value == "122");
        }

        [TestMethod]
        public void BaseNineToBaseFifteen()
        {
            BasedNumber _from = new BasedNumber(9, "203");
            BasedNumber _to = _from.ConvertToBase(15);

            Assert.IsTrue(_to.NumberBase == 15);
            Assert.IsTrue(_to.Value == "B0");
        }

        [TestMethod]
        public void BaseTwoToBaseSixteen()
        {
            BasedNumber _from = new BasedNumber(2, "1010");
            BasedNumber _to = _from.ConvertToBase(16);

            Assert.IsTrue(_to.NumberBase == 16);
            Assert.IsTrue(_to.Value == "A");
        }

        [TestMethod]
        public void BaseSixteenToBaseTwo()
        {
            BasedNumber _from = new BasedNumber(16, "A");
            BasedNumber _to = _from.ConvertToBase(2);

            Assert.IsTrue(_to.NumberBase == 2);
            Assert.IsTrue(_to.Value == "1010");
        }


        // operators
        [TestMethod]
        public void DecimalAdditionBaseTen()
        {
            BasedNumber _o1 = new BasedNumber(10, "15.5");
            BasedNumber _o2 = new BasedNumber(10, "12");
            BasedNumber _o3 = _o1 + _o2;

            Assert.IsTrue(_o3.NumberBase == 10);
            Assert.IsTrue(_o3.Value == "27.5");
        }


        [TestMethod]
        public void DecimalAdditionBaseThree()
        {
            BasedNumber _o1 = new BasedNumber(3, "12");
            BasedNumber _o2 = new BasedNumber(3, "12");
            BasedNumber _o3 = _o1 + _o2;

            Assert.IsTrue(_o3.NumberBase == 3);
            Assert.IsTrue(_o3.Value == "101");
        }

        [TestMethod]
        public void DecimalAdditionBaseThreeAndBaseTen()
        {
            BasedNumber _o1 = new BasedNumber(3, "12");
            BasedNumber _o2 = new BasedNumber(10, "5");
            BasedNumber _o3 = _o1 + _o2;

            Assert.IsTrue(_o3.NumberBase == 3);
            Assert.IsTrue(_o3.Value == "101");
        }


        [TestMethod]
        public void DecimalSubtract()
        {
            BasedNumber _o1 = new BasedNumber(10, "15.5");
            BasedNumber _o2 = new BasedNumber(10, "12");
            BasedNumber _o3 = _o1 - _o2;

            Assert.IsTrue(_o3.NumberBase == 10);
            Assert.IsTrue(_o3.Value == "3.5");
        }

        [TestMethod]
        public void DecimalMultiply()
        {
            BasedNumber _o1 = new BasedNumber(10, "15.5");
            BasedNumber _o2 = new BasedNumber(10, "12");
            BasedNumber _o3 = _o1 * _o2;

            Assert.IsTrue(_o3.NumberBase == 10);
            Assert.IsTrue(_o3.Value == "186");
        }

        [TestMethod]
        public void DecimalDivide()
        {
            BasedNumber _o1 = new BasedNumber(10, "15.5");
            BasedNumber _o2 = new BasedNumber(10, "12");
            BasedNumber _o3 = _o1 / _o2;

            Assert.IsTrue(_o3.NumberBase == 10);
            Assert.IsTrue(_o3.Value == "1.29166666666667");
        }

    }
}
