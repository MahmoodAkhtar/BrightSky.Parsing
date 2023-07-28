namespace BrightSky.Parsing.Xml;

public class XmlNameToken : SyntaxNode
{
    public XmlNameToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}