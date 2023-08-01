namespace BrightSky.Parsing.Xml;

internal class WhitespacesToken : SyntaxNode
{
    internal WhitespacesToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}