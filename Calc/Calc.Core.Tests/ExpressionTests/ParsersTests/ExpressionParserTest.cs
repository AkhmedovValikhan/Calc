using System;
using Calc.Core.Expressions.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Core.Tests.ExpressionTests.ParsersTests
{
    [TestClass]
    public class ExpressionParserTest
    {
        [TestMethod]
        public void AnalizeBracketsTest()
        {
            var wrongExpr = "2+2+(5*6))";
            var correctExpr = "2+2+(5*6)";
            var parser = new ExpressionParser();
            Assert.IsFalse(parser.AnalyzeBrackets(wrongExpr));
            Assert.IsTrue(parser.AnalyzeBrackets(correctExpr));
        }

        [TestMethod]
        public void ParseNumber()
        {
            var parser = new ExpressionParser();
            var number = "254,254";
            var startInd = 0;
            var numExpr = parser.ParseNumber(number,ref startInd);
            Assert.AreEqual(254.254, numExpr.Evaluate());
        }


    }
}
