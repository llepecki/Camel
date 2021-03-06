using System;
using System.Collections.Generic;

namespace Com.Lepecki.Playground.Camlc.Engine.Tokens
{
    public abstract class OperatorToken : Token
    {
        protected abstract int ArgCount { get; }

        protected abstract decimal Calculate(decimal[] args);

        public override void PushOrCalculate(Stack<decimal> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            decimal[] args = new decimal[ArgCount];

            for (int i = ArgCount - 1; i >= 0; i--)
            {
                args[i] = stack.Pop();
            }

            decimal result = Calculate(args);
            stack.Push(result);
        }
    }
}
