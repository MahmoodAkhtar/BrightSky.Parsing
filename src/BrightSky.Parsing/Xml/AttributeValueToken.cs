using BrightSky.Parsing.Internal;
using Pidgin;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

internal record AttributeValueToken : SyntaxNode
{
    internal AttributeValueToken(string value) 
        : base(value, new SyntaxNode[] { new DqToken(), new ValueToken(value), new DqToken() } )
    {
    }
    
    internal static readonly Parser<char, AttributeValueToken> Parser = 
        Token('"')
            .Then(new UntilFirstOfAnyString(new DqToken().Value))
            .Map(x => new AttributeValueToken(x));
}