namespace BrightSky.Parsing.Xml;

public class OpeningTagToken : SyntaxNode
{
    public OpeningTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
}