using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResistanceCalculator.Test
{
    [TestClass]
    public class OhmValueCalculatorTest
    {
        private readonly OhmValueCalculator _calculator = new OhmValueCalculator();

        [TestMethod]
        public void Calculator_CalculateOhmValue_ReturnsCorrectValue1()
        {
            int expected = 22;
            int actual = _calculator.CalculateOhmValue("Red", "Red", "Orange", "Gold");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_CalculateOhmValue_ReturnsCorrectValue2()
        {
            int expected = 99;
            int actual = _calculator.CalculateOhmValue("White", "White", "White", "None");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_GetToleranceValue_ReturnsCorrectValue1()
        {
            double expected = 2;
            double actual = _calculator.GetToleranceValue("Red");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_GetToleranceValue_ReturnsCorrectValue2()
        {
            double expected = 20;
            double actual = _calculator.GetToleranceValue("None");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_GetMultiplierValue_ReturnsCorrectValue1()
        {
            double expected = 0;
            double actual = _calculator.GetMultiplierValue("Black");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_GetMultiplierValue_ReturnsCorrectValue2()
        {
            double expected = 9;
            double actual = _calculator.GetMultiplierValue("White");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_GetOhmValueString_ReturnsCorrectValue1()
        {
            string expected = "22000 ohms ± 5%";
            string actual = _calculator.GetOhmValueString(22, 3, 5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_GetOhmValueString_ReturnsCorrectValue2()
        {
            string expected = "99000000000 ohms ± 20%";
            string actual = _calculator.GetOhmValueString(99, 9, 20);

            Assert.AreEqual(expected, actual);
        }
    }
}
