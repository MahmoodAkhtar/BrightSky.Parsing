namespace BrightSky.Parsing.Xml;

public class OpeningCommentTagToken : SyntaxNode
{
    public OpeningCommentTagToken() : base("<!--", 
        new SyntaxNode[] { new LtToken(), new ExcMarkToken(), new HyphenToken(), new HyphenToken() })
    {
    }
}