﻿using System;
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
            var result = calc.Calculate(expression);
            Assert.AreEqual(6.0, result);
        }
    }
}
