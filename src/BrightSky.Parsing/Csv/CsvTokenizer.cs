using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Csv;

public class CsvTokenizer : ITokenizer<CsvToken>
{
    private const char _comma = ',';
    private const char _doubleQuote = '"';
    private const char _cr = '\r';
    private const char _lf = '\n';
    private static readonly char[] _crlf = new[] { _cr, _lf };
    private static readonly char[] _exceptChars = new[] { _comma }.Union(_crlf).ToArray();
    
    private static readonly Parser<char, char> _commaDelimiter = Char(_comma);
    private static readonly Parser<char, char> _doubleQuoteDelimiter = Char('"');
    private static readonly Parser<char, char> _doubleQuoteEscape = Char('"');

    private static readonly Parser<char, char> _literalContent =
        AnyCharExcept(_exceptChars);
    
    public IEnumerable<CsvToken> Tokenize(string input)
    {
        var tokens = new List<CsvToken>();

        if (input is [' '])
            tokens.Add(new NonEscapedValueToken(input[0].ToString()));
        
        return tokens;
    }
}