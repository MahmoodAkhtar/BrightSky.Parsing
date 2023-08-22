namespace BrightSky.Parsing.Xml;

internal record ForwardSlashToken : SyntaxNode
{
    internal ForwardSlashToken() : base("/", Array.Empty<SyntaxNode>())
    {
    }
}