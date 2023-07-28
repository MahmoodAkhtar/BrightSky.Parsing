namespace BrightSky.Parsing.Xml;

public class LtQMarkToken : SyntaxNode
{
    public LtQMarkToken() : base("<?", new SyntaxNode[] { new LtToken(), new QMarkToken() })
    {
    }
}