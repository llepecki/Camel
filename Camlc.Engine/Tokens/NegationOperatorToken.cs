namespace Com.Lepecki.Playground.Camlc.Engine.Tokens
{
    public class NegationOperatorToken : UnaryOperatorToken
    {
        protected override decimal Calculate(decimal a)
        {
            return -a;
        }
    }
}