namespace BrightSky.Parsing.Xml;

public class QMarkGtToken : SyntaxNode
{
    public QMarkGtToken() : base("?>", new SyntaxNode[] { new QMarkToken(), new GtToken() })
    {
    }
}