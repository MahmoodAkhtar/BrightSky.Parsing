namespace BrightSky.Parsing.Csv;

public abstract class Token
{
    protected Token(string value)
    {
        Value = value;
    }

    public string Value { get; protected set; }
}