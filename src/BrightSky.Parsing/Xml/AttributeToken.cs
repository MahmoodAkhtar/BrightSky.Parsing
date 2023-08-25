using Pidgin;
using static Pidgin.Parser;

namespace BrightSky.Parsing.Xml;

internal record AttributeToken : SyntaxNode
{
    internal AttributeToken(string value, IEnumerable<SyntaxNode> children) : base(value, children)
    {
    }
    
    internal static readonly Parser<char, AttributeToken> Parser = 
        from before in (
            from ws in Whitespace
            select ws).Many()
        from name in IdentifierToken.Parser
        from middle in (
            from ws in Whitespace
            select ws).Many()
        from eq in EqToken.Parser
        from after in (
            from ws in Whitespace
            select ws).Many()
        from value in AttributeValueToken.Parser
        select new AttributeToken(
            name.Value,
            OrganiseChildren(
                before as char[] ?? before.ToArray(),
                name,
                middle as char[] ?? middle.ToArray(),
                eq,
                after as char[] ?? after.ToArray(),
                value));

    private static IEnumerable<SyntaxNode> OrganiseChildren (
        char[] before,
        SyntaxNode name,
        char[] middle,
        SyntaxNode eq,
        char[] after,
        SyntaxNode value)
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

        list.Add(value);
            
        return list;
    }
}