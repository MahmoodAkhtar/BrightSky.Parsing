namespace BrightSky.Parsing.Csv;

public class CrLfToken : CsvToken
{
    public CrLfToken() : base(new CrToken().Value + new LfToken().Value)
    {
    }
}