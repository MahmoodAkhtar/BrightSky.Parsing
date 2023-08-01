using Pidgin;

namespace BrightSky.Parsing.Xml;

internal class CommentTagToken : SyntaxNode
{
    internal CommentTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static readonly Parser<char, TagToken> Parser = 
        from comment in CommentTagContentToken.Parser
        select new TagToken(
            comment.Value,
            OrganiseChildren(
                new OpeningCommentTagToken(),
                comment,
                new ClosingCommentTagToken()));
    
    private static IEnumerable<SyntaxNode> OrganiseChildren 
        (SyntaxNode opening, SyntaxNode content, SyntaxNode closing)
        => new List<SyntaxNode> { opening, content, closing };
}