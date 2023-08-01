using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class LtForwardSlashToken : SyntaxNode
{
    internal LtForwardSlashToken() : base("</", new SyntaxNode[] { new LtToken(), new ForwardSlashToken() })
    {
    }
    
    internal static readonly Parser<char, LtForwardSlashToken> Parser = String("</")
        .Map(_ => new LtForwardSlashToken());
}