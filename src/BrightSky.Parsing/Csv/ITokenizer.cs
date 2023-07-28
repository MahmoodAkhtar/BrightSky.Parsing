namespace BrightSky.Parsing.Csv;

public interface ITokenizer<out TToken> where TToken : Token
{
    IEnumerable<TToken> Tokenize(string input);
}