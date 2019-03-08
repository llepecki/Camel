using Lepecki.Playground.ReversePolishNotationWebCalc.Engine.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lepecki.Playground.ReversePolishNotationWebCalc.Engine
{
    public class ExprSieve : IExprSieve
    {
        private static readonly Regex TokenRegex = new Regex(Patterns.AnyToken, RegexOptions.IgnoreCase);

        public IReadOnlyCollection<string> Sieve(string expr)
        {
            Match match = TokenRegex.Match(expr);
            return IdentifyOperandsAndOperators(match).ToArray();
        }

        private IEnumerable<string> IdentifyOperandsAndOperators(Match match)
        {
            while (match.Success)
            {
                string exprComponent = match.Value.Trim().ToLower();
                match = match.NextMatch();
                yield return exprComponent;
            }
        }
    }
}
