using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record EqToken : SyntaxNode
{
    private EqToken() : base("=", Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, EqToken> Parser = Char('=').ThenReturn(new EqToken());
}