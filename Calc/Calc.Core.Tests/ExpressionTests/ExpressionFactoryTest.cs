using System;
using Calc.Core.Expressions;
using Calc.Core.Expressions.BinaryExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Core.Tests.ExpressionTests
{
    [TestClass]
    public class ExpressionFactoryTest
    {

        [TestMethod]
        public void GetNumberExpressionTest()
        {
            var factory = new ExpressionFactory();
            var num = "225,155";
            var numberInstance = factory.GetNumber(num);
            Assert.IsInstanceOfType(numberInstance, typeof(NumberExpression), "Не возвращает инстанс NumberExpression");
        }

        [TestMethod]
        public void GetBinaryExpressionTest()
        {
            var factory = new ExpressionFactory();
            factory.RegisterBinaryExpression("+", typeof(AdditionBinaryExpression));
            factory.RegisterBinaryExpression("-", typeof(SubtractionBinaryExpression));

            var additionInstance = factory.GetBinary("+");

            var subtractionInstance = factory.GetBinary("-");

            Assert.IsInstanceOfType(additionInstance, typeof(AdditionBinaryExpression), "Не возвращает инстанс AdditionBinaryExpression");
            Assert.IsInstanceOfType(subtractionInstance, typeof(SubtractionBinaryExpression), "Не возвращает инстанс SubtractionBinaryExpression");
        }
    }
}
