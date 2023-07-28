namespace BrightSky.Parsing.Xml;

public class IdentifierToken : SyntaxNode
{
    public IdentifierToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}