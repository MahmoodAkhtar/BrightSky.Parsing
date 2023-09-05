using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record LtQMarkToken : SyntaxNode
{
    internal LtQMarkToken() : base("<?", new SyntaxNode[] { new LtToken(), new QMarkToken() })
    {
    }
    
    internal static readonly Parser<char, LtQMarkToken> Parser = String("<?").Map(_ => new LtQMarkToken());
}