namespace BrightSky.Parsing.Xml;

public class TagContentToken : SyntaxNode
{
    public TagContentToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}