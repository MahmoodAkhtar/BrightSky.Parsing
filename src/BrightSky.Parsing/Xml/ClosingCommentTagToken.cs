namespace BrightSky.Parsing.Xml;

public class ClosingCommentTagToken : SyntaxNode
{
    public ClosingCommentTagToken() : base("-->", 
        new SyntaxNode[] { new HyphenToken(), new HyphenToken(), new GtToken() })
    {
    }
}