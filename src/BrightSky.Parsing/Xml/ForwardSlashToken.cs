using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record ForwardSlashToken : SyntaxNode
{
    internal ForwardSlashToken() : base("/", Array.Empty<SyntaxNode>())
    {
    }
    
    internal static readonly Parser<char, ForwardSlashToken> Parser = Char('/').ThenReturn(new ForwardSlashToken());
}