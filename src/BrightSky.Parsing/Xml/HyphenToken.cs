using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record HyphenToken : SyntaxNode
{
    internal HyphenToken() : base("-", Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, HyphenToken> Parser = Char('-').ThenReturn(new HyphenToken());
}