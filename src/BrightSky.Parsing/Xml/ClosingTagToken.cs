namespace BrightSky.Parsing.Xml;

public class ClosingTagToken : SyntaxNode
{
    public ClosingTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
}