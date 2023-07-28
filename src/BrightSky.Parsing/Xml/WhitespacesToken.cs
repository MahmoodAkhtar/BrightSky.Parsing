namespace BrightSky.Parsing.Xml;

public class WhitespacesToken : SyntaxNode
{
    public WhitespacesToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}