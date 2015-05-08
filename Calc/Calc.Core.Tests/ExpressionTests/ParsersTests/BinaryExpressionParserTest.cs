using System;
using Calc.Core.Expressions;
using Calc.Core.Expressions.BinaryExpressions;
using Calc.Core.Expressions.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Core.Tests.ExpressionTests.ParsersTests
{
    [TestClass]
    public class BinaryExpressionParserTest
    {
        [TestMethod]
        public void ParseTest()
        {
            var operand = new NumberExpression("2");
            var additionInstance = BinaryExpressionParser.Parse('+');
            additionInstance.LeftOperand = operand;
            additionInstance.RightOperand = operand;

            var subtractionInstance = BinaryExpressionParser.Parse('-');
            subtractionInstance.LeftOperand = operand;
            subtractionInstance.RightOperand = operand;

            var divisionInstance = BinaryExpressionParser.Parse('/');
            divisionInstance.LeftOperand = operand;
            divisionInstance.RightOperand = operand;

            var multiplicationInstance = BinaryExpressionParser.Parse('*');
            multiplicationInstance.LeftOperand = operand;
            multiplicationInstance.RightOperand = operand;

            Assert.AreEqual(typeof(AdditionBinaryExpression), additionInstance.GetType(), "Не возвращает инстанс AdditionBinaryExpression");
            Assert.AreEqual(typeof(SubtractionBinaryExpression), subtractionInstance.GetType(), "Не возвращает инстанс SubtractionBinaryExpression");
            Assert.AreEqual(typeof(DivisionBinaryExpression), divisionInstance.GetType(), "Не возвращает инстанс DivisionBinaryExpression");
            Assert.AreEqual(typeof(MultiplicationBinaryExpression), multiplicationInstance.GetType(), "Не возвращает инстанс MultiplicationBinaryExpression");
        }

        [TestMethod]
        public void ContainsOperatorTest()
        {
            Assert.IsFalse(BinaryExpressionParser.ContainsOperation('%'));
            Assert.IsTrue(BinaryExpressionParser.ContainsOperation('-'));
        }
    }
}
