using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record QMarkGtToken : SyntaxNode
{
    private QMarkGtToken() : base("?>", new SyntaxNode[] { new QMarkToken(), new GtToken() })
    {
    }
    
    internal static readonly Parser<char, QMarkGtToken> Parser = String("?>").Map(_ => new QMarkGtToken());
}