using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Calc.Core.Expressions.BinaryExpressions;

namespace Calc.Core.Expressions.Parsers
{
    public class ExpressionParser : IExpressionParser
    {
        public ExpressionFactory Factory { get; set; }
        public int HighestPriority { get; set; }
        public List<IExpression> ExpressionList { get; set; } 

        public ExpressionParser()
        {
            Factory = new ExpressionFactory();
            RegisterBinaryExpressions();
        }

        private void RegisterBinaryExpressions()
        {
            Factory.RegisterBinaryExpression("+", typeof(AdditionBinaryExpression));
            Factory.RegisterBinaryExpression("-", typeof(SubtractionBinaryExpression));
            Factory.RegisterBinaryExpression("*", typeof(MultiplicationBinaryExpression));
            Factory.RegisterBinaryExpression("/", typeof(DivisionBinaryExpression));
        }

        public double ParseAndEvaluate(string expression)
        {
            expression = expression.Replace(" ", "");

            var highestPriority = 2;
            if (!AnalyzeBrackets(expression))
                throw new Exception("Unbalanced brackets");

            ExpressionList = Parse(expression);
            return Evaluate();



        }

        public List<IExpression> Parse(string expression)
        {
            var nesting = 0;
            var defaultHighestPriority = 10;//will be fix
            var i = 0;
            var exprList = new List<IExpression>();

            while (i < expression.Length)
            {
                if (Char.IsDigit(expression[i]))
                {
                    exprList.Add(ParseNumber(expression, ref i));
                    continue;
                }
                //Увлеичиваем уровень вложенность(nesting), тем самым увеличивая приоритет вложенных выражений
                if (expression[i] == '(')
                {
                    nesting++;
                    i++;
                    continue;
                }
                if (expression[i] == ')')
                {
                    nesting--;
                    i++;
                    continue;
                }

                var operation = ParseOperator(expression, ref i);
                if (operation != null)
                {
                    exprList.Add(operation);

                    operation.Priority += nesting * defaultHighestPriority;

                    if (operation.Priority > HighestPriority)
                        HighestPriority = operation.Priority;
                    continue;
                }

                throw new Exception(String.Format("Operator not found: \"{0}\"", expression[i]));

            }
            return exprList;
        }

        private double Evaluate()
        {
            var highestPriority = HighestPriority;
            while (highestPriority > 0)
            {
                var k = 0;

                while (k < ExpressionList.Count)
                {
                    if (ExpressionList[k].Priority == highestPriority)
                    {
                        var binExp = ExpressionList[k] as IBinaryExpression;
                        binExp.LeftOperand = ExpressionList[k-1];
                        binExp.RightOperand = ExpressionList[k + 1];
                        ExpressionList[k - 1] = binExp;
                        ExpressionList.RemoveRange(k,2);
                    }
                    else k++;
                }
                highestPriority--;
            }

            var totalResult = ExpressionList.Single().Evaluate();
            return totalResult;
        }

 
        public bool AnalyzeBrackets(string expression)
        {
            var bracketsBalance = 0;
            foreach (var ch in expression)
            {
                if (ch == '(')
                {
                    bracketsBalance++;
                    continue;
                }
                if (ch == ')')
                {
                    bracketsBalance--;
                }
            }

            return bracketsBalance == 0;
        }

        public IExpression ParseNumber(string expr, ref int index)
        {
            var result = new StringBuilder();
            while (index < expr.Length && (expr[index] == ',' || Char.IsDigit(expr[index])))
            {
                result.Append(expr[index++]);
            }
            return new NumberExpression(result.ToString());
        }

        public IBinaryExpression ParseOperator(string expr, ref int index)
        {
            var result = new StringBuilder();
            while (index < expr.Length && expr[index] != '(' && expr[index] != ')' && !Char.IsDigit(expr[index]))
            {
                result.Append(expr[index++]);
            }
            var restultStr = result.ToString();
            return Factory.ContainsOperation(restultStr) ? Factory.GetBinary(restultStr) : null;
        }
    }
}
