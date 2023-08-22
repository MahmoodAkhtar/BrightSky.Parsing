using Pidgin;

namespace BrightSky.Parsing.Xml;

internal record OpeningCommentTagToken : SyntaxNode
{
    internal OpeningCommentTagToken() : base("<!--", 
        new SyntaxNode[] { new LtToken(), new ExcMarkToken(), new HyphenToken(), new HyphenToken() })
    {
    }
    
    internal static readonly Parser<char, OpeningCommentTagToken> Parser = 
        from opening in LtToken.Parser
        from excMark in ExcMarkToken.Parser
        from first in HyphenToken.Parser
        from second in HyphenToken.Parser
        select new OpeningCommentTagToken();
}