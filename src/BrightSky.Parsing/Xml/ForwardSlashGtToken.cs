namespace BrightSky.Parsing.Xml;

public class ForwardSlashGtToken : SyntaxNode
{
    public ForwardSlashGtToken() : base("/>", new SyntaxNode[] { new ForwardSlashToken(), new GtToken() })
    {
    }
}