using System;
using Calc.Core.Expressions.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Core.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void SimpleAdditionTest()
        {
            var calc = new Calculator();
            var expression = "1+2+3";
            var result = calc.Calculate(expression, new ExpressionParser());
            Assert.AreEqual(6.0, result);
        }

        [TestMethod]
        public void SimpleSubtractionTest()
        {
            var calc = new Calculator();
            var expression = "6-2-3";
            var result = calc.Calculate(expression, new ExpressionParser());
            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void SimpleDivisionTest()
        {
            var calc = new Calculator();
            var expression = "4 + 6/3 + 10";
            var result = calc.Calculate(expression, new ExpressionParser());
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void SimpleMultiplicationTest()
        {
            var calc = new Calculator();
            var expression = "4 + 6*3/1 - 10";
            var result = calc.Calculate(expression, new ExpressionParser());
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void ComplexTest()
        {
            var calc = new Calculator();
            var expression = "20 + (10 * (10-5))";
            var result = calc.Calculate(expression, new ExpressionParser());
            Assert.AreEqual(70, result);
        }
    }
}
