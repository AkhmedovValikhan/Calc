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
            var additionInstance = BinaryExpressionParser.Parse('+', new NumberExpression("2"), new NumberExpression("2"));
            var subtractionInstance = BinaryExpressionParser.Parse('-', new NumberExpression("2"), new NumberExpression("2"));
            var divisionInstance = BinaryExpressionParser.Parse('/', new NumberExpression("2"), new NumberExpression("2"));
            Assert.AreEqual(typeof(AdditionBinaryExpression), additionInstance.GetType(), "Не возвращает инстанс AdditionBinaryExpression");
            Assert.AreEqual(typeof(SubtractionBinaryExpression), subtractionInstance.GetType(), "Не возвращает инстанс SubtractionBinaryExpression");
            Assert.AreEqual(typeof(DivisionBinaryExpression), divisionInstance.GetType(), "Не возвращает инстанс DivisionBinaryExpression");
        }
        [TestMethod]
        public void ContainsOperatorTest()
        {
            Assert.IsFalse(BinaryExpressionParser.ContainsOperation('%'));
            Assert.IsTrue(BinaryExpressionParser.ContainsOperation('-'));
        }
    }
}
