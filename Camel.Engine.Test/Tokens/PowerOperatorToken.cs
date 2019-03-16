using Lepecki.Playground.Camel.Engine.Abstractions;
using Lepecki.Playground.Camel.Engine.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.Camel.Engine.Test.Tokens
{
    [TestFixture]
    public class PowerOperatorTokenTest
    {
        [TestCase(3, 4, ExpectedResult = 81, TestOf = typeof(PowerOperatorToken))]
        public double OperatorShouldPushCorrectResultToStack(double a, double b)
        {
            var stack = new Stack<double>();
            stack.Push(a);
            stack.Push(b);

            var operatorToken = new PowerOperatorToken();
            operatorToken.PushOrCalculate(stack);

            return Math.Round(stack.Pop(), 8);
        }
    }
}