namespace BrightSky.Parsing.Xml;

internal record WhitespacesToken : SyntaxNode
{
    internal WhitespacesToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}