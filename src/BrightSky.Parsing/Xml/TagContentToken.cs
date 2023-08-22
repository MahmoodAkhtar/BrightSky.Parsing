using Pidgin;
using static Pidgin.Parser<char>;

namespace BrightSky.Parsing.Xml;

internal record TagContentToken : SyntaxNode
{
    internal TagContentToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, TagToken> Parser = 
        Token(c => c != '<').ManyString().Map(x => new TagToken(x, Array.Empty<SyntaxNode>()));
}