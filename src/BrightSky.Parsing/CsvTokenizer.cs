using BrightSky.Parsing.Csv;

namespace BrightSky.Parsing;

public class CsvTokenizer : ITokenizer<CsvToken>
{
    public IEnumerable<CsvToken> Tokenize(string input)
    {
        var tokens = new List<CsvToken>();

        return tokens;
    }
}