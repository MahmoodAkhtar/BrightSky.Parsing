namespace BrightSky.Parsing.Xml;

public class QMarkToken : SyntaxNode
{
    public QMarkToken() : base("?", Array.Empty<SyntaxNode>())
    {
    }
}