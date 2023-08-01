using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class GtToken : SyntaxNode
{
    internal GtToken() : base(">", Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, GtToken> Parser = Char('>').ThenReturn(new GtToken());
}