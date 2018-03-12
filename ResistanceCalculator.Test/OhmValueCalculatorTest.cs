using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResistanceCalculator.Test
{
    [TestClass]
    public class OhmValueCalculatorTest
    {
        private OhmValueCalculator _calculator = new OhmValueCalculator();
        [TestMethod]
        public void Calculator_CalculateOhmValue_ReturnsCorrectValue()
        {
            int expected = 223;
            int actual = _calculator.CalculateOhmValue("Red", "Red", "Orange", "Gold");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_GetToleranceValue_ReturnsCorrectValue()
        {
            double expected = 2;
            double actual = _calculator.GetToleranceValue("Red");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculator_GetOhmValueString_ReturnsCorrectValue()
        {
            string expected = "22000 ohms ± 5%";
            string actual = _calculator.GetOhmValueString(223, "Gold");

            Assert.AreEqual(expected, actual);
        }
    }
}
