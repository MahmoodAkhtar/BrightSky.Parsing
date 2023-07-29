namespace BrightSky.Parsing.Xml;

public class ClosingTagToken : SyntaxNode
{
    public ClosingTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static IEnumerable<SyntaxNode> OrganiseChildren (
        SyntaxNode opening,
        char[] before,
        SyntaxNode name,
        char[] after,
        SyntaxNode closing)
    {
        var list = new List<SyntaxNode>
        {
            opening
        };
            
        if (before.Any())
            list.Add(new WhitespacesToken(new string(before)));

        list.Add(name);
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));

        list.Add(closing);

        return list;
    }
}