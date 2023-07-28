namespace BrightSky.Parsing.Xml;

public class EmptyTagToken : SyntaxNode
{
    public EmptyTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
}