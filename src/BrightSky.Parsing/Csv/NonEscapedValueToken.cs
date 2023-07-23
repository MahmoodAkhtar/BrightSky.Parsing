namespace BrightSky.Parsing.Csv;

public class NonEscapedValueToken : ValueToken
{
    public NonEscapedValueToken(string value = "") : base(value)
    {
    }
}