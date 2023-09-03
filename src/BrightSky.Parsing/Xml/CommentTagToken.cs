using BrightSky.Parsing.Internal;
using Pidgin;

namespace BrightSky.Parsing.Xml;

internal record CommentTagToken : SyntaxNode
{
    internal CommentTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static readonly Parser<char, CommentTagToken> Parser = 
        from opening in OpeningCommentTagToken.Parser
        from content in new UntilLastOfAnyString(new ClosingCommentTagToken().Value)
        from closing in ClosingCommentTagToken.Parser
        select new CommentTagToken(
            content,
            OrganiseChildren(
                opening,
                new CommentTagContentToken(content),
                closing));
    
    private static IEnumerable<SyntaxNode> OrganiseChildren 
        (SyntaxNode opening, SyntaxNode content, SyntaxNode closing)
        => new List<SyntaxNode> { opening, content, closing };
}