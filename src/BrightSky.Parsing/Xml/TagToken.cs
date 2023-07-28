namespace BrightSky.Parsing.Xml;

public class TagToken : SyntaxNode
{
    public TagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
}