namespace BrightSky.Parsing.Xml;

internal record CommentTagContentToken :SyntaxNode
{
    internal CommentTagContentToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}