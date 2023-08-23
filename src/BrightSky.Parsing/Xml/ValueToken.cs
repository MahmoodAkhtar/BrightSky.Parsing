namespace BrightSky.Parsing.Xml;

internal record ValueToken : SyntaxNode
{
    internal ValueToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}