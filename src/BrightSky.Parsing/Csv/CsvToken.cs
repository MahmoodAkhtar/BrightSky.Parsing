namespace BrightSky.Parsing.Csv;

public abstract class CsvToken : Token
{
    protected CsvToken(string value = "") : base(value)
    {
    }
}