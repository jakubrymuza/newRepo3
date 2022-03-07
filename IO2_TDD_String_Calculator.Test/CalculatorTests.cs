using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringCalculator.Test
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void CorrectEmptyString()
        {
            int expectedResult = 0;
            string argument = "";

            Assert.AreEqual(expectedResult, Calculator.Calculate(argument));
        }

        [TestMethod]
        public void CorrectSingleNumber()
        {
            int expectedResult = 15;
            string argument = "15";

            Assert.AreEqual(expectedResult, Calculator.Calculate(argument));
        }

        [TestMethod]
        public void CorrectTwoNumbersWithComma()
        {
            int expectedResult = 5;
            string argument = "3,2";

            Assert.AreEqual(expectedResult, Calculator.Calculate(argument));
        }

        [TestMethod]
        public void CorrectTwoNumbersWithNewLine()
        {
            int expectedResult = 9;
            string argument = "6\n3";

            Assert.AreEqual(expectedResult, Calculator.Calculate(argument));
        }

        [TestMethod]
        public void CorrectThreeNumbersWithNewLineAndComma()
        {
            int expectedResult = 15;
            string argument = "2,10\n3";

            Assert.AreEqual(expectedResult, Calculator.Calculate(argument));
        }

        [TestMethod]
        public void CorrectNegativeNumbers()
        {
            string argumentSingleNegative = "-5";


            Assert.ThrowsException<ArgumentException>(() => Calculator.Calculate(argumentSingleNegative));

            string argumentNegativeAndPositive = "10,-5";

            Assert.ThrowsException<ArgumentException>(() => Calculator.Calculate(argumentNegativeAndPositive));
        }

        [TestMethod]
        public void CorrectLargeNumbersIgnored()
        {
            int expectedResult = 5;
            string argument = "2,1005\n3";

            Assert.AreEqual(expectedResult, Calculator.Calculate(argument));
        }

        [TestMethod]
        public void CorrectNewSeparatorDefinition()
        {
            int expectedResult = 16;
            string argument = "//#2,10\n3#1";

            Assert.AreEqual(expectedResult, Calculator.Calculate(argument));
        }

        [TestMethod]
        public void CorrectMultiCharacterSeparator()
        {
            int expectedResult = 17;
            string argument = "//[!$]2!$10,5";

            Assert.AreEqual(expectedResult, Calculator.Calculate(argument));
        }
    }
}
