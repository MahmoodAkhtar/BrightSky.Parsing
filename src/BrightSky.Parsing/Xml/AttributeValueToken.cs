namespace BrightSky.Parsing.Xml;

public class AttributeValueToken : SyntaxNode
{
    public AttributeValueToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}