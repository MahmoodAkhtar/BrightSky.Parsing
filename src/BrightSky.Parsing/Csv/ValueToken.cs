namespace BrightSky.Parsing.Csv;

public abstract class ValueToken : CsvToken
{
    protected ValueToken(string value = "") : base(value)
    {
    }
}