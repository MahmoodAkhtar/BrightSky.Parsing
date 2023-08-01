namespace BrightSky.Parsing.Xml;

internal class ForwardSlashToken : SyntaxNode
{
    internal ForwardSlashToken() : base("/", Array.Empty<SyntaxNode>())
    {
    }
}