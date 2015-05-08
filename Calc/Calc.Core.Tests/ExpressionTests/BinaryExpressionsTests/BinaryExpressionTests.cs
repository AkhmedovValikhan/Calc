using System;
using Calc.Core.Expressions;
using Calc.Core.Expressions.BinaryExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Core.Tests.ExpressionTests.BinaryExpressionsTests
{
    [TestClass]
    public class BinaryExpressionTests
    {
        [TestMethod]
        public void EvaluationTest()
        {
            var operand = new NumberExpression("10");
            var addition = new AdditionBinaryExpression
            {
                LeftOperand = operand,
                RightOperand = operand
            };

            var subraction = new SubtractionBinaryExpression
            {
                LeftOperand = operand,
                RightOperand = operand
            };

            var division = new DivisionBinaryExpression
            {
                LeftOperand = operand,
                RightOperand = operand
            };

            var multiplication = new MultiplicationBinaryExpression
            {
                LeftOperand = operand,
                RightOperand = operand
            };
            Assert.AreEqual(20, addition.Evaluate(), "Ошибка в вычилсении AdditionBinaryExpression");
            Assert.AreEqual(0, subraction.Evaluate(), "Ошибка в вычилсении SubtractionBinaryExpression");
            Assert.AreEqual(1, division.Evaluate(), "Ошибка в вычилсении DivisionBinaryExpression");
            Assert.AreEqual(100, multiplication.Evaluate(), "Ошибка в вычилсении MultiplicationBinaryExpression");
        }
    }
}
