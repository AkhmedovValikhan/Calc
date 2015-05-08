using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Calc.Core.Expressions.BinaryExpressions;

namespace Calc.Core.Expressions.Parsers
{
    public class ExpressionParser : IExpressionParser
    {
        public double ParseAndEvaluate(string expression)
        {
            expression = expression.Replace(" ", "");
            var operandList = new List<IExpression>();
            var operationList = new List<Char>();
            var resultsQueue = new Queue<IExpression>();
            if (!AnalyzeBrackets(expression))
                throw new Exception("Нарушен баланс скобок");
            var i = 0;

            while (i < expression.Length)
            {
                if (Char.IsDigit(expression[i]))
                {
                    operandList.Add(ParseNumber(expression, ref i));
                    continue;
                }
                if (BinaryExpressionParser.ContainsOperation(expression[i]))
                {
                    var operCh = expression[i++];
                    operationList.Add(operCh);
                    continue;
                }
                if (expression[i] == '(')
                {
                    throw new NotImplementedException();
                    continue;
                }
                if (expression[i] == ')')
                {
                    throw new NotImplementedException();
                    continue;
                }
                throw new Exception("Неопознаный оператор" + expression[i]);

            }

            for (var k =0;k < operationList.Count;  k++)
            {
                var op = operationList[k];
                if (op == '*')
                {
                    var expr = BinaryExpressionParser.Parse(op, operandList[k], operandList[k + 1]);
                    operationList.RemoveAt(k);
                    operandList[k] = expr;
                    operandList.RemoveAt(k+1);
                    
                }

                if (op == '/')
                {
                    var expr = BinaryExpressionParser.Parse(op, operandList[k], operandList[k + 1]);
                    operationList.RemoveAt(k);
                    operandList[k] = expr;
                    operandList.RemoveAt(k + 1);

                }
            }
            var j = 0;
            while (operandList.Count != 1)
            {
                var op = operationList[j];
                var expr = BinaryExpressionParser.Parse(op, operandList[j], operandList[j + 1]);
                operationList.RemoveAt(j);
                operandList[j] = expr;
                operandList.RemoveAt(j + 1);
            }
            var totalResult = operandList.Single().Evaluate();


            return totalResult;
        }

        public bool AnalyzeBrackets(string expression)
        {
            var bracketsBalance = 0;
            foreach (var ch in expression)
            {
                if (ch == '(')
                {
                    bracketsBalance ++;
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
    }
}
