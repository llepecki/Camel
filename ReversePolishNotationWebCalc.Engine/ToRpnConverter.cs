using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class ToRpnConverter : IToRpnConverter
    {
        private readonly IExprSieve _exprSieve;
        private readonly IInfixToPostfixConverter _infixToPostfixConverter;
        private readonly ITokenizer _tokenizer;

        public ToRpnConverter(
            IExprSieve exprSieve,
            IInfixToPostfixConverter infixToPostfixConverter,
            ITokenizer tokenizer)
        {
            _exprSieve = exprSieve ?? throw new ArgumentNullException(nameof(exprSieve));
            _infixToPostfixConverter = infixToPostfixConverter ?? throw new ArgumentNullException(nameof(infixToPostfixConverter));
            _tokenizer = tokenizer ?? throw new ArgumentNullException(nameof(tokenizer));
        }

        public RpnExpr Convert(string expr)
        {
            IReadOnlyCollection<string> infixExpr = _exprSieve.Sieve(expr);
            IReadOnlyCollection<string> postfixExpr = _infixToPostfixConverter.Convert(infixExpr);
            IEnumerable<Token> tokens = postfixExpr.Select(symbol => _tokenizer.Create(symbol));
            return new RpnExpr(tokens);
        }
    }
}
