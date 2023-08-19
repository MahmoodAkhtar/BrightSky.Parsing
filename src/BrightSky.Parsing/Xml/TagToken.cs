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
        from before in (
            from ws in Whitespace
            select ws).Many()
        from children in (
            from child in Try(NodeToken.Parser)
            select child).Many()
        from after in (
            from ws in Whitespace
            select ws).Many()
        from closing in ClosingTagToken.Parser
        select new TagToken(
            opening.Value,
            OrganiseChildren(
                opening,
                before as char[] ?? before.ToArray(),
                children as TagToken[] ?? children.ToArray(),
                after as char[] ?? after.ToArray(),
                closing));
    
    private static IEnumerable<SyntaxNode> OrganiseChildren (
        SyntaxNode opening,
        char[] before,
        TagToken[] children,
        char[] after,
        SyntaxNode closing)
    {
        var list = new List<SyntaxNode>
        {
            opening
        };

        if (before.Any())
            list.Add(new WhitespacesToken(new string(before)));

        if (children.Any())
            list.AddRange(DetermineTypeForTokens(children));
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));
            
        list.Add(closing);
        
        return list;
    }
    
    private static IEnumerable<SyntaxNode> DetermineTypeForTokens(IEnumerable<TagToken> tokens)
        => tokens.Select(DetermineTypeForToken);

    private static SyntaxNode DetermineTypeForToken(SyntaxNode token)
    {
        if (token.Children.Any())
        {
            return TryWhenFirstChildIsXmlDeclToken(token, out var output) 
                ? output 
                : OrTryBasedUponTypeOfLastChild(token);
        }

        return WhenNotHavingAnyChildren(token);
    }

    private static bool TryWhenFirstChildIsXmlDeclToken(SyntaxNode parent, out SyntaxNode output)
    {
        output = new DocumentToken(Array.Empty<SyntaxNode>());
        if (parent.Children.First() is not XmlDeclToken) return false;
        output = new DocumentToken(parent.Children);
        return true;
    }

    private static SyntaxNode OrTryBasedUponTypeOfLastChild(SyntaxNode token)
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