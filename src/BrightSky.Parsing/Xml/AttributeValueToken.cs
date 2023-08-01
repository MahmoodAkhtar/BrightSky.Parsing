using Pidgin;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

internal class AttributeValueToken : SyntaxNode
{
    private AttributeValueToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, AttributeValueToken> Parser = 
        Token(c => c != '"').ManyString().Map(x => new AttributeValueToken(x));
}