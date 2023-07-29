namespace BrightSky.Parsing.Xml;

public class HyphenToken : SyntaxNode
{
    public HyphenToken() : base("-", Array.Empty<SyntaxNode>())
    {
    }
}