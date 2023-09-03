using Pidgin;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

internal record TagContentToken : SyntaxNode
{
    internal TagContentToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, TagContentToken> Parser = 
        Token(c => c != '<').ManyString().Map(x => new TagContentToken(x));
}