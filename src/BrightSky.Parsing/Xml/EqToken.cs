namespace BrightSky.Parsing.Xml;

public class EqToken : SyntaxNode
{
    public EqToken() : base("=", Array.Empty<SyntaxNode>())
    {
    }
}