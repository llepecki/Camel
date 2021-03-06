using System;
using System.Globalization;
using Com.Lepecki.Playground.Camlc.Engine.Abstractions;
using Com.Lepecki.Playground.Camlc.Engine.Tokens;

namespace Com.Lepecki.Playground.Camlc.Engine
{
    public class Tokenizer : ITokenizer
    {
        public Token Create(TokenDescriptor tokenDescriptor)
        {
            if (tokenDescriptor.IsOperand)
            {
                return new OperandToken(decimal.Parse(tokenDescriptor.ToString(), CultureInfo.InvariantCulture));
            }

            if (tokenDescriptor.IsOperator)
            {
                switch (tokenDescriptor.ToString())
                {
                    case Operators.Add: return new AddOperatorToken();
                    case Operators.Subtract: return new SubtractOperatorToken();
                    case Operators.Multiply: return new MultiplyOperatorToken();
                    case Operators.Divide: return new DivideOperatorToken();
                    case Operators.Power: return new PowerOperatorToken();
                    case Operators.Negate: return new NegationOperatorToken();

                    default:
                        throw new ArgumentException($"Unknown operator: {tokenDescriptor}");
                }
            }

            if (tokenDescriptor.IsLeftParenthesis || tokenDescriptor.IsRightParenthesis)
            {
                throw new InvalidOperationException("A parenthesis can't be turned into a token");
            }

            throw new InvalidOperationException("Invalid token descriptor");
        }
    }
}
