namespace BrightSky.Parsing.Xml;

public class DqToken : SyntaxNode
{
    public DqToken() : base("\"", Array.Empty<SyntaxNode>())
    {
    }
}