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
            list.AddRange(TypeTheTagTokens(children));
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));
            
        list.Add(closing);
            
        return list;
    }
    
    private static IEnumerable<SyntaxNode> TypeTheTagTokens(IEnumerable<TagToken> tokens)
    {
        var list = new List<SyntaxNode>();

        foreach (var token in tokens)
        {
            if (token.Children.Any())
            {
                var first = token.Children.First();
                if (first is XmlDeclToken)
                {
                    list.Add(new DocumentToken(token.Children));
                }
                
                var last = token.Children.Last();
                switch (last)
                {
                    case ForwardSlashGtToken:
                        list.Add(new EmptyTagToken(token.Value, token.Children));
                        break;
                    case ClosingTagToken:
                        list.Add(token);
                        break;
                    case ClosingCommentTagToken:
                        list.Add(new CommentTagToken(token.Value, token.Children));
                        break;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(token.Value))
                {
                    list.Add(new WhitespacesToken(token.Value));
                }
                else
                {
                    list.Add(new TagContentToken(token.Value));
                }
            }
        }
            
        return list;
    }
}