namespace BrightSky.Parsing.Xml;

public class OpeningTagToken : SyntaxNode
{
    public OpeningTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }

    internal static IEnumerable<SyntaxNode> OrganiseChildren (
        SyntaxNode opening,
        char[] before,
        SyntaxNode name,
        char[]  middle,
        AttributeToken[] attributes,
        char[]  after,
        SyntaxNode closing)
    {
        var list = new List<SyntaxNode>
        {
            opening
        };

        if (before.Any())
            list.Add(new WhitespacesToken(new string(before)));

        list.Add(name);
            
        if (middle.Any())
            list.Add(new WhitespacesToken(new string(middle)));
            
        if (attributes.Any())
            list.AddRange(attributes);
            
        if (after.Any())
            list.Add(new WhitespacesToken(new string(after)));
            
        list.Add(closing);
            
        return list;
    }
}