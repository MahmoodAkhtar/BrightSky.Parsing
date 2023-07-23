namespace BrightSky.Parsing;

public interface ITokenizer<out TToken> where TToken : Token
{
    IEnumerable<TToken> Tokenize(string input);
}