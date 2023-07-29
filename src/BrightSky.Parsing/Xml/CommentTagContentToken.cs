namespace BrightSky.Parsing.Xml;

public class CommentTagContentToken :SyntaxNode
{
    public CommentTagContentToken(string value) : base(value, Array.Empty<SyntaxNode>())
    {
    }
}