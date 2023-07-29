namespace BrightSky.Parsing.Xml;

public class CommentTagToken : SyntaxNode
{
    public CommentTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static IEnumerable<SyntaxNode> OrganiseChildren 
        (SyntaxNode opening, SyntaxNode content, SyntaxNode closing)
        => new List<SyntaxNode> { opening, content, closing };
}