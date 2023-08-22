using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

public class TagToken : SyntaxNode
{
    internal TagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static readonly Parser<char, TagToken> Parser =
        from opening in OpeningTagToken.Parser
        from children in (
            from child in Try(NodeToken.Parser)
            select child).Many()
        from closing in ClosingTagToken.Parser
        select new TagToken(
            opening.Value,
            OrganiseChildren(
                opening,
                children as TagToken[] ?? children.ToArray(),
                closing));
    
    private static IEnumerable<SyntaxNode> OrganiseChildren (
        SyntaxNode opening,
        TagToken[] children,
        SyntaxNode closing)
    {
        var list = new List<SyntaxNode>
        {
            opening
        };

        if (children.Any())
            list.AddRange(DetermineTypeForTokens(children));
            
        list.Add(closing);
        
        return list;
    }
    
    private static IEnumerable<SyntaxNode> DetermineTypeForTokens(IEnumerable<TagToken> tokens)
        => tokens.Select(DetermineTypeForToken);

    private static SyntaxNode DetermineTypeForToken(SyntaxNode token)
        => token.Children.Any() 
            ? WhenBasedUponTypeOfLastChild(token) 
            : WhenNotHavingAnyChildren(token);

    private static SyntaxNode WhenBasedUponTypeOfLastChild(SyntaxNode token)
        => token.Children.Last() switch
        {
            ForwardSlashGtToken => new EmptyTagToken(token.Value, token.Children),
            ClosingTagToken => token,
            ClosingCommentTagToken => new CommentTagToken(token.Value, token.Children),
            _ => Empty
        };

    private static SyntaxNode WhenNotHavingAnyChildren(SyntaxNode token)
        => string.IsNullOrWhiteSpace(token.Value)
            ? new WhitespacesToken(token.Value)
            : new TagContentToken(token.Value);
}