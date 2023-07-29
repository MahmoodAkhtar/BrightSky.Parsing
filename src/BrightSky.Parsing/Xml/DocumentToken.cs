namespace BrightSky.Parsing.Xml;

public class DocumentToken : SyntaxNode
{
    public DocumentToken(IEnumerable<SyntaxNode> children) : base(string.Empty, children)
    {
    }
    
    internal static IEnumerable<SyntaxNode> OrganiseChildren (SyntaxNode decl, SyntaxNode root)
        => new List<SyntaxNode> { decl, root };
}