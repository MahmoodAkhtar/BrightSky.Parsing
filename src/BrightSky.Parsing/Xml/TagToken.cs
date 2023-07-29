namespace BrightSky.Parsing.Xml;

public class TagToken : SyntaxNode
{
    public TagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static IEnumerable<SyntaxNode> OrganiseChildren (
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
                var last = token.Children.Last();
                switch (last)
                {
                    case ForwardSlashGtToken:
                        list.Add(new EmptyTagToken(token.Value, token.Children));
                        break;
                    case ClosingTagToken:
                        list.Add(token);
                        break;
                }
            }
            else
            {
                list.Add(new TagContentToken(token.Value));
            }
        }
            
        return list;
    }
}