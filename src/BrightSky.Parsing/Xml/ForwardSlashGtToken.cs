using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class ForwardSlashGtToken : SyntaxNode
{
    private ForwardSlashGtToken() : base("/>", new SyntaxNode[] { new ForwardSlashToken(), new GtToken() })
    {
    }
    
    internal static readonly Parser<char, ForwardSlashGtToken> Parser = String("/>")
        .Map(_ => new ForwardSlashGtToken());
}