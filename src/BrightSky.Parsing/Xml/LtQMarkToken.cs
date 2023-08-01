using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class LtQMarkToken : SyntaxNode
{
    private LtQMarkToken() : base("<?", new SyntaxNode[] { new LtToken(), new QMarkToken() })
    {
    }
    
    internal static readonly Parser<char, LtQMarkToken> Parser = String("<?").Map(_ => new LtQMarkToken());
}