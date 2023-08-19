using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal class EmptyTagToken : SyntaxNode
{
    internal EmptyTagToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
 
    internal static readonly Parser<char, TagToken> Parser = 
        from opening in LtToken.Parser
        from before in (
            from ws in Whitespace
            select ws).Many()
        from name in IdentifierToken.Parser
        from middle in (
            from ws in Whitespace
            select ws).Many()
        from attributes in (
            from attribute in Try(AttributeToken.Parser)
            select attribute).Many()
        from after in (
            from ws in Whitespace
            select ws).Many()
        from closing in ForwardSlashGtToken.Parser
        select new TagToken(
            name.Value,
            OrganiseChildren(
                opening,
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                attributes as AttributeToken[] ?? attributes.ToArray(),
                after as char[] ?? after.ToArray(),
                closing));


    private static IEnumerable<SyntaxNode> OrganiseChildren (
        SyntaxNode opening,
        char[] before,
        SyntaxNode name,
        char[] middle,
        AttributeToken[] attributes,
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