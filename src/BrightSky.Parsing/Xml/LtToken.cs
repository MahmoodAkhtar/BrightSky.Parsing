using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class LtToken : SyntaxNode
{
    internal LtToken() : base("<", Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, LtToken> Parser = Char('<').ThenReturn(new LtToken());
}