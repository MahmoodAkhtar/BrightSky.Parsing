namespace BrightSky.Parsing.Xml;

public class LtForwardSlashToken : SyntaxNode
{
    public LtForwardSlashToken() : base("</", new SyntaxNode[] { new LtToken(), new ForwardSlashToken() })
    {
    }
}