namespace BrightSky.Parsing.Xml;

internal record QMarkToken : SyntaxNode
{
    internal QMarkToken() : base("?", Array.Empty<SyntaxNode>())
    {
    }
}