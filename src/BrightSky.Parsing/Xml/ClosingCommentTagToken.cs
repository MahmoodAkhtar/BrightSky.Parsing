using Pidgin;

namespace BrightSky.Parsing.Xml;

internal class ClosingCommentTagToken : SyntaxNode
{
    internal ClosingCommentTagToken() : base("-->", 
        new SyntaxNode[] { new HyphenToken(), new HyphenToken(), new GtToken() })
    {
    }
    
    internal static readonly Parser<char, ClosingCommentTagToken> Parser = 
        from first in HyphenToken.Parser
        from second in HyphenToken.Parser
        from excMark in ExcMarkToken.Parser
        from closing in GtToken.Parser
        select new ClosingCommentTagToken();
}