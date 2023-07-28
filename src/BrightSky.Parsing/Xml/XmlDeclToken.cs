namespace BrightSky.Parsing.Xml;

public class XmlDeclToken : SyntaxNode
{
    public XmlDeclToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
}