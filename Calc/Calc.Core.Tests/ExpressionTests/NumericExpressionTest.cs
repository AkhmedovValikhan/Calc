using System;
using Calc.Core.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Core.Tests.ExpressionTests
{
    [TestClass]
    public class NumberExpressionTest
    {
        [TestMethod]
        public void EvaluateTest()
        {
            var num = "225,155";
            var expr = new NumberExpression(num);
            Assert.AreEqual(225.155, expr.Evaluate(), "Ошибка в вычилсении NumberExpression");
        }
    }
}
