namespace BrightSky.Parsing.Xml;

public class AttributeToken : SyntaxNode
{
    public AttributeToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static IEnumerable<SyntaxNode> OrganiseChildren (
        char[] before,
        SyntaxNode name,
        char[] middle,
        SyntaxNode eq,
        char[] after,
        SyntaxNode first,
        SyntaxNode value,
        SyntaxNode second)
    {
        var list = new List<SyntaxNode>();

        if (before.Any())
            list.Add(new WhitespacesToken(new string(before)));

        list.Add(name);

        if (middle.Any())
            list.Add(new WhitespacesToken(new string(middle)));

        list.Add(eq);
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));

        list.Add(first);
        list.Add(value);
        list.Add(second);
            
        return list;
    }
}