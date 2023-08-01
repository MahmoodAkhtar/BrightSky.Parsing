namespace BrightSky.Parsing.Xml;

internal class QMarkToken : SyntaxNode
{
    internal QMarkToken() : base("?", Array.Empty<SyntaxNode>())
    {
    }
}