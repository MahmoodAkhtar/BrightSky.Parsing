using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record DqToken : SyntaxNode
{
    internal DqToken() : base("\"", Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, DqToken> Parser = Char('"').ThenReturn(new DqToken());
}