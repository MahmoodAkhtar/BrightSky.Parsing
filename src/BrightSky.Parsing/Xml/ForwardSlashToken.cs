namespace BrightSky.Parsing.Xml;

public class ForwardSlashToken : SyntaxNode
{
    public ForwardSlashToken() : base("/", Array.Empty<SyntaxNode>())
    {
    }
}