namespace BrightSky.Parsing.Xml;

public class AttributeToken : SyntaxNode
{
    public AttributeToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
}