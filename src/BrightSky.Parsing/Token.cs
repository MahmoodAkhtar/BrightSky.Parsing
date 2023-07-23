namespace BrightSky.Parsing;

public abstract class Token
{
    protected Token(string value)
    {
        Value = value;
    }

    public string Value { get; protected set; }
}