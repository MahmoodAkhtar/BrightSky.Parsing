namespace BrightSky.Parsing.Csv;

public class EscapedValueToken : ValueToken
{
    public static DoubleQuoteToken Quote => new DoubleQuoteToken();
    public new NonEscapedValueToken Value;

    public EscapedValueToken(string value = "") : base(value)
    {
        Value = new NonEscapedValueToken(value);
    }
}