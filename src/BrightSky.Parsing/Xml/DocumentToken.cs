using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record DocumentToken : SyntaxNode
{
    private DocumentToken(IEnumerable<SyntaxNode> children) : base(string.Empty, children)
    {
    }
    
    internal static readonly Parser<char, DocumentToken> Parser = 
        from decl in Try(XmlDeclToken.Parser).Optional()
        from root in NodeToken.Parser
        select new DocumentToken(
            OrganiseChildren(
                decl.HasValue ? decl.Value : Empty,
                root));
    
    private static IEnumerable<SyntaxNode> OrganiseChildren (SyntaxNode decl, SyntaxNode root)
        => new List<SyntaxNode> { decl, root };
}